using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using System.Xml;
using System.Xml.Serialization;

namespace AplikacjaGubisch
{

    // UWAGA: Wygenerowany kod może wymagać co najmniej programu .NET Framework 4.5 lub .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class TenonMachineXML
    {

        private TenonMachineXMLObiekt[] chipbreakerField;

        private TenonMachineXMLObiekt1[] tenonVisior1Field;

        private TenonMachineXMLObiekt2[] sawUnitField;

        private TenonMachineXMLObiekt3[] unloadStationField;

        private TenonMachineXMLObiekt4[] cleanTableField;

        private TenonMachineXMLObiekt5[] feedbeamRollersField;

        private TenonMachineXMLObiekt6[] spindle1Field;

        private TenonMachineXMLObiekt7[] spindle2Field;

        private TenonMachineXMLObiekt8[] spindle3Field;

        private TenonMachineXMLObiekt9[] grooveSpindleField;

        private TenonMachineXMLObiekt10[] guidensField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt[] Chipbreaker
        {
            get
            {
                return this.chipbreakerField;
            }
            set
            {
                this.chipbreakerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt1[] TenonVisior1
        {
            get
            {
                return this.tenonVisior1Field;
            }
            set
            {
                this.tenonVisior1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt2[] SawUnit
        {
            get
            {
                return this.sawUnitField;
            }
            set
            {
                this.sawUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt3[] UnloadStation
        {
            get
            {
                return this.unloadStationField;
            }
            set
            {
                this.unloadStationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt4[] CleanTable
        {
            get
            {
                return this.cleanTableField;
            }
            set
            {
                this.cleanTableField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt5[] FeedbeamRollers
        {
            get
            {
                return this.feedbeamRollersField;
            }
            set
            {
                this.feedbeamRollersField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt6[] Spindle1
        {
            get
            {
                return this.spindle1Field;
            }
            set
            {
                this.spindle1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt7[] Spindle2
        {
            get
            {
                return this.spindle2Field;
            }
            set
            {
                this.spindle2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt8[] Spindle3
        {
            get
            {
                return this.spindle3Field;
            }
            set
            {
                this.spindle3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt9[] GrooveSpindle
        {
            get
            {
                return this.grooveSpindleField;
            }
            set
            {
                this.grooveSpindleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("obiekt", IsNullable = false)]
        public TenonMachineXMLObiekt10[] Guidens
        {
            get
            {
                return this.guidensField;
            }
            set
            {
                this.guidensField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt1
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt2
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt3
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt4
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt5
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt6
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt7
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt8
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt9
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TenonMachineXMLObiekt10
    {

        private string blok_danychField;

        private string typ_danychField;

        private byte to_PLCField;

        private byte saveField;

        private byte messageField;

        private string komentarzField;

        /// <remarks/>
        public string blok_danych
        {
            get
            {
                return this.blok_danychField;
            }
            set
            {
                this.blok_danychField = value;
            }
        }

        /// <remarks/>
        public string typ_danych
        {
            get
            {
                return this.typ_danychField;
            }
            set
            {
                this.typ_danychField = value;
            }
        }

        /// <remarks/>
        public byte To_PLC
        {
            get
            {
                return this.to_PLCField;
            }
            set
            {
                this.to_PLCField = value;
            }
        }

        /// <remarks/>
        public byte Save
        {
            get
            {
                return this.saveField;
            }
            set
            {
                this.saveField = value;
            }
        }

        /// <remarks/>
        public byte Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        public string komentarz
        {
            get
            {
                return this.komentarzField;
            }
            set
            {
                this.komentarzField = value;
            }
        }
    }


}
