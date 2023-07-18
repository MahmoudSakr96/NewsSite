using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    [Table("News", Schema = "NewsSite")]
    public class News : Auditing
    {
        public News() { 
            this.Date = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }
        public DateTime Date { get; set; }

        [AllowHtml]
        public string Body { get; set; }
        public byte[] Image { get; set; }

        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
