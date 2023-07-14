using System.ComponentModel.DataAnnotations;

namespace Enversoft.Web.Models
{
    public class SupplierModel
    {
        public int SupplierId { get; set; }

        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public string Telephone { get; set; }
    }
}
