using System.ComponentModel.DataAnnotations;

namespace LibDispensary;

public class Dispensary
{
    private int _rowNum;
    private string _fullName;
    private string _shortName;
    private Address _address;
    private string _chiefName;
    private string _chiefPosition;
    private string _chiefGender;
    private PhoneAttribute _chiefPhone;
    private string _closeFlag;
    private string _closeReason;
    private DateOnly _closeDate;
    private DateOnly _reopenDate;
    private string _workingHours;
    private string _clarificationOfWorkingHours;
    private string _specialization;
    private string _beneficialDrugPrescriptions;
    private string _extraInfo;
    private double _pointX;
    private double _pointY;
    private int _globalId;
    
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Dispensary() {}
    
    /// <summary>
    /// Main constructor.
    /// </summary>
    public Dispensary(int rowNum, string fullName, string shortName, string chiefName,
        string chiefPosition, string chiefGender, PhoneAttribute chiefPhone, string closeFlag, string closeReason,
        DateOnly closeDate, DateOnly reopenDate, string workingHours, string clarificationOfWorkingHours,
        string specialization, string beneficialDrugPrescriptions, string extraInfo,
        double pointX, double pointY, int globalId,
        int postalCode, string admArea, string district, 
        PhoneAttribute publicPhone, PhoneAttribute fax, EmailAddressAttribute email)
    {
        _rowNum = rowNum;
        _fullName = fullName;
        _shortName = shortName;
        _chiefName = chiefName;
        _chiefPosition = chiefPosition;
        _chiefGender = chiefGender;
        _chiefPhone = chiefPhone;
        _closeFlag = closeFlag;
        _closeReason = closeReason;
        _closeDate = closeDate;
        _reopenDate = reopenDate;
        _workingHours = workingHours;
        _clarificationOfWorkingHours = clarificationOfWorkingHours;
        _specialization = specialization;
        _beneficialDrugPrescriptions = beneficialDrugPrescriptions;
        _extraInfo = extraInfo;
        _pointX = pointX;
        _pointY = pointY;
        _globalId = globalId;

        _address = new Address(postalCode, admArea, district, publicPhone, fax, email);
    }
    
    // Dispensary realization.
}