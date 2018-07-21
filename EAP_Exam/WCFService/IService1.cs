using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "GetDoctors")]
        List<Doctor> GetDoctors();

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "GetDoctorsById/{id}")]
        Doctor GetDoctorsById(string id);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "PostDoctor")]
        void PostDoctor(Doctor newDoctor);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "DeleteDoctor")]
        void DeleteDoctor(int id);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}