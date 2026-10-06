using System.ComponentModel.DataAnnotations;

namespace BookManager.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Url]
        public string? CoverImageUrl { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        [Range(1, 10000)]
        public int NumberOfPages { get; set; }
    }
}