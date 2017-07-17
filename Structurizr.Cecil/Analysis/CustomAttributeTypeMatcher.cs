using System.Linq;

using Mono.Cecil;

namespace Structurizr.Analysis
{
    public class CustomAttributeTypeMatcher : ITypeMatcher
    {
        public TypeDefinition AttributeType { get; private set; }
        public string Description { get; private set; }
        public string Technology { get; private set; }

        public CustomAttributeTypeMatcher(TypeDefinition attributeType,
            string description,
            string technology)
        {
            this.AttributeType = attributeType;
            this.Description = description;
            this.Technology = technology;
        }

        /// <inheritdoc />
        public bool Matches(TypeDefinition type)
        {
            return type.CustomAttributes.Any(ca => ca.AttributeType.Resolve().MetadataToken == this.AttributeType.MetadataToken);
        }

        /// <inheritdoc />
        public string GetDescription()
        {
            return this.Description;
        }

        /// <inheritdoc />
        public string GetTechnology()
        {
            return this.Technology;
        }
    }
}
