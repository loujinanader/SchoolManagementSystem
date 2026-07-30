using System.ComponentModel.DataAnnotations;
namespace School.Api.DTO.Student 
{
    public class StudentDto {

        public int StudentID { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string ClassName { get; set; } = string.Empty;
    } 
}

