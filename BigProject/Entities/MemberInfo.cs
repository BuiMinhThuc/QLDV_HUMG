using BigProject.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigProject.Entities
{
    public class MemberInfo : EntityBase
    {
        public string? Class { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? FullName { get; set; }
        public string? Nation { get; set; }  
        public string? religion { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UrlAvatar { get; set; }
        public string? PoliticalTheory{ get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string? PlaceOfJoining { get; set; }
        public bool IsOutstandingMember { get; set; } = false;
        public MemberInfoEnum Status { get; set; } = MemberInfoEnum.studying;
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public ICollection<RequestToBeOutStandingMember> requestToBeOutStandingMembers { get; set; } = new List<RequestToBeOutStandingMember>();
    }
}   
