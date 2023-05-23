using System.ComponentModel.DataAnnotations;

namespace TMS.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int BatchId { get; set; }
        public Batch batch { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }

        public string Status { get; set; } = "pending";
    }
}
