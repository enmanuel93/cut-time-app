using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CutTime.Domain.Models;
using FluentValidation;

namespace CutTime.Domain.Validations
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Campo nombre requerido!");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Campo apellido requerido!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Campo correo requerido!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Campo contraseña requerido!");

            RuleFor(x => x.PasswordConfirmed).NotEmpty().WithMessage("Campo confirmación de contraseña es requerido!");
            RuleFor(x => x.PasswordConfirmed).Equal(x => x.Password).WithMessage("La confirmación de contraseña no coincide con la contraseña");
        }
    }
}
