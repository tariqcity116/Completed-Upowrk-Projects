﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://webservice.telemetry.udo.fors.ru/", ConfigurationName="SoapSampleServiceSoap")]
public interface SoapSampleServiceSoap
{
    
    // CODEGEN: Generating message contract since message storeTelemetryListRequest has headers
    [System.ServiceModel.OperationContractAttribute(Action="http://webservice.telemetry.udo.fors.ru/storeTelemetryList", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute()]
    storeTelemetryListResponse storeTelemetryList(storeTelemetryListRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://webservice.telemetry.udo.fors.ru/storeTelemetryList", ReplyAction="*")]
    System.Threading.Tasks.Task<storeTelemetryListResponse> storeTelemetryListAsync(storeTelemetryListRequest request);
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
    "")]
public partial class Security
{
    
    private UsernameToken usernameTokenField;
    
    private string mustUnderstandField;
    
    private System.Xml.XmlAttribute[] anyAttrField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public UsernameToken UsernameToken
    {
        get
        {
            return this.usernameTokenField;
        }
        set
        {
            this.usernameTokenField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string MustUnderstand
    {
        get
        {
            return this.mustUnderstandField;
        }
        set
        {
            this.mustUnderstandField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAnyAttributeAttribute()]
    public System.Xml.XmlAttribute[] AnyAttr
    {
        get
        {
            return this.anyAttrField;
        }
        set
        {
            this.anyAttrField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
    "")]
public partial class UsernameToken
{
    
    private string usernameField;
    
    private string passwordField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public string Username
    {
        get
        {
            return this.usernameField;
        }
        set
        {
            this.usernameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public string Password
    {
        get
        {
            return this.passwordField;
        }
        set
        {
            this.passwordField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class TelemetryDetails
{
    
    private string sensorCodeField;
    
    private double valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public string sensorCode
    {
        get
        {
            return this.sensorCodeField;
        }
        set
        {
            this.sensorCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public double value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class Telemetry
{
    
    private double coordXField;
    
    private double coordYField;
    
    private System.DateTime dateField;
    
    private int glonassField;
    
    private string gpsCodeField;
    
    private int speedField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public double coordX
    {
        get
        {
            return this.coordXField;
        }
        set
        {
            this.coordXField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public double coordY
    {
        get
        {
            return this.coordYField;
        }
        set
        {
            this.coordYField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=2)]
    public System.DateTime date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=3)]
    public int glonass
    {
        get
        {
            return this.glonassField;
        }
        set
        {
            this.glonassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=4)]
    public string gpsCode
    {
        get
        {
            return this.gpsCodeField;
        }
        set
        {
            this.gpsCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=5)]
    public int speed
    {
        get
        {
            return this.speedField;
        }
        set
        {
            this.speedField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class TelemetryWithDetails
{
    
    private Telemetry telemetryField;
    
    private TelemetryDetails[] telemetryDetailsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public Telemetry telemetry
    {
        get
        {
            return this.telemetryField;
        }
        set
        {
            this.telemetryField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("telemetryDetails", Order=1)]
    public TelemetryDetails[] telemetryDetails
    {
        get
        {
            return this.telemetryDetailsField;
        }
        set
        {
            this.telemetryDetailsField = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(WrapperName="storeTelemetryList", WrapperNamespace="http://webservice.telemetry.udo.fors.ru/", IsWrapped=true)]
public partial class storeTelemetryListRequest
{
    
    [System.ServiceModel.MessageHeaderAttribute(Namespace="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "")]
    public Security Security;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
    [System.Xml.Serialization.XmlElementAttribute("telemetryWithDetails", Namespace="", IsNullable=true)]
    public TelemetryWithDetails[] telemetryWithDetails;
    
    public storeTelemetryListRequest()
    {
    }
    
    public storeTelemetryListRequest(Security Security, TelemetryWithDetails[] telemetryWithDetails)
    {
        this.Security = Security;
        this.telemetryWithDetails = telemetryWithDetails;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(WrapperName="storeTelemetryListResponse", WrapperNamespace="http://webservice.telemetry.udo.fors.ru/", IsWrapped=true)]
public partial class storeTelemetryListResponse
{
    
    [System.ServiceModel.MessageHeaderAttribute(Namespace="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" +
        "")]
    public Security Security;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://webservice.telemetry.udo.fors.ru/", Order=0)]
    public string storeTelemetryListResult;
    
    public storeTelemetryListResponse()
    {
    }
    
    public storeTelemetryListResponse(Security Security, string storeTelemetryListResult)
    {
        this.Security = Security;
        this.storeTelemetryListResult = storeTelemetryListResult;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface SoapSampleServiceSoapChannel : SoapSampleServiceSoap, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class SoapSampleServiceSoapClient : System.ServiceModel.ClientBase<SoapSampleServiceSoap>, SoapSampleServiceSoap
{
    
    public SoapSampleServiceSoapClient()
    {
    }
    
    public SoapSampleServiceSoapClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public SoapSampleServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SoapSampleServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public SoapSampleServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    storeTelemetryListResponse SoapSampleServiceSoap.storeTelemetryList(storeTelemetryListRequest request)
    {
        return base.Channel.storeTelemetryList(request);
    }
    
    public string storeTelemetryList(ref Security Security, TelemetryWithDetails[] telemetryWithDetails)
    {
        storeTelemetryListRequest inValue = new storeTelemetryListRequest();
        inValue.Security = Security;
        inValue.telemetryWithDetails = telemetryWithDetails;
        storeTelemetryListResponse retVal = ((SoapSampleServiceSoap)(this)).storeTelemetryList(inValue);
        Security = retVal.Security;
        return retVal.storeTelemetryListResult;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    System.Threading.Tasks.Task<storeTelemetryListResponse> SoapSampleServiceSoap.storeTelemetryListAsync(storeTelemetryListRequest request)
    {
        return base.Channel.storeTelemetryListAsync(request);
    }
    
    public System.Threading.Tasks.Task<storeTelemetryListResponse> storeTelemetryListAsync(Security Security, TelemetryWithDetails[] telemetryWithDetails)
    {
        storeTelemetryListRequest inValue = new storeTelemetryListRequest();
        inValue.Security = Security;
        inValue.telemetryWithDetails = telemetryWithDetails;
        return ((SoapSampleServiceSoap)(this)).storeTelemetryListAsync(inValue);
    }
}
