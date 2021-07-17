using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.ViewModels
{
    public class TenantCreateModel
    {
        [Required(ErrorMessage = "The Title is Required")]
        [MinLength(2)]
        [MaxLength(250)]
        [DisplayName("Title")]
        public string Title { get; set; }
    }
}
