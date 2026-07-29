namespace School.Api.Models.ClassRoom
{
    public class ClassRoom
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public System.Collections.Generic.ICollection<School.Api.Models.Student.Student> Students { get; set; }
          = new System.Collections.Generic.List<School.Api.Models.Student.Student>();
    }
}
