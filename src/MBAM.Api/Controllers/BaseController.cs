using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MBAM.Business.Interfaces;
using MBAM.Business.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MBAM.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IMessenger _messenger;
        public readonly IMapper _mapper;
        public readonly IUser _user;
        public BaseController(IMessenger messenger,
                              IMapper mapper,
                              IUser user)
        {
            _messenger = messenger;
            _mapper = mapper;
            _user = user;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (!_messenger.HasMessage())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _messenger.GetMessages().Select(n => n.Value)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModel(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in errors)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string mensagem)
        {
            _messenger.Handle(new Message(mensagem));
        }

    }
}
