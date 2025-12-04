using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private decimal _shippingCost;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
        _shippingCost = CalculateShippingCost();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to add multiple products
    public void AddProducts(List<Product> products)
    {
        _products.AddRange(products);
    }

    // Method to calculate shipping cost
    private decimal CalculateShippingCost()
    {
        return _customer.LivesInUSA() ? 5.00m : 35.00m;
    }

    // Method to calculate total cost of the order
    public decimal CalculateTotalCost()
    {
        decimal totalProductCost = 0;
        foreach (Product product in _products)
        {
            totalProductCost += product.GetTotalCost();
        }
        return totalProductCost + _shippingCost;
    }

    // Method to get packing label
    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL\n";
        packingLabel += "===============\n";
        
        if (_products.Count == 0)
        {
            packingLabel += "No products in this order.\n";
        }
        else
        {
            for (int i = 0; i < _products.Count; i++)
            {
                packingLabel += $"Item {i + 1}: {_products[i].GetPackingInfo()}\n";
            }
        }
        
        return packingLabel;
    }

    // Method to get shipping label
    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }

    // Method to display complete order summary
    public void DisplayOrderSummary()
    {
        Console.WriteLine("\n" + new string('=', 60));
        Console.WriteLine("ORDER SUMMARY");
        Console.WriteLine(new string('=', 60));
        
        // Display shipping label
        Console.WriteLine("\n" + GetShippingLabel());
        
        // Display packing label
        Console.WriteLine("\n" + GetPackingLabel());
        
        // Display cost breakdown
        Console.WriteLine("COST BREAKDOWN");
        Console.WriteLine(new string('-', 40));
        
        decimal subtotal = 0;
        Console.WriteLine("Products:");
        foreach (Product product in _products)
        {
            decimal productTotal = product.GetTotalCost();
            Console.WriteLine($"  • {product.Name}: {product.Quantity} × ${product.Price:F2} = ${productTotal:F2}");
            subtotal += productTotal;
        }
        
        Console.WriteLine($"\nSubtotal: ${subtotal:F2}");
        Console.WriteLine($"Shipping Cost: ${_shippingCost:F2} ({(_customer.LivesInUSA() ? "USA" : "International")})");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine($"TOTAL: ${CalculateTotalCost():F2}");
        Console.WriteLine(new string('=', 60));
    }

    // Getters for properties
    public List<Product> Products { get { return new List<Product>(_products); } }
    public Customer Customer { get { return _customer; } }
    public decimal ShippingCost { get { return _shippingCost; } }
}