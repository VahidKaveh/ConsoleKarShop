namespace ConsoleKarShop.Domain.Entites
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Description { get; set; }
        public int NewValue { get; set; }

    }
}