namespace ERMWebAPI.Services
{
    public interface IERMLogic
    {
        Model.ResultModel GetCalculations(string date, string datatype, string filename);
    }
}