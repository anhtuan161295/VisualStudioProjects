﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab01WebRole.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/Lab01RemoteWCFService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Patient", Namespace="http://schemas.datacontract.org/2004/07/Lab01RemoteWCFService")]
    [System.SerializableAttribute()]
    public partial class Patient : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DatedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HourField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PatientIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PatientNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Dated {
            get {
                return this.DatedField;
            }
            set {
                if ((object.ReferenceEquals(this.DatedField, value) != true)) {
                    this.DatedField = value;
                    this.RaisePropertyChanged("Dated");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Hour {
            get {
                return this.HourField;
            }
            set {
                if ((this.HourField.Equals(value) != true)) {
                    this.HourField = value;
                    this.RaisePropertyChanged("Hour");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PatientId {
            get {
                return this.PatientIdField;
            }
            set {
                if ((this.PatientIdField.Equals(value) != true)) {
                    this.PatientIdField = value;
                    this.RaisePropertyChanged("PatientId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PatientName {
            get {
                return this.PatientNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PatientNameField, value) != true)) {
                    this.PatientNameField = value;
                    this.RaisePropertyChanged("PatientName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        Lab01WebRole.ServiceReference1.CompositeType GetDataUsingDataContract(Lab01WebRole.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<Lab01WebRole.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(Lab01WebRole.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/displayAll", ReplyAction="http://tempuri.org/IService1/displayAllResponse")]
        Lab01WebRole.ServiceReference1.Patient[] displayAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/displayAll", ReplyAction="http://tempuri.org/IService1/displayAllResponse")]
        System.Threading.Tasks.Task<Lab01WebRole.ServiceReference1.Patient[]> displayAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/createPatient", ReplyAction="http://tempuri.org/IService1/createPatientResponse")]
        void createPatient(Lab01WebRole.ServiceReference1.Patient newPatient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/createPatient", ReplyAction="http://tempuri.org/IService1/createPatientResponse")]
        System.Threading.Tasks.Task createPatientAsync(Lab01WebRole.ServiceReference1.Patient newPatient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/detailsPatient", ReplyAction="http://tempuri.org/IService1/detailsPatientResponse")]
        Lab01WebRole.ServiceReference1.Patient detailsPatient(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/detailsPatient", ReplyAction="http://tempuri.org/IService1/detailsPatientResponse")]
        System.Threading.Tasks.Task<Lab01WebRole.ServiceReference1.Patient> detailsPatientAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/editPatient", ReplyAction="http://tempuri.org/IService1/editPatientResponse")]
        void editPatient(Lab01WebRole.ServiceReference1.Patient newPatient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/editPatient", ReplyAction="http://tempuri.org/IService1/editPatientResponse")]
        System.Threading.Tasks.Task editPatientAsync(Lab01WebRole.ServiceReference1.Patient newPatient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/deletePatient", ReplyAction="http://tempuri.org/IService1/deletePatientResponse")]
        void deletePatient(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/deletePatient", ReplyAction="http://tempuri.org/IService1/deletePatientResponse")]
        System.Threading.Tasks.Task deletePatientAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Lab01WebRole.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Lab01WebRole.ServiceReference1.IService1>, Lab01WebRole.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public Lab01WebRole.ServiceReference1.CompositeType GetDataUsingDataContract(Lab01WebRole.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Lab01WebRole.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(Lab01WebRole.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public Lab01WebRole.ServiceReference1.Patient[] displayAll() {
            return base.Channel.displayAll();
        }
        
        public System.Threading.Tasks.Task<Lab01WebRole.ServiceReference1.Patient[]> displayAllAsync() {
            return base.Channel.displayAllAsync();
        }
        
        public void createPatient(Lab01WebRole.ServiceReference1.Patient newPatient) {
            base.Channel.createPatient(newPatient);
        }
        
        public System.Threading.Tasks.Task createPatientAsync(Lab01WebRole.ServiceReference1.Patient newPatient) {
            return base.Channel.createPatientAsync(newPatient);
        }
        
        public Lab01WebRole.ServiceReference1.Patient detailsPatient(int id) {
            return base.Channel.detailsPatient(id);
        }
        
        public System.Threading.Tasks.Task<Lab01WebRole.ServiceReference1.Patient> detailsPatientAsync(int id) {
            return base.Channel.detailsPatientAsync(id);
        }
        
        public void editPatient(Lab01WebRole.ServiceReference1.Patient newPatient) {
            base.Channel.editPatient(newPatient);
        }
        
        public System.Threading.Tasks.Task editPatientAsync(Lab01WebRole.ServiceReference1.Patient newPatient) {
            return base.Channel.editPatientAsync(newPatient);
        }
        
        public void deletePatient(int id) {
            base.Channel.deletePatient(id);
        }
        
        public System.Threading.Tasks.Task deletePatientAsync(int id) {
            return base.Channel.deletePatientAsync(id);
        }
    }
}