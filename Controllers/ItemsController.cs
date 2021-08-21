using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{

    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }
        //GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems(){
            return repository.GetItems().Select( item => item.AsDto());
            
        }
        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if(item is null) return NotFound();
            return item.AsDto();
        }

        //POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto) //Due to convention we return the item we create and we use action result as we could have to return multiple values
        {
            //We can create the object like this thanks to C#9
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            }; 
            //We use the repository method to add it
            repository.CreateItem(item);

            //We should return the item we created and a header that specifies where you will get that info
            return CreatedAtAction(nameof(GetItem), new { id = item.Id}, item.AsDto());
        }
    }
    
}