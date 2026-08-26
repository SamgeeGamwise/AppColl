using AppColl.Workspaces;

namespace AppColl.Services
{
    public class BroadbandService(BroadbandWorkspaceStore broadbandWorkspaceStore)
    {

        private readonly BroadbandWorkspaceStore _broadbandWorkspaceStore = broadbandWorkspaceStore;


    }
}
