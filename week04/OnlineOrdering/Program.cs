using System;
using System.Collections.Generic;
using System.Text;

// Main program class to run the demonstration
public class Program
{
    public static void Main(string[] args)
    {
        // --- Order 1 ---
        // Create address and customer in the USA
        Address address1 = new Address("2 omolola street", "Surulere", "Lagos", "Nigeria");
        Customer customer1 = new Customer("Ademola Samuel", address1);

        // Create products for the order
        Product product1_1 = new Product("Laptop", "P-1001", 1200.50, 1);
        Product product1_2 = new Product("Mouse", "P-1002", 25.00, 2);
        Product product1_3 = new Product("Keyboard", "P-1003", 75.75, 1);

        // Create the order and add products
        Order order1 = new Order(customer1);
        order1.AddProduct(product1_1);
        order1.AddProduct(product1_2);
        order1.AddProduct(product1_3);

        // --- Order 2 ---
        // Create address and customer outside the USA
        Address address2 = new Address("46", "Bod Thomas", "Cheeetah", "Nigeria");
        Customer customer2 = new Customer("Tolani Mary", address2);

        // Create products for the order
        Product product2_1 = new Product("Book: The Art of C#", "P-2001", 49.99, 1);
        Product product2_2 = new Product("USB-C Hub", "P-2002", 39.95, 1);

        // Create the order and add products
        Order order2 = new Order(customer2);
        order2.AddProduct(product2_1);
        order2.AddProduct(product2_2);

        // --- Display Order Information ---
        Console.WriteLine("--- Order 1 Details ---");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalPrice():0.00}");
        Console.WriteLine("\n------------------------------------------\n");

        Console.WriteLine("--- Order 2 Details ---");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalPrice():0.00}");
        Console.WriteLine("\n------------------------------------------\n");
    }
}

/// <summary>
/// Represents an order containing a list of products for a specific customer.
/// </summary>
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost
        double shippingCost = _customer.LivesInUSA() ? 5.00 : 35.00;
        totalCost += shippingCost;

        return totalCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        foreach (var product in _products)
        {
            label.AppendLine($"  - Name: {product.GetName()}, ID: {product.GetProductId()}");
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}

/// <summary>
/// Represents a product with a name, ID, price, and quantity.
/// </summary>
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }
}

/// <summary>
/// Represents a customer with a name and an address.
/// </summary>
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }
}

/// <summary>
/// Represents a physical address.
/// </summary>
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        // Case-insensitive comparison for robustness
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_state}\n{_country}";
    }
}
