using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(C => C.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(95000).When(c => c.BrandId == 3);
            //RuleFor(c => c.Description).Must(StartWithA).WithMessage("Açıklamalar 'A' harfi ile başlamalı");
        }



        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
