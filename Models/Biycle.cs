using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBaslangc.Models
{
    public class Biycle
    {
        [Key]
        public int ıd { get; set; }
        [Required(ErrorMessage ="Brand is Required")]
        public string? brand { get; set; }
        [Required(ErrorMessage = "Model is Required")]
        public string? model { get; set; }
        [Range(2000,2020,ErrorMessage ="Year must be between 2000 and 2020")]
        [Required(ErrorMessage = "Year is Required")]
        public int year { get; set; }
        [Required(ErrorMessage = "Type is Required")]
        public string? type { get; set; } 
        [Required(ErrorMessage = "Price is Required")]
        [Range(0, 30000, ErrorMessage = "Price must be  between 0 and 30000")]
        public decimal? price { get; set; }
        [Required(ErrorMessage = "Coloe is Required")]
        public string? color { get; set; }



        public string slug => $"{brand}-{model}-{year}".ToLower().Replace(" ", " -");
        public bool IsDeleted { get; set; } = false; 

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; 
        public DateTime? UpdatedDate { get; set; } 
        public DateTime? DeletedDate { get; set; } 
        public string? ImageFileName { get; set; }

    }
}
