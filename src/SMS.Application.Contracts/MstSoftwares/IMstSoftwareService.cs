using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SMS.MstSoftwares
{
    public interface IMstSoftwareService : ICrudAppService<
        MstSoftwareDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdateMstSoftwareDto>
    {
    }
}
