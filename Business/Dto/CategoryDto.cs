using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business.Dto
{
    public class CategoryDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Category Name"), MaxLength(100)]
        public string Name { get; set; }

        [AllowHtml]
        public string Description { get; set; }
        public List <NewsDto>? News { get; set; }
    }
}
