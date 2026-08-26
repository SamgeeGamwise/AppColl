using AppColl.Models;

namespace AppColl.Workspaces
{
    public interface IWorkspaceStore<T, U>
    {
        public int AddWorkspace(T[] records);
        public U GetWorkspace(int workspaceId);
        public void RemoveWorkspace(int workspaceId);
    }
}
