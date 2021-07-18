using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Models
{
    public class OrderLine : Entity
    {
        //public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public double Cost { get; set; }

        public OrderLine() { }
        public OrderLine(Guid id, Guid prodcutId, int quantity, double productPrice, double cost)
        {
            this.Id = id;
            this.ProductId = prodcutId;
            this.Quantity = quantity;
            this.ProductPrice = productPrice;
            this.Cost = cost;
        }
    }
}
