namespace MobyIpsumAPI.Data
{
    public class MobyDto
    {
        private readonly MobyContext _ctx = new MobyContext();
        public string Title { get; set; }
        public string Content { get; set; }
        public string Opening { get; set; }
        public MobyDto(string title)
        {
            var novel = _ctx.Novels.FirstOrDefault(n => n.Title == title);
            if (novel == null) return;
            Title = novel.Title;
            Content = novel.Content;
            Opening = novel.Opening;
        }
    }
}
