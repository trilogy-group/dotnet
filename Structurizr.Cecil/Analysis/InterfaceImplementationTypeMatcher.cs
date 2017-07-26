using Mono.Cecil;

using Structurizr.Cecil;

namespace Structurizr.Analysis
{
    public class InterfaceImplementationTypeMatcher : ITypeMatcher
    {
        public TypeDefinition InterfaceType { get; private set; }
        public string Description { get; private set; }
        public string Technology { get; private set; }

        public InterfaceImplementationTypeMatcher(TypeDefinition interfaceType,
            string description,
            string technology)
        {
            this.InterfaceType = interfaceType;
            this.Description = description;
            this.Technology = technology;
        }

        /// <inheritdoc />
        public bool Matches(TypeDefinition type)
        {
            return this.InterfaceType.IsAssignableFrom(type);
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
