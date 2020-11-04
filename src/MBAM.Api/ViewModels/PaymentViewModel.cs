using MBAM.Business.Models.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MBAM.Api.ViewModels
{
    public class PaymentViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public double Value { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public string Type { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
