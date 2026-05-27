using FluentValidation;
using TaskManager.Application.Commands.Tasks;

namespace TaskManager.Application.Validators
{
    /// <summary>
    /// اعتبارسنجی برای دستور به‌روزرسانی کار (UpdateTaskCommand).
    /// </summary>
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        /// <summary>
        /// قوانین اعتبارسنجی برای فیلدهای دستور به‌روزرسانی کار.
        /// </summary>
        public UpdateTaskCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("شناسه کار نمی‌تواند خالی باشد");

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