using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CafeBlue
{
    [Table("Feedback")]
    public class FeedbackTable
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string LearnedComments { get; set; }
        public string OtherComments { get; set; }
        public int ExprienceRating { get; set; }
        public bool ReadStatus { get; set; }
    }
}
