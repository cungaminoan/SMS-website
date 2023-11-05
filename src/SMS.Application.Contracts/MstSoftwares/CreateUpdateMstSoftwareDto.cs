using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SMS.MstSoftwares
{
    public class CreateUpdateMstSoftwareDto
    {
        [Required]
        public string SoftwareCode { get; set; }
        [Required]
        public string SoftwareName { get; set; }
        public string SoftwareDescription { get; set; }
        public SoftwareStatus SoftwareStatus { get; set; } = SoftwareStatus.Active;
    }
}
