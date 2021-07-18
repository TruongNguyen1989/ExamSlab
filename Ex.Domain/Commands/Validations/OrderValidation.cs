using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands.Validations
{
    public class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
       
    }
}
