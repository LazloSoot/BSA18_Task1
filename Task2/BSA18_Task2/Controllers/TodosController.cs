using BSA18_Task2.Services;
using System.Web.Mvc;

namespace BSA18_Task2.Controllers
{
    public class TodosController : Controller
    {
        private readonly UserDataService userDataService;

        public TodosController()
        {
            userDataService = UserDataService.Instance;
        }

        // Todos/
        public ActionResult Index()
        {
            return View();
        }

        // GET: Todos/GetTodo/{id}
        public ActionResult GetTodo(int id)
        {
            var todo = userDataService.GetTodo(id);
            return View(todo);
        }

        //GET: Todos/GetAllTodos
        public ActionResult GetAllTodos()
        {
            var todos = userDataService.GetAllTodos();
            return View(todos);
        }

        //POST: Todos/GetCompletedUserTodos
        [HttpPost]
        public ActionResult GetCompletedUserTodos(int Id)
        {
            if (Id < 1)
            {
                ModelState.AddModelError("Id", "Id value must be greater than zero");
                return View("Index");
            }
            var todos = userDataService.GetCompletedUserTodos(Id);
            return View(todos);
        }

        //POST: Todos/GetUserTodos
        [HttpPost]
        public ActionResult GetUserTodos(int Id)
        {
            if (Id < 1)
            {
                ModelState.AddModelError("Id", "Id value must be greater than zero");
                return View("Index");
            }
            var todos = userDataService.GetUserTodos(Id);
            return View(todos);
        }
    }
}