using DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.Validator.FluentValidation.UserValidations
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez.");
            RuleFor(u => u.Surname).NotEmpty().WithMessage("Kullanıcı Soyadı boş geçilemez.");
            RuleFor(u => u.IdentityNumber).NotEmpty().WithMessage("Kullanıcı TC Kimlik numarası boş geçilemez.");
            RuleFor(u => u.IdentityNumber).MaximumLength(11).MinimumLength(11).WithMessage("Kullanıcı TC Kimlik numarası 11 haneli olmak zorundadır!");
            RuleFor(u => u.EMail).EmailAddress().NotEmpty().WithMessage("E-mail Boş Geçilemez.");
            RuleFor(u => u.PhoneNumber).NotEmpty().WithMessage("Telefon numarası Boş Geçilemez.");

        }
    }
}
