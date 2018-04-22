using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenWEBSERVER
{
    public class Efemerides
    {


        /// <comentarios/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", IsNullable = false)]
        public partial class @string
        {

            private stringEFEMERIDES eFEMERIDESField;

            /// <comentarios/>
            public stringEFEMERIDES EFEMERIDES
            {
                get
                {
                    return this.eFEMERIDESField;
                }
                set
                {
                    this.eFEMERIDESField = value;
                }
            }
        }

        /// <comentarios/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/")]
        public partial class stringEFEMERIDES
        {

            private stringEFEMERIDESEFEMERIDE_SOL eFEMERIDE_SOLField;

            private stringEFEMERIDESEFEMERIDE_LUNA eFEMERIDE_LUNAField;

            private stringEFEMERIDESFASELUNAR fASELUNARField;

            /// <comentarios/>
            public stringEFEMERIDESEFEMERIDE_SOL EFEMERIDE_SOL
            {
                get
                {
                    return this.eFEMERIDE_SOLField;
                }
                set
                {
                    this.eFEMERIDE_SOLField = value;
                }
            }

            /// <comentarios/>
            public stringEFEMERIDESEFEMERIDE_LUNA EFEMERIDE_LUNA
            {
                get
                {
                    return this.eFEMERIDE_LUNAField;
                }
                set
                {
                    this.eFEMERIDE_LUNAField = value;
                }
            }

            /// <comentarios/>
            public stringEFEMERIDESFASELUNAR FASELUNAR
            {
                get
                {
                    return this.fASELUNARField;
                }
                set
                {
                    this.fASELUNARField = value;
                }
            }
        }

        /// <comentarios/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/")]
        public partial class stringEFEMERIDESEFEMERIDE_SOL
        {

            private string sALEField;

            private string sEPONEField;

            /// <comentarios/>
            public string SALE
            {
                get
                {
                    return this.sALEField;
                }
                set
                {
                    this.sALEField = value;
                }
            }

            /// <comentarios/>
            public string SEPONE
            {
                get
                {
                    return this.sEPONEField;
                }
                set
                {
                    this.sEPONEField = value;
                }
            }
        }

        /// <comentarios/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/")]
        public partial class stringEFEMERIDESEFEMERIDE_LUNA
        {

            private string sALEField;

            private string sEPONEField;

            /// <comentarios/>
            public string SALE
            {
                get
                {
                    return this.sALEField;
                }
                set
                {
                    this.sALEField = value;
                }
            }

            /// <comentarios/>
            public string SEPONE
            {
                get
                {
                    return this.sEPONEField;
                }
                set
                {
                    this.sEPONEField = value;
                }
            }
        }

        /// <comentarios/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/")]
        public partial class stringEFEMERIDESFASELUNAR
        {

            private byte idField;

            private string valueField;

            /// <comentarios/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            /// <comentarios/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string Value
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



    }
}
