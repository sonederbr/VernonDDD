using System;
using Common.Domain.Core.Models;
using FluentValidation;

namespace ManageMainEvents.Domain.Model.MainEvents
{
    public class Address : Entity<Address>
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Street2 { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipeCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid? MainEventId { get; private set; }

        // EF Property Navigation 
        public virtual MainEvent MainEvent { get; private set; }

        public Address(Guid id, string street, string number, string street2, string neighborhood, string zipCode, string city, string state, Guid? mainEventId)
        {
            Id = id;
            Street = street;
            Number = number;
            Street2 = street2;
            Neighborhood = neighborhood;
            ZipeCode = zipCode;
            City = city;
            State = state;
            MainEventId = mainEventId;
        }

        // EF Constructor
        protected Address() { }

        public override bool IsValid()
        {
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("O Logradouro precisa ser fornecido")
                .Length(2, 150).WithMessage("O Logradouro precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage("O Bairro precisa ser fornecido")
                .Length(2, 150).WithMessage("O Bairro precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.ZipeCode)
                .NotEmpty().WithMessage("O CEP precisa ser fornecido")
                .Length(8).WithMessage("O CEP precisa ter 8 caracteres");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("A Cidade precisa ser fornecida")
                .Length(2, 150).WithMessage("A Cidade precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("O Estado precisa ser fornecido")
                .Length(2, 150).WithMessage("O Estado precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("O Numero precisa ser fornecido")
                .Length(1, 10).WithMessage("O Numero precisa ter entre 1 e 10 caracteres");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}