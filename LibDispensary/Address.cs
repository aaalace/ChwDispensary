using System.ComponentModel.DataAnnotations;

namespace LibDispensary;

public class Address
{
    private int _postalCode;
    private string _admArea;
    private string _district;
    private PhoneAttribute _publicPhone;
    private PhoneAttribute _fax;
    private EmailAddressAttribute _email;
    
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Address() {}

    /// <summary>
    /// Main constructor.
    /// </summary>
    public Address(int postalCode, string admArea, string district, 
        PhoneAttribute publicPhone, PhoneAttribute fax, EmailAddressAttribute email)
    {
        _postalCode = postalCode;
        _admArea = admArea;
        _district = district;
        _publicPhone = publicPhone;
        _fax = fax;
        _email = email;
    }
    
    // Address realization.
}
