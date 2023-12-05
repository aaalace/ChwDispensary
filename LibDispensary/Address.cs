namespace LibDispensary;

public class Address
{
    private string _postalCode;
    private string _admArea;
    private string _district;
    private string _publicPhone;
    private string _fax;
    private string _email;
    private string _address;
    
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Address() {}

    /// <summary>
    /// Main constructor.
    /// </summary>
    public Address(string postalCode, string admArea, string district, 
        string publicPhone, string fax, string email, string address)
    {
        _postalCode = postalCode;
        _admArea = admArea;
        _district = district;
        _publicPhone = publicPhone;
        _fax = fax;
        _email = email;
        _address = address;
    }
}
