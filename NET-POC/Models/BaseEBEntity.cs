using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NET_POC.Models
{
    public class BaseEBEntity
    {
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now.ToUniversalTime();

        [Required]
        public string DateCreatedTimezone { get; set; } = "America/Montreal";

        public DateTime? DateDeleted { get; set; }

        public string DateDeletedTimezone { get; set; }

        public bool Deleted { get; set; } = false;
    }
}