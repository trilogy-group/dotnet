using Mono.Cecil;

using Structurizr.Cecil;

namespace Structurizr.Analysis
{
    public class ExtendsClassTypeMatcher : ITypeMatcher
    {
        public TypeDefinition ClassType { get; private set; }
        public string Description { get; private set; }
        public string Technology { get; private set; }

        public ExtendsClassTypeMatcher(TypeDefinition classType, string description, string technology)
        {
            this.ClassType = classType;
            this.Description = description;
            this.Technology = technology;
        }

        /// <inheritdoc />
        public bool Matches(TypeDefinition type)
        {
            return type.IsSubclassOf(this.ClassType);
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
