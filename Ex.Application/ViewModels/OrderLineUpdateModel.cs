using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.ViewModels
{
    public class OrderLineUpdateModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
