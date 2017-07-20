using System;
using System.Runtime.Serialization;
using Structurizr.Util;

namespace Structurizr
{

    [DataContract]
    public sealed class Branding
    {

        [DataMember(Name = "font", EmitDefaultValue = false)]
        public Font Font;

        private string _logo;

        [DataMember(Name = "logo", EmitDefaultValue = false)]
        public string Logo
        {
            get { return _logo; }
            set
            {
                if (value != null && value.Trim().Length > 0)
                {
                    if (Url.IsUrl(value) || value.StartsWith("data:image/"))
                    {
                        _logo = value;
                    }
                    else {
                        throw new ArgumentException(value + " is not a valid URL.");
                    }
                }
            }
        }

        [DataMember(Name = "color1", EmitDefaultValue = false)]
        public ColorPair Color1;

        [DataMember(Name = "color2", EmitDefaultValue = false)]
        public ColorPair Color2;

        [DataMember(Name = "color3", EmitDefaultValue = false)]
        public ColorPair Color3;

        [DataMember(Name = "color4", EmitDefaultValue = false)]
        public ColorPair Color4;

        [DataMember(Name = "color5", EmitDefaultValue = false)]
        public ColorPair Color5;

    }

}
