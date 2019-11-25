using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.Paymentservice.Context;
using MOD.Paymentservice.Models;

namespace MOD.Paymentservice.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentServiceContext _context;
        public PaymentRepository(PaymentServiceContext context)
        {
            _context = context;
        }
        public void Payment_Add(Payment item)
        {
            _context.Payments.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payments.ToList();
        }

        
    }
}
