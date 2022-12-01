using System.ComponentModel.DataAnnotations;

namespace FamilyApplication.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        
        public string CategoryName { get; set; }

    
    }
}