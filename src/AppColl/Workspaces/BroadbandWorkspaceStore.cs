using AppColl.Models;

namespace AppColl.Workspaces
{
    public class BroadbandWorkspaceStore : IWorkspaceStore<BroadbandRecord, BroadbandWorkspace>
    {
        private readonly List<BroadbandWorkspace> _workspaces = [];
        private int _workspaceId = 1;

        public int AddWorkspace(BroadbandRecord[] records)
        {
            // Very insecure way to generate IDs, however, this is just a simple in-memory store for demonstration purposes.
            var workspaceId = _workspaceId++;

            _workspaces.Add(new BroadbandWorkspace
            {
                Id = workspaceId,
                Records = records,
                ImportedAt = DateTime.Now
            });

            return workspaceId;
        }

        public BroadbandWorkspace GetWorkspace(int workspaceId)
        {
            var workspace = _workspaces.FirstOrDefault(w => w.Id == workspaceId);

            if (workspace == null)
            {
                throw new ArgumentException("Workspace not found", nameof(workspaceId));
            }

            return workspace;
        }

        public void RemoveWorkspace(int workspaceId)
        {
            _workspaces.RemoveAll(w => w.Id == workspaceId);
        }
    }
}
