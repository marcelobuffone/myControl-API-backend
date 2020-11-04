using System;

namespace MBAM.Business.Models.Payment
{
    public class Payment : Entity<Payment>
    {
        public virtual string Description { get; set; }
        public virtual double Value { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual PaymentType Type { get; set; }
        public virtual bool IsActive { get; set; }

        public Payment()
        {
            IsActive = true;
        }
    }

    public enum PaymentType
    {
        expense,
        profit
    }
}
  