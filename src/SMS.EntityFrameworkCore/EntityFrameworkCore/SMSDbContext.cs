using Microsoft.EntityFrameworkCore;
using SMS.MstLocations;
using SMS.MstSoftwares;
using SMS.MstSoftwareVersions;
using SMS.MstVersionLocations;
using SMS.TblSoftwareLogs;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace SMS.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SMSDbContext :
    AbpDbContext<SMSDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    public DbSet<MstSoftware> MstSoftwares { get; set; }
    public DbSet<MstSoftwareVersion> MstSoftwareVersions { get; set; }
    public DbSet<MstVersionLocation> MstVersionLocations { get; set; }
    public DbSet<MstLocation> MstLocations { get; set; }
    public DbSet<TblSoftwareLog> tblSoftwareLogs { get; set; }


    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public SMSDbContext(DbContextOptions<SMSDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(SMSConsts.DbTablePrefix + "YourEntities", SMSConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<MstSoftware>(s =>
        {
            s.ToTable(SMSConsts.DbTablePrefix + "MstSoftwares",
                SMSConsts.DbSchema);
            s.ConfigureByConvention(); //auto configure for the base class props
            s.Property(s => s.SoftwareCode).IsRequired().HasMaxLength(20);
            s.Property(s => s.SoftwareName).IsRequired().HasMaxLength(100);
            s.Property(s => s.SoftwareDescription).HasMaxLength(255);
        });

        builder.Entity<MstSoftwareVersion>(s =>
        {
            s.ToTable(SMSConsts.DbTablePrefix + "MstSoftwareVersions",
                SMSConsts.DbSchema);
            s.ConfigureByConvention(); //auto configure for the base class props
            s.HasKey(s => new
            {
                s.SoftwareCode,
                s.VersionCode
            });
            s.Property(x => x.SoftwareCode).IsRequired().HasMaxLength(20);
            s.Property(x => x.VersionCode).HasMaxLength(20);
            s.Property(x => x.VersionContent).HasMaxLength(255);
        });

        builder.Entity<MstLocation>(loca =>
        {
            loca.ToTable(SMSConsts.DbTablePrefix + "MstLocations", SMSConsts.DbSchema);
            loca.ConfigureByConvention(); //auto configure for the base class props
            loca.Property(x => x.LocationCode).IsRequired().HasMaxLength(20);
            loca.Property(x => x.LocationName).IsRequired().HasMaxLength(100);
        });


        builder.Entity<TblSoftwareLog>(log =>
        {
            log.ToTable(SMSConsts.DbTablePrefix + "TblSoftwareLog", SMSConsts.DbSchema);
            log.ConfigureByConvention();
            log.HasKey(log => new
            {
                log.SoftwareCode,
                log.VersionCode,
            });
            log.Property(x => x.SoftwareCode).IsRequired().HasMaxLength(20);
            log.Property(x => x.VersionCode).HasMaxLength(20);
            log.Property(x => x.FactoryCode).IsRequired().HasMaxLength(20);
            log.Property(x => x.LineICode).IsRequired().HasMaxLength(20);
            log.Property(x => x.ProcessCode).IsRequired().HasMaxLength(20);
            log.Property(x => x.LogContent).HasMaxLength(20);
            log.Property(x => x.LogDateTime).HasMaxLength(20);

        });
        builder.Entity<MstVersionLocation>(s =>
        {
            s.ToTable(SMSConsts.DbTablePrefix + "MstVersionLocation",
                SMSConsts.DbSchema);
            s.ConfigureByConvention(); //auto configure for the base class props
            s.HasKey(s => new
            {
                s.SoftwareCode,
                s.VersionCode,
            });
            s.Property(x => x.SoftwareCode).IsRequired().HasMaxLength(20);
            s.Property(x => x.VersionCode).HasMaxLength(20);
            s.Property(x => x.Factorycode).HasMaxLength(20);
            s.Property(x => x.LinelCode).HasMaxLength(20);
            s.Property(x => x.ProcessCode).HasMaxLength(20);
            s.Property(x => x.FromDate).HasMaxLength(8);
            s.Property(x => x.ToDate).HasMaxLength(8);
        });
    }
}
