using System.ComponentModel.DataAnnotations.Schema;

namespace Nnt_TvcLesson12.Models
{
    public partial class NntProduct
    {
        [NotMapped]
        public IFormFile? NntImageFile { get; set; }
    }
}