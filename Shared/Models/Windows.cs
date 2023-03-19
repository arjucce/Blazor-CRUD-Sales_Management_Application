using System.ComponentModel.DataAnnotations;

namespace SalesManagementApp.Shared.Models
{
    public class Windows
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
