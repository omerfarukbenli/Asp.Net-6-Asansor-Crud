using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Entities.Models
{
    public class ProductWithCategory
    {
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
