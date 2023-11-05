using SMS.MstSoftwares;
using System;
using Volo.Abp.Application.Dtos;

namespace SMS.MstSoftwares;

public class MstSoftwareDto : AuditedEntityDto<int>
{
    public string SoftwareCode { get; set; }

    public string SoftwareName { get; set; }
    public string SoftwareDescription { get; set; }
    public SoftwareStatus SoftwareStatus { get; set; }
}
