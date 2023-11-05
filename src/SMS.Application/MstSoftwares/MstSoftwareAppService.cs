using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SMS.MstSoftwares
{
    public class MstSoftwareAppService :
        CrudAppService<
            MstSoftware,
            MstSoftwareDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateMstSoftwareDto>,
        IMstSoftwareService
    {
        public MstSoftwareAppService(IRepository<MstSoftware, int> repository) : base(repository)
        {
        }
    }
}
