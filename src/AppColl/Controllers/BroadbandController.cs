using AppColl.Models;
using AppColl.Services;
using AppColl.Workspaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppColl.Controllers
{
    public class BroadbandController : Controller
    {
        private readonly ImportService _importService;
        private readonly BroadbandWorkspaceStore _workspaceStore;

        public BroadbandController(ImportService importService, BroadbandWorkspaceStore workspaceStore)
        {
            _importService = importService;
            _workspaceStore = workspaceStore;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var workspaceId = HttpContext.Session.GetInt32("BroadbandWorkspaceId");

            if (workspaceId != null && _workspaceStore.GetWorkspace(workspaceId.Value) != null)
            {
                return RedirectToAction(nameof(Results));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Results()
        {
            var (workspaceId, records) = await _importService.ImportBroadband();

            HttpContext.Session.SetInt32("BroadbandWorkspaceId", workspaceId);

            return View(records);
        }

        [HttpGet]
        public async Task<IActionResult> Clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
