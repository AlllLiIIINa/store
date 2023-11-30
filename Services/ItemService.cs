using System;
using System.Collections.Generic;
using System.Linq;
using Store.ItemManager.Database;
using Store.ItemManager.Models;

namespace Store.ItemManager.Services
{
    public class ItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.Find(id);
        }

        public void AddItem(Item item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void UpdateItem(int id, Item model)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                item.Name = model.Name;
                item.Description = model.Description;
                item.Price = model.Price;
                _context.SaveChanges();
            }
        }

        public void DeleteItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
