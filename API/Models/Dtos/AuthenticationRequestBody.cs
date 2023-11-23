using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
