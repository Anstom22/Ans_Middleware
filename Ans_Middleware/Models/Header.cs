namespace Ans_Middleware.Models
{
    public class Header
    {
        public int Id { get; set; }
        public string? RequestId { get; set; }
        public string? Authorization { get; set; }
        public string? UserAgent { get; set; }
        public string? Host { get; set; }
        public string? CorrelationId { get; set; }

        
    }
}
