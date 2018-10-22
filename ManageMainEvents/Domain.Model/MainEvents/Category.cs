using System;
using System.Collections.Generic;
using Common.Domain.Core.Models;

namespace ManageMainEvents.Domain.Model.MainEvents
{
    public class Category: Entity<Category>
    {

        public Category(Guid id)
        {
            Id = id;
        }

        public string Name { get; private set; }

        // EF Property Navigation 
        public virtual ICollection<MainEvent> MainEvents { get; set; }

        // EF Constructor
        protected Category() { }

        public override bool IsValid()
        {
            return true;
        }
    }
}