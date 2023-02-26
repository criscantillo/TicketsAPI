using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Models.Data
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor Ingresar el nombre del usuario")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Por favor Ingresar el correo del usuario")]
        public string Email { get; set; }
    }
}
