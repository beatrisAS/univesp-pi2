namespace univesp_pi2.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public required string Author { get; set; }
        public int Rating { get; set; }
        public required string Date { get; set; }
        public required string Comment { get; set; }
    }
}