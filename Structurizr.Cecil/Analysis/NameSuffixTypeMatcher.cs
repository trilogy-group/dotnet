using Mono.Cecil;

namespace Structurizr.Analysis
{
    public class NameSuffixTypeMatcher : ITypeMatcher
    {
        public string Suffix { get; private set; }
        public string Description { get; private set; }
        public string Technology { get; private set; }

        public NameSuffixTypeMatcher(string suffix, string description, string technology)
        {
            this.Suffix = suffix;
            this.Description = description;
            this.Technology = technology;
        }

        /// <inheritdoc />
        public bool Matches(TypeDefinition type)
        {
            return type.Name.EndsWith(this.Suffix);
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
