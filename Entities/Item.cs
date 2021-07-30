using System;

namespace Catalog.Entities
{   
    //record instead of class because we're using record types here, record types offer the possibility to compare to objects and get a true even if they're note the same object but have similar properties
    public record Item
    {
        public Guid Id { get; init; } //init instead of init because we want it to be immutable. Init means that you can create this object but you can't modify it afterwards
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

    }   

}