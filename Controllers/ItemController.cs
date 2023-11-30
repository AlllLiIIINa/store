using Microsoft.AspNetCore.Mvc;
using Store.ItemManager.Models;
using Store.ItemManager.Services;

namespace Store.ItemManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items = _itemService.GetItems();
                if (items.Count == 0)
                {
                    return NotFound("Products not found");
                }
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var item = _itemService.GetItemById(id);
                if (item == null)
                {
                    return NotFound("Item not found");
                }
                return Ok(item);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Error find Item. {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post(Item model)
        {
            try
            {
                _itemService.AddItem(model);
                return Ok("Item successfully created");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error Item create. {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Item model)
        {
            try
            {
                _itemService.UpdateItem(id, model);
                return Ok("Item successfully updated");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating Item. {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _itemService.DeleteItem(id);
                return Ok("Item successfully deleted");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting Item. {ex.Message}");
            }
        }
    }
}
