using BSA18_Task2.Services;
using System.Web.Mvc;

namespace BSA18_Task2.Controllers
{
    public class PostsController : Controller
    {
        private readonly UserDataService userDataService;

        public PostsController()
        {
            userDataService = UserDataService.Instance;
        }

        // GET: Posts/
        public ActionResult Index()
        {
            return View();
        }

        // GET: Posts/{id}
        public ActionResult GetPost(int id)
        {
            var post = userDataService.GetPost(id);
            return View(post);
        }

        // POST: Posts/GetPostInfo/
        [HttpPost]
        public ActionResult GetPostInfo(int Id)
        {
            if (Id < 1)
            {
                ModelState.AddModelError("Id", "Id value must be greater than zero");
                return View("Index");
            }
            var postInfo = userDataService.GetPostInfo(Id);
            return View(postInfo);
        }

        // POST: Posts/GetUserPostsList/
        [HttpPost]
        public ActionResult GetUserPostsList(int Id)
        {
            if (Id < 1)
            {
                ModelState.AddModelError("Id", "Id value must be greater than zero");
                return View("Index");
            }
            var post = userDataService.GetUserPostsList(Id);
            return View(post);
        }
    }
}