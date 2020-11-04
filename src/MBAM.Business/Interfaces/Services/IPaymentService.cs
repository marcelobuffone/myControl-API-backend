using MBAM.Business.Models.Payment;
using System;
using System.Threading.Tasks;

namespace MBAM.Business.Interfaces.Services
{
    public interface IPaymentService : IDisposable
    {
        Task<bool> Add(Payment payment);
        Task<bool> Update(Payment payment);
        Task<bool> Delete(Guid id);
        Task<bool> ChangeStatus(Payment payment, bool IsActive);
    }
}
