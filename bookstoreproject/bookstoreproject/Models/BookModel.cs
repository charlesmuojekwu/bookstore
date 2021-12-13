using bookstoreproject.Helpers;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace bookstoreproject.Models
{
    public class BookModel
    {
       /* [DataType(DataType.EmailAddress)]
        [Display(Name ="Enter email address")]
        [EmailAddress]
        public string MyField { get; set; }*/


        public int Id { get; set; }
        //[StringLength(100,MinimumLength =5)]
        //[Required(ErrorMessage ="Please enter the title if your book book")]
        //[MyCustomValidationAttributes("Azure")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [StringLength(500, MinimumLength = 30)]
        public string Description { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage ="Please enter the total pages")]
        [Display(Name ="Total Pages of book")]
        public int? TotalPages { get; set; }

        
        [Display(Name = "Choose Cover Photo of book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose gallery Photo of book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }



    }
}
