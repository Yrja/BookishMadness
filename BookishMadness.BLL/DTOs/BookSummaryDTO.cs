namespace BookishMadness.BLL.DTOs
{
    public class BookSummaryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorFullName { get; set; }
        public float AvgReaction { get; set; }
        public int ReactionsCount { get; set; }
        public int LikesQuantity { get; set; }
        public int DislikesQuantity { get; set; }
    }
}
