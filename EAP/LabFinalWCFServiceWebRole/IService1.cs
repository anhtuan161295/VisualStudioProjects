using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LabFinalWCFServiceWebRole
{
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
    }
}