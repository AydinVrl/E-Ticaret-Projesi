using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.Models
{
    public class OrderUserDTO
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string OrderName { get; set; }
        public string City { get; set; }
        public bool IsShipped { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
