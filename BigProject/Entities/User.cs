using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigProject.Entities
{
    public class User : EntityBase
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MaSV { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public ICollection<RefreshToken> refreshTokens { get; set; } = new List<RefreshToken>();
        public ICollection<EmailConfirm> emailConfirms { get; set; } = new List<EmailConfirm>();
        public ICollection<Document> documents { get; set; } = new List<Document>();
    }
}
