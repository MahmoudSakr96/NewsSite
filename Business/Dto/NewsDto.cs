using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business.Dto
{
    public class NewsDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Title"), MaxLength(100)]
        public string Title { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [AllowHtml]
        [DisplayName("Body")]

        public string Body { get; set; }
        public byte[]? Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }


        public IEnumerable<CategoryDto>? Categories { get; set; }

    }
    public class NewsGrid
    {
        public IEnumerable<NewsDto>? News { get; set; }
        public IEnumerable<CategoryDto>? Categories { get; set; }


    }

}
