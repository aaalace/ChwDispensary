using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibDispensary;

public class Dispensary
{
    private string _rowNum;
    private string _fullName;
    private string _shortName;
    private string _chiefName;
    private string _chiefPosition;
    private string _chiefGender;
    private string _chiefPhone;
    private string _closeFlag;
    private string _closeReason;
    private string _closeDate;
    private string _reopenDate;
    private string _workingHours;
    private string _clarificationOfWorkingHours;
    private string _specialization;
    private string _beneficialDrugPrescriptions;
    private string _extraInfo;
    private string _pointX;
    private string _pointY;
    private string _globalId;
    
    private Address _addressObj;
    
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Dispensary() {}
    
    /// <summary>
    /// Main constructor.
    /// </summary>
    public Dispensary(string rowNum, string fullName, string shortName, string admArea, 
        string district, string postalCode, string address, string chiefName,
        string chiefPosition, string chiefGender, string chiefPhone, string publicPhone,
        string fax, string email, string closeFlag, string closeReason,
        string closeDate, string reopenDate, string workingHours, string clarificationOfWorkingHours,
        string specialization, string beneficialDrugPrescriptions, string extraInfo,
        string pointX, string pointY, string globalId)
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

        _addressObj = new Address(postalCode: postalCode, admArea: admArea,
            district: district, publicPhone: publicPhone,
            fax: fax, email: email, address: address);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        return _rowNum;
    }
}