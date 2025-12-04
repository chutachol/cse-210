public class Customer
{
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Method to check if customer lives in USA
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }

    // Method to get shipping label info
    public string GetShippingLabel()
    {
        return $"Ship to:\n{_name}\n{_address.GetFullAddress()}";
    }

    // Getters for properties
    public string Name { get { return _name; } }
    public Address Address { get { return _address; } }
}