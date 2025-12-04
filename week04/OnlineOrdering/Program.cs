using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ONLINE ORDERING SYSTEM");
        Console.WriteLine("=======================\n");
        
        // Create a list to store orders
        List<Order> orders = new List<Order>();
        
        // ORDER 1: Domestic Order (USA)
        Console.WriteLine("Creating Order 1: Domestic (USA) Order...\n");
        
        // Create customer and address
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        
        // Create products
        List<Product> products1 = new List<Product>
        {
            new Product("Laptop", "PROD001", 899.99m, 1),
            new Product("Wireless Mouse", "PROD002", 24.99m, 2),
            new Product("Laptop Bag", "PROD003", 49.99m, 1)
        };
        
        // Create order and add products
        Order order1 = new Order(customer1);
        order1.AddProducts(products1);
        orders.Add(order1);
        
        // ORDER 2: International Order
        Console.WriteLine("Creating Order 2: International Order...\n");
        
        // Create customer and address
        Address address2 = new Address("456 Maple Ave", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Maria Garcia", address2);
        
        // Create products
        List<Product> products2 = new List<Product>
        {
            new Product("Smartphone", "PROD004", 699.99m, 1),
            new Product("Phone Case", "PROD005", 19.99m, 2),
            new Product("Screen Protector", "PROD006", 9.99m, 3),
            new Product("Wireless Earbuds", "PROD007", 129.99m, 1)
        };
        
        // Create order and add products
        Order order2 = new Order(customer2);
        order2.AddProducts(products2);
        orders.Add(order2);
        
        // ORDER 3: Another Domestic Order (USA)
        Console.WriteLine("Creating Order 3: Domestic Order with Multiple Items...\n");
        
        // Create customer and address
        Address address3 = new Address("789 Oak Blvd", "Seattle", "WA", "USA");
        Customer customer3 = new Customer("Robert Johnson", address3);
        
        // Create products
        List<Product> products3 = new List<Product>
        {
            new Product("Coffee Maker", "PROD008", 89.99m, 1),
            new Product("Coffee Beans (1lb)", "PROD009", 14.99m, 3)
        };
        
        // Create order and add products
        Order order3 = new Order(customer3);
        order3.AddProducts(products3);
        orders.Add(order3);
        
        // Display all orders
        Console.WriteLine("\n" + new string('*', 60));
        Console.WriteLine("PROCESSING ALL ORDERS");
        Console.WriteLine(new string('*', 60) + "\n");
        
        // Process and display each order
        for (int i = 0; i < orders.Count; i++)
        {
            Console.WriteLine($"Processing Order #{i + 1}:");
            orders[i].DisplayOrderSummary();
        }
        
        // Display system summary
        DisplaySystemSummary(orders);
        
        Console.WriteLine("\nAll orders processed successfully!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    
    static void DisplaySystemSummary(List<Order> orders)
    {
        Console.WriteLine("\n" + new string('*', 60));
        Console.WriteLine("SYSTEM SUMMARY");
        Console.WriteLine(new string('*', 60));
        
        int totalProducts = 0;
        decimal totalRevenue = 0;
        int domesticOrders = 0;
        int internationalOrders = 0;
        
        foreach (Order order in orders)
        {
            totalProducts += order.Products.Count;
            totalRevenue += order.CalculateTotalCost();
            
            if (order.Customer.LivesInUSA())
                domesticOrders++;
            else
                internationalOrders++;
        }
        
        Console.WriteLine($"\nTotal Orders Processed: {orders.Count}");
        Console.WriteLine($"  • Domestic Orders (USA): {domesticOrders}");
        Console.WriteLine($"  • International Orders: {internationalOrders}");
        Console.WriteLine($"\nTotal Products Ordered: {totalProducts}");
        Console.WriteLine($"Total Revenue: ${totalRevenue:F2}");
        
        // Calculate average order value
        if (orders.Count > 0)
        {
            decimal averageOrderValue = totalRevenue / orders.Count;
            Console.WriteLine($"Average Order Value: ${averageOrderValue:F2}");
        }
        
        Console.WriteLine(new string('*', 60));
    }
}