using MBAM.Business.Interfaces;
using MBAM.Business.Interfaces.Repository;
using MBAM.Business.Interfaces.Services;
using MBAM.Business.Models.Payment;
using System;
using System.Threading.Tasks;

namespace MBAM.Business.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository,
                              IMessenger messenger) :base(messenger)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> Add(Payment payment)
        {
            if (!ExecuteValidation(new PaymentValidation(), payment)) return false;
            payment.IsActive = true;
            await _paymentRepository.Add(payment);
            return true;
        }

        public async Task<bool> Update(Payment payment)
        {
            if (!ExecuteValidation(new PaymentValidation(), payment)) return false;

            await _paymentRepository.Update(payment);
            return true;
        }

        public async Task<bool> ChangeStatus(Payment payment, bool IsActive)
        {
            payment.IsActive = IsActive;

            await _paymentRepository.Update(payment);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _paymentRepository.Delete(id);
            return true;
        }

        public void Dispose()
        {
            _paymentRepository?.Dispose();
        }

    }
}
