using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Models
{
    public class Order : Entity, IAggregateRoot
    {
        private Guid _CustomerId { get; set; }
        private float _Number { get; set; }
        private Guid _TenantId { get; set; }
        private double _Sum { get; set; }
        private readonly List<OrderLine> _orderLines = new List<OrderLine>() ;

        protected Order()
        {
            _orderLines = new List<OrderLine>();
        }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float Number { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public double Sum { get; set; }
        public IEnumerable<OrderLine> OrderLines => _orderLines;
        public Order(Guid id, Guid customerId,float number,Guid tenantId,double sum)
        {
            Id = id;
            CustomerId = customerId;
            Number = number;
            TenantId = tenantId;
            Sum = sum;

        }
        public void AddOrderItem(IEnumerable<OrderLine> neworderLines)
        {
            if (neworderLines == null)
            {
                throw new ArgumentNullException(nameof(neworderLines));
            }
            if (!neworderLines.Any())
            {
                throw new ArgumentException("Must have at least 1 order line.", nameof(neworderLines));
            }
            _orderLines.Clear();
            _orderLines.AddRange(neworderLines);
        }
        public double GetSum()
        {
            return _Sum = _orderLines.Sum(o => o.Quantity * o.ProductPrice);
        }
    }
}
