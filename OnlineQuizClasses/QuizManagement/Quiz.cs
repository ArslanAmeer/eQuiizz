using System.ComponentModel.DataAnnotations;

namespace OnlineQuizClasses.QuizManagement
{
    public class Quiz
    {
        public int Id { get; set; }
        [Required]
        public string QuizTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required(ErrorMessage = "Total Question Field is Required")]
        public int TotalQuestion { get; set; }
        [Required]
        public string TotalTime { get; set; }
    }
}
