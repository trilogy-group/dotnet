using System.IO;

namespace Structurizr.IO
{

    public interface IWorkspaceWriter
    {

        void Write(Workspace workspace, TextWriter writer);

    }

}