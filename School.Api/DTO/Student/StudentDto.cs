namespace School.Api.DTO.Student
{
    public class StudentDto
{
    public int StudentID { get; set; }

    public string StudentName { get; set; } = string.Empty;

        public int Age { get; set; }

    public string ClassName { get; set; } = string.Empty;
}
}

//public StudentDto MapStudent(Student student)
//{
      /*      var dto = new StudentDto
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                Age = student.Age,
                ClassName = student.ClassRoom?.ClassName
            };
*/
           // return dto;
      