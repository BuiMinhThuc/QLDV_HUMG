using BigProject.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigProject.Entities
{
    public class RewardDiscipline : EntityBase
    {
        [Required]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool RewardOrDiscipline { get; set; }
        public RequestEnum Status { get; set; }
        public string? RejectReason { get; set; }
        //public int RewardDisciplineTypeId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public User Recipient { get; set; } 
        [Required]
        public int ProposerId { get; set; }
        [ForeignKey("ProposerId")]
        public User Proposer { get; set; }
        //public RewardDisciplineType RewardDisciplineType { get; set; }
    }
}
