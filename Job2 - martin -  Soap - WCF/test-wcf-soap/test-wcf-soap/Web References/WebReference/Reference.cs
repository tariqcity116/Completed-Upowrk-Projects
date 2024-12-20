﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace test_wcf_soap.WebReference {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SoapSampleServiceSoap", Namespace="http://webservice.telemetry.udo.fors.ru/")]
    public partial class SoapSampleService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private Security securityValueField;
        
        private System.Threading.SendOrPostCallback storeTelemetryListOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SoapSampleService() {
            this.Url = global::test_wcf_soap.Properties.Settings.Default.test_wcf_soap_WebReference_SoapSampleService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public Security SecurityValue {
            get {
                return this.securityValueField;
            }
            set {
                this.securityValueField = value;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event storeTelemetryListCompletedEventHandler storeTelemetryListCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityValue", Direction=System.Web.Services.Protocols.SoapHeaderDirection.InOut)]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://webservice.telemetry.udo.fors.ru/storeTelemetryList", RequestNamespace="http://webservice.telemetry.udo.fors.ru/", ResponseNamespace="http://webservice.telemetry.udo.fors.ru/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string storeTelemetryList([System.Xml.Serialization.XmlElementAttribute("telemetryWithDetails", Namespace="", IsNullable=true)] TelemetryWithDetails[] telemetryWithDetails) {
            object[] results = this.Invoke("storeTelemetryList", new object[] {
                        telemetryWithDetails});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void storeTelemetryListAsync(TelemetryWithDetails[] telemetryWithDetails) {
            this.storeTelemetryListAsync(telemetryWithDetails, null);
        }
        
        /// <remarks/>
        public void storeTelemetryListAsync(TelemetryWithDetails[] telemetryWithDetails, object userState) {
            if ((this.storeTelemetryListOperationCompleted == null)) {
                this.storeTelemetryListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnstoreTelemetryListOperationCompleted);
            }
            this.InvokeAsync("storeTelemetryList", new object[] {
                        telemetryWithDetails}, this.storeTelemetryListOperationCompleted, userState);
        }
        
        private void OnstoreTelemetryListOperationCompleted(object arg) {
            if ((this.storeTelemetryListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.storeTelemetryListCompleted(this, new storeTelemetryListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "", IsNullable=false)]
    public partial class Security : System.Web.Services.Protocols.SoapHeader {
        
        private UsernameToken usernameTokenField;
        
        private string mustUnderstandField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public UsernameToken UsernameToken {
            get {
                return this.usernameTokenField;
            }
            set {
                this.usernameTokenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MustUnderstand {
            get {
                return this.mustUnderstandField;
            }
            set {
                this.mustUnderstandField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "")]
    public partial class UsernameToken {
        
        private string usernameField;
        
        private string passwordField;
        
        /// <remarks/>
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
        
        /// <remarks/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TelemetryDetails {
        
        private string sensorCodeField;
        
        private double valueField;
        
        /// <remarks/>
        public string sensorCode {
            get {
                return this.sensorCodeField;
            }
            set {
                this.sensorCodeField = value;
            }
        }
        
        /// <remarks/>
        public double value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Telemetry {
        
        private double coordXField;
        
        private double coordYField;
        
        private System.DateTime dateField;
        
        private int glonassField;
        
        private string gpsCodeField;
        
        private int speedField;
        
        /// <remarks/>
        public double coordX {
            get {
                return this.coordXField;
            }
            set {
                this.coordXField = value;
            }
        }
        
        /// <remarks/>
        public double coordY {
            get {
                return this.coordYField;
            }
            set {
                this.coordYField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        public int glonass {
            get {
                return this.glonassField;
            }
            set {
                this.glonassField = value;
            }
        }
        
        /// <remarks/>
        public string gpsCode {
            get {
                return this.gpsCodeField;
            }
            set {
                this.gpsCodeField = value;
            }
        }
        
        /// <remarks/>
        public int speed {
            get {
                return this.speedField;
            }
            set {
                this.speedField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TelemetryWithDetails {
        
        private Telemetry telemetryField;
        
        private TelemetryDetails[] telemetryDetailsField;
        
        /// <remarks/>
        public Telemetry telemetry {
            get {
                return this.telemetryField;
            }
            set {
                this.telemetryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("telemetryDetails")]
        public TelemetryDetails[] telemetryDetails {
            get {
                return this.telemetryDetailsField;
            }
            set {
                this.telemetryDetailsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void storeTelemetryListCompletedEventHandler(object sender, storeTelemetryListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class storeTelemetryListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal storeTelemetryListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591