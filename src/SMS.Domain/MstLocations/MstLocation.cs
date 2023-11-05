using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace SMS.MstLocations
{
    public class MstLocation : Entity
    {
        [Key]
        [Required]
        public string LocationCode { get; set; }

        [Required]
        public string LocationName { get; set; }

        public int LocationType { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { LocationCode };
        }
    }
}

