using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using MBAM.Api.Controllers;
using MBAM.Api.ViewModels;
using MBAM.Business.Interfaces;
using MBAM.Business.Interfaces.Repository;
using MBAM.Business.Interfaces.Services;
using MBAM.Business.Models.Archive;
using Microsoft.AspNetCore.Mvc;

namespace MBAM.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/V{version:apiVersion}/archive")]
    public class ArchiveController : BaseController
    {
        private readonly IArchiveService _archiveService;
        private readonly IArchiveRepository _archiveRepository;

        public ArchiveController(IArchiveService archiveService,
                                 IArchiveRepository archiveRepository,
                                 IMessenger messenger, IMapper mapper, IUser user) : base(messenger, mapper, user)
        {
            _archiveService = archiveService;
            _archiveRepository = archiveRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ArchiveViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ArchiveViewModel>>(await _archiveRepository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<ArchiveViewModel>> Create(ArchiveViewModel archiveViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            archiveViewModel.Path = Guid.NewGuid() + Path.GetExtension(archiveViewModel.Imagem);

            if (!UploadFile(archiveViewModel.ImagemUpload, archiveViewModel.Path))
                return CustomResponse(ModelState);

            await _archiveService.Add(_mapper.Map<Archive>(archiveViewModel));

            return CustomResponse(archiveViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ArchiveViewModel>> Delete(Guid id)
        {
            var archiveViewModel = await _archiveRepository.GetByIdNoTracking(id);

            if (archiveViewModel == null) return NotFound();

            await _archiveRepository.Delete(id);

            DeleteFile(archiveViewModel.Path);

            return CustomResponse(archiveViewModel);
        }

        private bool UploadFile(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotifyError("Image is required.");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotifyError("A file with this name already exists.");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }

        private void DeleteFile(string file)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

    }
}
