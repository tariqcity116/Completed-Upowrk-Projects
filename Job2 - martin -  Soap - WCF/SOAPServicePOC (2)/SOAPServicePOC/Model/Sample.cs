
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Body
{

    private BodyStoreTelemetryList storeTelemetryListField;

    /// <remarks/>
    public BodyStoreTelemetryList storeTelemetryList
    {
        get
        {
            return this.storeTelemetryListField;
        }
        set
        {
            this.storeTelemetryListField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class BodyStoreTelemetryList
{

    private BodyStoreTelemetryListTelemetryWithDetails telemetryWithDetailsField;

    /// <remarks/>
    public BodyStoreTelemetryListTelemetryWithDetails telemetryWithDetails
    {
        get
        {
            return this.telemetryWithDetailsField;
        }
        set
        {
            this.telemetryWithDetailsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class BodyStoreTelemetryListTelemetryWithDetails
{

    private object telemetryField;

    private BodyStoreTelemetryListTelemetryWithDetailsTelemetryDetails[] telemetryDetailsField;

    /// <remarks/>
    public object telemetry
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
    [System.Xml.Serialization.XmlElementAttribute("telemetryDetails")]
    public BodyStoreTelemetryListTelemetryWithDetailsTelemetryDetails[] telemetryDetails
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

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class BodyStoreTelemetryListTelemetryWithDetailsTelemetryDetails
{

    private string sensorCodeField;

    private ushort valueField;

    /// <remarks/>
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
    public ushort value
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPServicePOC.Model
{
    public class Sample
    {
    }
}