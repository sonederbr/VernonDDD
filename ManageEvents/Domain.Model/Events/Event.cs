using System;
using System.Collections.Generic;
using Common.Domain.Core;

namespace ManageEvents.Domain.Model.Events
{
    public class Event: Entity
    {
        public string Name { get; private set; }

        public string DescriptionShort { get; private set; }

        public string DescriptinLong { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime FinishDate { get; private set; }

        public bool Free { get; private set; }

        public decimal Price { get; private set; }

        public bool Online { get; private set; }

        public string ClientName { get; private set; }

        public Category Category { get; private set; }

        public IEnumerable<Tags> Tags { get; private set; }

        public Address Address { get; private set; }

        public Owner Owner { get; private set; }
    }
}
