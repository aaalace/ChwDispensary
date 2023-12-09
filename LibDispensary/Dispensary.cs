namespace LibDispensary;

public class Dispensary
{
    private string _rowNum = string.Empty;
    private string _fullName = string.Empty;
    private string _shortName = string.Empty;
    private string _chiefName = string.Empty;
    private string _chiefPosition = string.Empty;
    private string _chiefGender = string.Empty;
    private string _chiefPhone = string.Empty;
    private string _closeFlag = string.Empty;
    private string _closeReason = string.Empty;
    private string _closeDate = string.Empty;
    private string _reopenDate = string.Empty;
    private string _workingHours = string.Empty;
    private string _clarificationOfWorkingHours = string.Empty;
    private string _specialization = string.Empty;
    private string _beneficialDrugPrescriptions = string.Empty;
    private string _extraInfo = string.Empty;
    private string _pointX = string.Empty;
    private string _pointY = string.Empty;
    private string _globalId = string.Empty;
    
    private Address _addressObj = new();

    public List<string> DataList { get; } = new();
    public Address Address => _addressObj;
    public string Specialization => _specialization;
    public string ChiefPosition => _chiefPosition;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public Dispensary() {}
    
    /// <summary>
    /// Main constructor.
    /// </summary>
    public Dispensary(List<string> dataList)
    {
        DataList = dataList;
        
        _rowNum = dataList[0];
        _fullName = dataList[1];
        _shortName = dataList[2];
        _chiefName = dataList[7];
        _chiefPosition = dataList[8];
        _chiefGender = dataList[9];
        _chiefPhone = dataList[10];
        _closeFlag = dataList[14];
        _closeReason = dataList[15];
        _closeDate = dataList[16];
        _reopenDate = dataList[17];
        _workingHours = dataList[18];
        _clarificationOfWorkingHours = dataList[19];
        _specialization = dataList[20];
        _beneficialDrugPrescriptions = dataList[21];
        _extraInfo = dataList[22];
        _pointX = dataList[23];
        _pointY = dataList[24];
        _globalId = dataList[25];

        _addressObj = new Address(postalCode: dataList[5], admArea: dataList[3],
            district: dataList[4], publicPhone: dataList[11],
            fax: dataList[12], email: dataList[13], address: dataList[6]);
    }

    public override string ToString() => string.Join(" | ", DataList);
}