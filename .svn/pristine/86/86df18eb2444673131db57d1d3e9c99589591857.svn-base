using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SMS.Data;

/* This is used if database provider does't define
 * ISMSDbSchemaMigrator implementation.
 */
public class NullSMSDbSchemaMigrator : ISMSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
