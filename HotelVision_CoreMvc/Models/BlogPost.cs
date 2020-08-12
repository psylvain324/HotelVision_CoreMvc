using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace HotelVision_CoreMvc.Models
{
    public class BlogPost
    {
        [Key]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        public string Post { get; set; }

        public string Summary { get; set; }

        public IFormFile PostImage { get; set; }

        public string ImageUrl { get; set; }
    }
}
