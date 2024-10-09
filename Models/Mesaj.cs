using System.ComponentModel.DataAnnotations;

namespace Noksan_Music_Web.Models
{
    public class Mesaj
    {
        public int Id { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        [Required]
        public string Telefon { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Konu { get; set; }

        [Required]
        public string MesajMetni { get; set; }
    }
}