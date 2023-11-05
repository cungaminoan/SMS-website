using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.TblSoftwareLogs
{
    public class TblSoftwareLog
    {
        [Key]
        public string SoftwareCode { get; set; }

        [Key]
        public string? VersionCode { get; set; }

        public string FactoryCode { get; set; }

        public string LineICode { get; set; }

        public string ProcessCode { get; set; }

        public int? LogType { get; set; }

        public string? LogContent { get; set; }

        public string? LogDateTime { get; set; }

    }
}
