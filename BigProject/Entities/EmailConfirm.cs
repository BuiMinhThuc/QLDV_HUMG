using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigProject.Entities
{
    public class EmailConfirm : EntityBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Code { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
        public DateTime Exprired { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public bool IsActiveAccount { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
