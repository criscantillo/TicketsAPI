using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsAPI.Models.Data
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor Ingresar un título para el ticket")]
        public string Title { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Por favor Ingresar el código del usuario")]
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required]
        public bool Open { get; set; } //Status
    }
}
