using System;
using System.ComponentModel.DataAnnotations;
using aspnetcoreapp1.Domains;

namespace aspnetcoreapp1.Models
{
    public class InsertProductViewModel
    {
        [Display(Prompt = "Enter Title")]
        [Required(ErrorMessage = "Title is required"), MaxLength(10, ErrorMessage = "Max length of title is 10 character")]
        public string Title { get; set; }

        public Category Category { get; set; }
        
        [Required(ErrorMessage = "Quantity is required"), Range(0, double.MaxValue, ErrorMessage = "Quantity must higher than 0")]
        public int Quantity { get; set; }

        [Display(Prompt = "Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Price is required"), Range(1, double.MaxValue, ErrorMessage = "Price must higher than 0")]
        public decimal Price { get; set; }
    }
}
