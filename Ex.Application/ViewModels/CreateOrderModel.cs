using Ex.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.ViewModels
{
    public class CreateOrderModel
    {
        [Required(ErrorMessage = "The Title is Required")]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage = "The Title is Required")]
        public Guid TenantId { get; set; }
        public List<CreateOrderLine> OrderLines { get; set; }
    }
}
