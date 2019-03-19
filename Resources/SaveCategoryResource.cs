using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)] // .NET core pipeline uses these annotations to validate the request payload
        public string Name { get; set; }
    }
}