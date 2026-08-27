using FluentValidation;
using School.Api.DTO.Request;

namespace School.Api.Validators
{
    public class CreateStudentRequestValidator : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentRequestValidator()
        {
            RuleFor(x => x.StudentName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Age)
                .InclusiveBetween(5, 18);

            RuleFor(x => x.CID)
                .GreaterThan(0);
        }
    }
}