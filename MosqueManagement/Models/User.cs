using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class User : IdentityUser
    {
        [Key]

        public int? id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? ic { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }
        public string? gender { get; set; }
        public string? phone { get; set; }
        public string? password { get; set; }
        public string? role { get; set; }

        //Relationships
        public List<Social>? Socials { get; set; }
        public List<Class>? Classs { get; set; }
        public List<Rental>? Rentals { get; set;}
        public List<Payment>? Payments { get; set; }
    }
}
