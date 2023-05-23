﻿
using System.ComponentModel.DataAnnotations;

namespace TMS.Models
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public string Trainer { get; set; }
        public DateTime? StartDate { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
    }
}
