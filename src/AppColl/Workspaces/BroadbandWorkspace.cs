using AppColl.Models;

namespace AppColl.Workspaces
{
    public class BroadbandWorkspace
    {
        public int Id { get; set; }
        public BroadbandRecord[] Records { get; set; } = [];
        public DateTime ImportedAt { get; set; }
    }
}
