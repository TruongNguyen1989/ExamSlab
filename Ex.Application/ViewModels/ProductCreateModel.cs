using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.ViewModels
{
    public class ProductCreateModel
    {
        [Required(ErrorMessage = "The Title is Required")]
        [MinLength(2)]
        [MaxLength(250)]
        [DisplayName("Title")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "The Price is Required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "The tenant id is Required")]
        public Guid TenantId { get; set; }

    }
}
