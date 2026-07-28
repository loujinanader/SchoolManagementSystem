using System;
using School.Api.Models;
using School.Api.Repository;
using School.Api.Services;

public class StudentService : IstudentService
{
	if (student.Age< 16 || student.Age> 18)
{
    throw new Exception("Invalid student age");
}
if (string.IsNullOrEmpty(student.StudentName))
{
    throw new Exception("Student name cannot be empty");

    if (student.CID <= 0)
    {
        throw new Exception("Invalid class ID");
    }



}
