using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace School.Api.Models.Student
{
    public class Student
    { //[Age],[StudentId],[StudentName],[CID]
        //[Range(5, 18, ErrorMessage = "Age must be between 5 and 18")]
        public int Age { get; set; }
        public int StudentID { get; set; }
        //[Required]
        public string? StudentName { get; set; }

        public int? CID { get; set; }
        [JsonIgnore]
        public School.Api.Models.ClassRoom.ClassRoom? ClassRoom { get; set; }
    }
}
 
