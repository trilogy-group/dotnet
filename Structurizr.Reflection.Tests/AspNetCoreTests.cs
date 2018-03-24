using System;
using System.Linq;
using Structurizr.Analysis;
using Structurizr.Reflection.Tests.Controllers;
using Xunit;

namespace Structurizr.Reflection.Tests
{
    public class AspNetCoreTests
    {
        [Fact]
        public void Reflection_Success_WithAspNetCoreAssembly()
        {
            // arrange
            Workspace workspace = new Workspace("Dummy ASP.NET Core WebApp", "A web application using .NET Core");
            Model model = workspace.Model;
            SoftwareSystem contosoUniversity = model.AddSoftwareSystem("Some Software System", "Dummy Description");
            Container webApplication = contosoUniversity.AddContainer("Some Container", "Dummy Description", "Microsoft ASP.NET Core MVC");
            Type controllerType = typeof(Microsoft.AspNetCore.Mvc.Controller);
            TypeMatcherComponentFinderStrategy typeMatcherComponentFinderStrategy = new TypeMatcherComponentFinderStrategy(
                new ExtendsClassTypeMatcher(controllerType, "ASP.NET Core MVC Controller", ".NET Core")
            );


            // act
            ComponentFinder componentFinder = new ComponentFinder(
                webApplication,
                "Structurizr.Reflection.Tests.Controllers",
                typeMatcherComponentFinderStrategy
            );
            var foundComponents = componentFinder.FindComponents(); // must successfully find controller in 'Controllers/ValuesController.cs'


            // assert
            Assert.Single(foundComponents);
            Assert.Equal(nameof(StubController), foundComponents.First().Name);
        }
    }
}
