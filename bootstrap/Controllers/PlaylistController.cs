using System.Web.Mvc;
using bootstrap.Models;

namespace bootstrap.Controllers
{
    public class PlaylistController : Controller
    {
        //
        // GET: /Playlist/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Display(string id)
		{
			if (string.IsNullOrEmpty(id))
				id = "09bb70dd-31fd-4ac7-a7c0-af82efa10513";

			var model = new PlaylistRepository("http://localhost:9200", "playlist").Get(id);
			
			return View(model);
		}
    }
}
