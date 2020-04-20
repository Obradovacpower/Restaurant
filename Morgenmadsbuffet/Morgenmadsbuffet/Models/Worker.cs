using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Morgenmadsbuffet.Models
{
    public class Worker
    {
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}
