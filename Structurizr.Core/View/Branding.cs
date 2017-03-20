using System.Runtime.Serialization;

namespace Structurizr
{

    [DataContract]
    public class Branding
    {

        [DataMember(Name = "font", EmitDefaultValue = false)]
        public Font Font;

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
