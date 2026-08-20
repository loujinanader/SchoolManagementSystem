using System.ComponentModel.DataAnnotations;
namespace School.Api.DTO.Request
{
    public class CreateStudentRequest
    {
        [Required]
        [StringLength(50)]
        public string StudentName { get; set; } = string.Empty;
        [Range(5, 18)]
        public int Age { get; set; }
        [Required]
        public int CID { get; set; }
        public int StudentID { get; set; }
    }
}