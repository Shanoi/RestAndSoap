﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientGUI.JCDLibrary {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Station", Namespace="http://schemas.datacontract.org/2004/07/JCDLibrary")]
    [System.SerializableAttribute()]
    public partial class Station : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Available_bike_standsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Available_bikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
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
        public int Available_bike_stands {
            get {
                return this.Available_bike_standsField;
            }
            set {
                if ((this.Available_bike_standsField.Equals(value) != true)) {
                    this.Available_bike_standsField = value;
                    this.RaisePropertyChanged("Available_bike_stands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Available_bikes {
            get {
                return this.Available_bikesField;
            }
            set {
                if ((this.Available_bikesField.Equals(value) != true)) {
                    this.Available_bikesField = value;
                    this.RaisePropertyChanged("Available_bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JCDLibrary.IVelibsRetriever")]
    public interface IVelibsRetriever {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getCities", ReplyAction="http://tempuri.org/IVelibsRetriever/getCitiesResponse")]
        string[] getCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getCities", ReplyAction="http://tempuri.org/IVelibsRetriever/getCitiesResponse")]
        System.Threading.Tasks.Task<string[]> getCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getDataFromCity", ReplyAction="http://tempuri.org/IVelibsRetriever/getDataFromCityResponse")]
        string getDataFromCity(string city, string station, string fidelity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getDataFromCity", ReplyAction="http://tempuri.org/IVelibsRetriever/getDataFromCityResponse")]
        System.Threading.Tasks.Task<string> getDataFromCityAsync(string city, string station, string fidelity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getListStationFromCity", ReplyAction="http://tempuri.org/IVelibsRetriever/getListStationFromCityResponse")]
        ClientGUI.JCDLibrary.Station[] getListStationFromCity(string city, string station, string fidelity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getListStationFromCity", ReplyAction="http://tempuri.org/IVelibsRetriever/getListStationFromCityResponse")]
        System.Threading.Tasks.Task<ClientGUI.JCDLibrary.Station[]> getListStationFromCityAsync(string city, string station, string fidelity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getFidelityLevels", ReplyAction="http://tempuri.org/IVelibsRetriever/getFidelityLevelsResponse")]
        string[] getFidelityLevels();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getFidelityLevels", ReplyAction="http://tempuri.org/IVelibsRetriever/getFidelityLevelsResponse")]
        System.Threading.Tasks.Task<string[]> getFidelityLevelsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getLastUpdate", ReplyAction="http://tempuri.org/IVelibsRetriever/getLastUpdateResponse")]
        System.DateTime getLastUpdate(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibsRetriever/getLastUpdate", ReplyAction="http://tempuri.org/IVelibsRetriever/getLastUpdateResponse")]
        System.Threading.Tasks.Task<System.DateTime> getLastUpdateAsync(string city);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibsRetrieverChannel : ClientGUI.JCDLibrary.IVelibsRetriever, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VelibsRetrieverClient : System.ServiceModel.ClientBase<ClientGUI.JCDLibrary.IVelibsRetriever>, ClientGUI.JCDLibrary.IVelibsRetriever {
        
        public VelibsRetrieverClient() {
        }
        
        public VelibsRetrieverClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VelibsRetrieverClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibsRetrieverClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibsRetrieverClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] getCities() {
            return base.Channel.getCities();
        }
        
        public System.Threading.Tasks.Task<string[]> getCitiesAsync() {
            return base.Channel.getCitiesAsync();
        }
        
        public string getDataFromCity(string city, string station, string fidelity) {
            return base.Channel.getDataFromCity(city, station, fidelity);
        }
        
        public System.Threading.Tasks.Task<string> getDataFromCityAsync(string city, string station, string fidelity) {
            return base.Channel.getDataFromCityAsync(city, station, fidelity);
        }
        
        public ClientGUI.JCDLibrary.Station[] getListStationFromCity(string city, string station, string fidelity) {
            return base.Channel.getListStationFromCity(city, station, fidelity);
        }
        
        public System.Threading.Tasks.Task<ClientGUI.JCDLibrary.Station[]> getListStationFromCityAsync(string city, string station, string fidelity) {
            return base.Channel.getListStationFromCityAsync(city, station, fidelity);
        }
        
        public string[] getFidelityLevels() {
            return base.Channel.getFidelityLevels();
        }
        
        public System.Threading.Tasks.Task<string[]> getFidelityLevelsAsync() {
            return base.Channel.getFidelityLevelsAsync();
        }
        
        public System.DateTime getLastUpdate(string city) {
            return base.Channel.getLastUpdate(city);
        }
        
        public System.Threading.Tasks.Task<System.DateTime> getLastUpdateAsync(string city) {
            return base.Channel.getLastUpdateAsync(city);
        }
    }
}
