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
        public DateTime DateCreatedUtc { get; set; } = DateTime.Now.ToUniversalTime();

        public DateTime? DateDeletedUtc { get; set; }
    }
}