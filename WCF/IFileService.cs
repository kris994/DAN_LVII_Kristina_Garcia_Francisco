using System.ServiceModel;

namespace WCF
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        string GetData(int value);
    }
}
