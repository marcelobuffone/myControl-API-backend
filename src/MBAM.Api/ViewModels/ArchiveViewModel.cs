using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MBAM.Api.ViewModels
{
    public class ArchiveViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Path { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string ImagemUpload { get; set; }

        public string Imagem { get; set; }

    }
}
