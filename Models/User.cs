namespace Store.ItemManager.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Email { get; set; }

        public ICollection<Item> Items { get; } = new List<Item>();
    }
}
