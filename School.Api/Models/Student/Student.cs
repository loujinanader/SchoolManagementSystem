using System.Text.Json.Serialization;
namespace School.Api.Models.Student
{
    public class Student 
    { //[Age],[StudentId],[StudentName],[CID]
        public int Age { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int CID { get; set; }
        [JsonIgnore]
        public School.Api.Models.ClassRoom.ClassRoom? ClassRoom { get; set; }
    }
}
