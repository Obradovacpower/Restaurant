using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Morgenmadsbuffet.Models
{
    public class Buffet
    {
        [Key]
        public int orderId { get; set; }
        public int roomNum { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        [DataType(DataType.Date)]
        public DateTime day { get; set; }
        public int CheckedInAdult { get; set; }
        public int CheckedInChildren { get; set; }
    }
}
