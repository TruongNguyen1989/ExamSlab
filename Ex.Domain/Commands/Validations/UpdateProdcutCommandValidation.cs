﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands.Validations
{
    public class UpdateProdcutCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProdcutCommandValidation()
        {
            ValidateTitle();
        }
    }
}
