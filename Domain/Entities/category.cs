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
    [Table("Categories", Schema = "NewsSite")]
    public class Category : Auditing
    {
        public Category()
        {
            News = new HashSet<News>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [AllowHtml]
        public string Description { get; set; }
        public virtual ICollection<News> News { get; set; }

    }
}
