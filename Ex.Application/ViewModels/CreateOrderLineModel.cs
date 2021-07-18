using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.ViewModels
{
    public class CreateOrderLineModel
    {
        [Required(ErrorMessage = "The Title is Required")]
        public Guid ProductId { get; set; }
        [Required(ErrorMessage = "The Title is Required")]
        public int Quantity { get; set; }
    }
}
