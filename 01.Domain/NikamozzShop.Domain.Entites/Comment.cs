namespace ConsoleKarShop.Domain.Entites
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentBy { get; set; }
        public string Text { get; set; }
        public int Vote { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}