// WishlistManager.cs
public class WishlistManager
{
    private List<WishlistItem> wishlist = new();

    public void AddItem(WishlistItem item) => wishlist.Add(item);
    public void RemoveItem(WishlistItem item) => wishlist.Remove(item);
    public decimal GetTotalCost()
    {
        decimal total = 0;
        foreach (var item in wishlist)
            total += item.Price;
        return total;
    }
}