using System;
using Common.Domain.Core.Models;
using FluentValidation;
using ManageMainEvents.Domain.Model.Owners;

namespace ManageMainEvents.Domain.Model.MainEvents
{
    public class MainEvent : Entity<MainEvent>
    {
        public MainEvent(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public string DescriptionShort { get; private set; }

        public string DescriptinLong { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime FinishDate { get; private set; }

        public bool Free { get; private set; }

        public decimal Price { get; private set; }

        public bool Online { get; private set; }

        public string ClientName { get; private set; }

        public Guid? CategoryId { get; private set; }

        public Guid? AddressId { get; private set; }

        public Guid OwnerId { get; private set; }

        // EF Property Navigation 
        public virtual Category Category { get; private set; }

        public virtual Address Address { get; private set; }

        public virtual Owner Owner { get; private set; }

        // EF Constructor
        protected MainEvent() { }

        public override bool IsValid()
        {
            Validations();
            return ValidationResult.IsValid;
        }

        #region Validations

        void Validations()
        {
            ValidateInputs();
            ValidationResult = Validate(this);
            ValidateAddressInputs();
        }

        void ValidateInputs()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("Name must be not empty")
               .Length(2, 150).WithMessage("Name length must be between 2 and 150 characterss");


            if (!Free)
                RuleFor(c => c.Price)
                            .ExclusiveBetween(1, 50000)
                            .WithMessage("O valor deve estar entre 1.00 e 50.000");

            if (Free)
                RuleFor(c => c.Price)
                    .Equal(0).When(e => e.Free)
                            .WithMessage("O valor não deve diferente de 0 para um evento gratuito");

            RuleFor(c => c.StartDate)
                .LessThan(c => c.FinishDate)
                .WithMessage("A data de início deve ser maior que a data do final do evento");

            RuleFor(c => c.StartDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("A data de início não deve ser menor que a data atual");



            if (Online)
                RuleFor(c => c.Address)
                    .Null().When(c => c.Online)
                    .WithMessage("O evento não deve possuir um endereço se for online");

            if (!Online)
                RuleFor(c => c.Address)
                    .NotNull().When(c => c.Online == false)
                    .WithMessage("O evento deve possuir um endereço");

        }

        void ValidateAddressInputs()
        {
            if (Online) return;
            if (Address.IsValid()) return;

            foreach (var error in Address.ValidationResult.Errors)
                ValidationResult.Errors.Add(error);
        }
        #endregion

        #region Factory
        public static class MainEventFactory
        {
            public static MainEvent NewMainEvent(Guid id, string name)
            {
                var mainEvent = new MainEvent()
                {
                    Id = id,
                    Name = name
                };

                //if (ownerId.HasValue)
                //    mainEvent.OwnerId = ownerId.Value;

                //if (online)
                //    mainEvent.Address = null;

                return mainEvent;
            }
        }
        #endregion
    }
}