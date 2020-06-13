using System;

namespace Structurizr
{
    public sealed class Tags
    {

        public const string Element = "Element";
        public const string Relationship = "Relationship";

        public const string Person = "Person";
        public const string SoftwareSystem = "Software System";
        public const string Container = "Container";
        public const string Component = "Component";

        public const string Synchronous = "Synchronous";
        public const string Asynchronous = "Asynchronous";

        public const string DeploymentNode = "Deployment Node";
        public const string ContainerInstance = "Container Instance";
    }

    public sealed class Tag
    {
        public Tag(string name, string value)
        {
            Name = string.IsNullOrWhiteSpace(name ?? throw new ArgumentNullException(nameof(name))) ? throw new ArgumentException($"Parameter canot be empty string or whitespace", nameof(name)) : name.Trim();
            Value = value;
        }
        public string Name { get; }
        public string Value { get; }
        private string FullName => $"{Name}:{Value}";

        public override bool Equals(object obj) => string.Equals(FullName, (obj as Tag)?.FullName, StringComparison.OrdinalIgnoreCase);
        public override int GetHashCode() => FullName.GetHashCode();
        public override string ToString() => FullName;
    }
}
