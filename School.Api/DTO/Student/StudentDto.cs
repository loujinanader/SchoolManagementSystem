using System;

    public class StudentDto
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public int Age { get; set; }

        public string ClassName { get; set; }
    new StudentDto
{
        StudentID = student.StudentID,
    StudentName = student.StudentName,
    Age = student.Age,
    ClassName = student.ClassRoom.ClassName
    }
}

