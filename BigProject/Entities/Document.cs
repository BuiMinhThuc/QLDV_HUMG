using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigProject.Entities
{
    public class Document : EntityBase
    {
        [Required]
        public string DocumentTitle { get; set; }
        [Required]
        public string DocumentContent { get; set; }
        [Required]
        public string UrlAvatar { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
