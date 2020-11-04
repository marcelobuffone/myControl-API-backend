using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MBAM.Api.Controllers;
using MBAM.Api.ViewModels;
using MBAM.Business.Interfaces;
using MBAM.Business.Interfaces.Repository;
using MBAM.Business.Interfaces.Services;
using MBAM.Business.Models.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MBAM.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/V{version:apiVersion}/payment")]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentService paymentService,
                                 IPaymentRepository paymentRepository,
                                 IMessenger messenger, IMapper mapper, IUser user) : base(messenger, mapper, user)
        {
            _paymentService = paymentService;
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<PaymentViewModel>>(await _paymentRepository.GetAllActives());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PaymentViewModel>> GetById(Guid id)
        {
            var paymentViewModel = await GetPaymentById(id);

            if (paymentViewModel == null) return NotFound();

            return paymentViewModel;
        }

        private async Task<PaymentViewModel> GetPaymentById(Guid id)
        {
            return _mapper.Map<PaymentViewModel>(await _paymentRepository.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<PaymentViewModel>> Create(PaymentViewModel paymentViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _paymentService.Add(_mapper.Map<Payment>(paymentViewModel));

            return CustomResponse(paymentViewModel);
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PaymentViewModel>> Update(Guid id, PaymentViewModel paymentViewModel)
        {
            if (id != paymentViewModel.Id)
            {
                NotifyError("The given id is not the same as what was passed in the query.");
                return CustomResponse(paymentViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _paymentService.Update(_mapper.Map<Payment>(paymentViewModel));

            return CustomResponse(paymentViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PaymentViewModel>> Excluir(Guid id)
        {
            var paymentViewModel = await _paymentRepository.GetByIdNoTracking(id);

            if (paymentViewModel == null) return NotFound();

            await _paymentService.ChangeStatus(_mapper.Map<Payment>(paymentViewModel), false);

            return CustomResponse(paymentViewModel);
        }
    }
}
