public class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Method to calculate total cost for this product
    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    // Method to get product info for packing label
    public string GetPackingInfo()
    {
        return $"{_name} (ID: {_productId}) - Quantity: {_quantity}";
    }

    // Getters for properties
    public string Name { get { return _name; } }
    public string ProductId { get { return _productId; } }
    public decimal Price { get { return _price; } }
    public int Quantity { get { return _quantity; } }

    // Setters (if needed)
    public void SetQuantity(int quantity)
    {
        if (quantity >= 0)
            _quantity = quantity;
    }

    public void SetPrice(decimal price)
    {
        if (price >= 0)
            _price = price;
    }
}