using System.ComponentModel.DataAnnotations;

namespace BookCatalog_Project.Dtos
{
    public record CreateOrUpdateBookcs

    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Price { get; set; }
    }
}
