using System;

namespace Catalog.Dtos
{
        public record ItemDto
    {
        public Guid Id { get; init; } //init instead of init because we want it to be immutable. Init means that you can create this object but you can't modify it afterwards
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }

    }       
}