using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace SMS.MstSoftwareVersions
{
    public class MstSoftwareVersion : Entity
    {
        [Key]
        public string SoftwareCode { get; set; }
        [Key]
        public string VersionCode { get; set; }
        public string? VersionContent { get; set; }
        public int? VersionStatus { get; set; }
        public override object[] GetKeys()
        {
            return new object[] { SoftwareCode, VersionCode };
        }
    }
}
