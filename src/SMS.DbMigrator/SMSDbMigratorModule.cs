using SMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SMS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SMSEntityFrameworkCoreModule),
    typeof(SMSApplicationContractsModule)
    )]
public class SMSDbMigratorModule : AbpModule
{
}
