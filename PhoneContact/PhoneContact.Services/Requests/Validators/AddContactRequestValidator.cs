using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Services.Requests.Validators
{
    public class AddContactRequestValidator : AbstractValidator<AddContactRequest>
    {
        public AddContactRequestValidator()
        {
            RuleFor(artist => artist.FirstName).NotEmpty();
            RuleFor(artist => artist.LastName).NotEmpty();
        }
    }
}