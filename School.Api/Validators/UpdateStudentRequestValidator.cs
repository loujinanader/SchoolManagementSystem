using FluentValidation;
using School.Api.DTO.Request;

namespace School.Api.Validators
{
    public class UpdateStudentValidator : AbstractValidator<CreateStudentRequest>
    {
        public UpdateStudentValidator()
        {
            RuleFor(x => x.StudentName)
                .MaximumLength(50)
                .When(x => x.StudentName != null);

            RuleFor(x => x.Age)
                .InclusiveBetween(5, 18)
                .When(x => x.Age.HasValue);

            RuleFor(x => x.CID)
                .GreaterThan(0)
                .When(x => x.CID.HasValue);
        }

    }
}