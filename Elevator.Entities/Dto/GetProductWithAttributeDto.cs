using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Entities.Dto
{
    public class GetProductWithAttributeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string ProductName { get; set; }
        [Required]
        public List<ProductAttributeDto> Attributes { get; set; }
    }
}
