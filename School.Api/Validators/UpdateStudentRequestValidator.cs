using FluentValidation;
using School.Api.DTO.Request;
namespace School.Api.Validators
{
    public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentRequestValidator>
    {
        public UpdateStudentRequestValidator()
        {
            RuleFor(x => x.StudentName)
            .NotEmpty().WithMessage("StudentName is required.")
            .MaximumLength(50).WithMessage("StudentName cannot exceed 200 characters.");

            RuleFor(x => x.Age)
                .InclusiveBetween(5, 18);

            RuleFor(x => x.CID)
                   .GreaterThan(0);
        }
    }
}
