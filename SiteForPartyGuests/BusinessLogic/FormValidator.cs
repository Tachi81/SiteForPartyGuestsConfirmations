using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using SiteForPartyGuests.Models;

namespace SiteForPartyGuests.BusinessLogic
{
    public class FormValidator : AbstractValidator<Form>
    {
        public FormValidator()
        {
            RuleFor(x => x.Name).NotEmpty();//.WithMessage("Pole imie jest puste");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Pole nazwisko jest puste");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Pole nazwisko jest puste")
                .Matches("[A - Za - z.] +@+[A - Za - z.] +.[A - Za - z.]").WithMessage("wstaw poprawnego maila");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Pole telefon jest puste")
                .Matches("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}");

        }
    }
}