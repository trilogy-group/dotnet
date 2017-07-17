using Mono.Cecil;

namespace Structurizr.Analysis
{
    public interface ITypeMatcher
    {
        bool Matches(TypeDefinition type);

        string GetDescription();

        string GetTechnology();
    }
}
