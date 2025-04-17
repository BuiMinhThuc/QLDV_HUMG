using System.ComponentModel.DataAnnotations;

namespace BigProject.Entities
{
    public class Role : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public ICollection<User> users { get; set; } = new List<User>();
    }
}
