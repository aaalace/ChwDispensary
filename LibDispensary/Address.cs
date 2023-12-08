namespace LibDispensary;

public class Address
{
    private string _postalCode = string.Empty;
    private string _admArea = string.Empty;
    private string _district = string.Empty;
    private string _publicPhone = string.Empty;
    private string _fax = string.Empty;
    private string _email = string.Empty;
    private string _address = string.Empty;
    
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
