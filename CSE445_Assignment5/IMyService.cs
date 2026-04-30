using System.ServiceModel;

namespace CSE445_Assignment5
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string ReverseString(string textInput);

        [OperationContract]
        int GetStringLength(string textInput);
    }
}