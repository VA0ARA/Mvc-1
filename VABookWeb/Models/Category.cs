using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace VABookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [DisplayName("Display order")]
        [Range(10,1000,ErrorMessage ="enter Number between 10-1000")]
        public int  Displayorder { get; set; }
        public DateTime MyProperty3 { get; set; }= DateTime.Now;
    }
}
