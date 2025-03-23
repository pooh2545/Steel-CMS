using SteelCMS.Shared;

public class CartService
{
    public event Action OnChange;

    private List<CartItem> cartItems = new();

    public IReadOnlyList<CartItem> GetItems() => cartItems;

    public void AddToCart(Product product)
    {
        var existingItem = cartItems.FirstOrDefault(i => i.ProductId == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cartItems.Add(new CartItem
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1,
                ImageUrl = product.ImageUrl
            });
        }

        NotifyStateChanged();
    }

    public void RemoveItem(CartItem item)
    {
        cartItems.Remove(item);
        NotifyStateChanged();
    }

    public void ClearCart()
    {
        cartItems.Clear();
        NotifyStateChanged();
    }

    public decimal GetTotalPrice() => cartItems.Sum(i => i.Price * i.Quantity);

    public void UpdateQuantity(string productId, int quantity)
    {
        var item = cartItems.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            if (quantity <= 0)
            {
                RemoveItem(item);
            }
            else
            {
                item.Quantity = quantity;
                NotifyStateChanged();
            }
        }
    }

    public int GetCartCount()
    {
        return cartItems.Sum(i => i.Quantity); // Or use cartItems.Count for unique items
    }

    public event Action OnCartChanged;

    private void NotifyStateChanged() => OnCartChanged?.Invoke();

}


public class CartItem
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}
