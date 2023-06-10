using System.ComponentModel.DataAnnotations;

namespace FindMeJob.API.Entities
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
