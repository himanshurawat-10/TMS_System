namespace TMS.Models
{
    public class RequestViewModel
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string BatchName { get; set; }
        public string CourseName { get; set; }
        public string Trainer { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

    }
}
