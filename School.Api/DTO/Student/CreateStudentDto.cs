
using System.ComponentModel.DataAnnotations;

public class CreateStudentDto
{
    [Required]
    [StringLength(50)]
    public string StudentName { get; set; }

    [Range(5, 18)]
    public int Age { get; set; }

    [Required]
    public int CID { get; set; }


}
