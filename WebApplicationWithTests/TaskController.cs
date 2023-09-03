using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationWithTests
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly TaskManager _taskManager;

        public TaskController()
        {
            _taskManager = new TaskManager(); // Inicjalizacja managera zadań
        }

        // Akcja do wyświetlania listy zadań
        public IActionResult Index()
        {
            var tasks = _taskManager.GetTasks();
            return View(tasks);
        }

        // Akcja do tworzenia nowego zadania
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            _taskManager.AddTask(task);
            return RedirectToAction("Index");
        }

    }
}

