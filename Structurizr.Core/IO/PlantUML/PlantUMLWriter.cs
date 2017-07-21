using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Structurizr.IO.PlantUML
{

    /// <summary>
    ///  A simple PlantUML writer that outputs diagram definitions that can be copy-pasted
    /// into http://plantuml.com/plantuml/ ... it supports enterprise context, system context,
    /// container, component and dynamic diagrams.
    /// 
    /// Note: This won't work if you have two elements named the same on a diagram.
    /// </summary>
    public class PlantUMLWriter : IWorkspaceWriter
    {

        public void Write(Workspace workspace, TextWriter writer)
        {
            if (workspace != null && writer != null) {
                workspace.Views.EnterpriseContextViews.ForEach(v => Write(v, writer));
                workspace.Views.SystemContextViews.ForEach(v => Write(v, writer));
                workspace.Views.ContainerViews.ForEach(v => Write(v, writer));
                workspace.Views.ComponentViews.ForEach(v => Write(v, writer));
                workspace.Views.DynamicViews.ForEach(v => Write(v, writer));
            }
        }

        public void Write(View view, TextWriter writer)
        {
            if (view != null && writer != null)
            {
                if (view is EnterpriseContextView)
                {
                    Write((EnterpriseContextView) view, writer);
                }
                else if (view is SystemContextView)
                {
                    Write((SystemContextView) view, writer);
                }
                else if (view is ContainerView)
                {
                    Write((ContainerView)view, writer);
                }
                else if (view is ComponentView)
                {
                    Write((ComponentView)view, writer);
                }
                else if (view is DynamicView)
                {
                    Write((DynamicView)view, writer);
                }
            }
        }

        private void Write(EnterpriseContextView view, TextWriter writer)
        {
            try
            {
                WriteHeader(view, writer);

                view.Elements
                    .Select(ev => ev.Element)
                    .Where(e => e is Person && ((Person)e).Location == Location.External)
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, false));

                view.Elements
                    .Select(ev => ev.Element)
                    .Where(e => e is SoftwareSystem && ((SoftwareSystem)e).Location == Location.External)
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, false));

                writer.WriteLine("package " + NameOf(view.Model.Enterprise.Name) + " {");

                view.Elements
                    .Select(ev => ev.Element)
                    .Where(e => e is Person && ((Person)e).Location == Location.Internal)
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, true));

                view.Elements
                    .Select(ev => ev.Element)
                    .Where(e => e is SoftwareSystem && ((SoftwareSystem)e).Location == Location.Internal)
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, true));

                    writer.WriteLine("}");

                Write(view.Relationships, writer);

                WriteFooter(writer);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void Write(SystemContextView view, TextWriter writer)
        {
            try
            {
                WriteHeader(view, writer);

                view.Elements
                    .Select(ev => ev.Element)
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, false));
                Write(view.Relationships, writer);

                writer.WriteLine("@enduml");
                writer.WriteLine("");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void Write(ContainerView view, TextWriter writer)
        {
            try
            {
                WriteHeader(view, writer);

                view.Elements
                    .Select(ev => ev.Element)
                    .Where(e => !(e is Container))
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, false));

                writer.WriteLine("package " + NameOf(view.SoftwareSystem) + " {");

                view.Elements
                    .Select(ev => ev.Element)
                    .Where(e => e is Container)
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, true));

                writer.WriteLine("}");

                Write(view.Relationships, writer);

                WriteFooter(writer);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void Write(ComponentView view, TextWriter writer)
        {
            try
            {
                WriteHeader(view, writer);

                view.Elements
                    .Select(ev => ev.Element)
                    .Where(e => !(e is Component))
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, false));

                writer.WriteLine("package " + NameOf(view.Container) + " {");

                view.Elements
                    .Select(ev => ev.Element)
                    .Where(e => e is Component)
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, true));

                writer.WriteLine("}");

                Write(view.Relationships, writer);

                WriteFooter(writer);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void Write(DynamicView view, TextWriter writer)
        {
            try
            {
                WriteHeader(view, writer);

                view.Elements
                    .Select(ev => ev.Element)
                    .OrderBy(e => e.Name).ToList()
                    .ForEach(e => Write(e, writer, false));

                view.Relationships
                    .OrderBy(rv => rv.Order).ToList()
                    .ForEach(r =>
                        writer.WriteLine(
                                String.Format("{0} -> {1} : {2}",
                                        r.Relationship.Source.Id,
                                        r.Relationship.Destination.Id,
                                        HasValue(r.Description) ? r.Description : HasValue(r.Relationship.Description) ? r.Relationship.Description : ""
                                )
                        ));

                WriteFooter(writer);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void Write(Element element, TextWriter writer, bool indent)
        {
            try
            {
                writer.WriteLine(
                        String.Format("{0}{1} \"{2}\" <<{3}>> as {4}",
                                indent ? "  " : "",
                                element is Person ? "actor" : "component",
                                element.Name,
                                TypeOf(element),
                                element.Id
                        )
                );
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void Write(HashSet<RelationshipView> relationships, TextWriter writer)
        {
            relationships
                    .Select(rv => rv.Relationship)
                    .OrderBy(r => r.Source.Name + r.Destination.Name).ToList()
                    .ForEach(r => Write(r, writer));
        }

        private void Write(Relationship relationship, TextWriter writer)
        {
            try
            {
                writer.WriteLine(
                        String.Format("{0} ..> {1} {2}{3}",
                                relationship.Source.Id,
                                relationship.Destination.Id,
                                HasValue(relationship.Description) ? ": " + relationship.Description : "",
                                HasValue(relationship.Technology) ? " <<" + relationship.Technology + ">>" : ""
                        )
                );
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private string NameOf(Element e)
        {
            return NameOf(e.Name);
        }

        private string NameOf(string s)
        {
            if (s != null)
            {
                return s.Replace(" ", "")
                        .Replace("-", "");
            }
            else {
                return "";
            }
        }

        private string TypeOf(Element e)
        {
            if (e is SoftwareSystem) {
                return "Software System";
            } else if (e is Component) {
                Component component = (Component)e;
                return HasValue(component.Technology) ? component.Technology : "Component";
            } else {
                return e.GetType().Name;
            }
        }

        private bool HasValue(string s)
        {
            return s != null && s.Trim().Length > 0;
        }

        private void WriteHeader(View view, TextWriter writer)
        {
            writer.Write("@startuml");
            writer.Write(Environment.NewLine);

            writer.Write("title " + view.Name);
            writer.Write(Environment.NewLine);
    
            if (!String.IsNullOrEmpty(view.Description))
            {
                writer.Write("caption " + view.Description);
                writer.Write(Environment.NewLine);
            }
        }

        private void WriteFooter(TextWriter writer)
        {
            writer.Write("@enduml");
            writer.Write(Environment.NewLine);
            writer.Write(Environment.NewLine);
        }

    }

}