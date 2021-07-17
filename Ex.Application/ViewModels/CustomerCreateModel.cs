using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.ViewModels
{
    public class CustomerCreateModel
    {
        [Required(ErrorMessage = "The Title is Required")]
        [MinLength(2)]
        [MaxLength(250)]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The tenant id is Required")]
        public Guid  TenantId { get; set; }
    }
}
