using FluentValidation;
using School.Api.DTO.Request;

public class CreateStudentRequestValidator
    : AbstractValidator<CreateStudentRequest>
{
    public CreateStudentRequestValidator()
    {
        RuleFor(x => x.StudentName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Age)
            .InclusiveBetween(5, 100);

        RuleFor(x => x.CID)
            .GreaterThan(0);
    }
}