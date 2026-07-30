using System;
using System.ComponentModel.DataAnnotations;
namespace School.Api.DTO.Student
{
    public class UpdateStudentDto
    {
        //[Required]
        [StringLength(50)]
        public string StudentName { get; set; } = string.Empty;

        [Range(5, 18)]
        public int Age { get; set; }

       // [Required]
        public int CID { get; set; }
    }
}