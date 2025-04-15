namespace BigProject.Entities
{
    public class Document : EntityBase
    {
        public string DocumentTitle { get; set; }
        public string DocumentContent { get; set; }
        public string UrlAvatar { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
