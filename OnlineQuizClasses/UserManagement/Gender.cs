using System.ComponentModel.DataAnnotations;

namespace OnlineQuizClasses.UserManagement
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Gender")]
        public string Name { get; set; }
    }
}
