using FluentValidation;
using TaskManager.Application.Commands.Tasks;

namespace TaskManager.Application.Validators
{
    /// <summary>
    /// اعتبارسنجی برای دستور ایجاد کار جدید (CreateTaskCommand).
    /// </summary>
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        /// <summary>
        /// قوانین اعتبارسنجی برای فیلدهای دستور ایجاد کار.
        /// </summary>
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("عنوان کار نمی‌تواند خالی باشد")
                .MaximumLength(200).WithMessage("عنوان کار نمی‌تواند بیشتر از ۲۰۰ کاراکتر باشد");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("توضیحات نمی‌تواند بیشتر از ۲۰۰۰ کاراکتر باشد")
                .When(x => x.Description is not null);

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("اولویت انتخاب‌شده معتبر نیست");

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("موعد تحویل باید در آینده باشد")
                .When(x => x.DueDate.HasValue);
        }
    }
}