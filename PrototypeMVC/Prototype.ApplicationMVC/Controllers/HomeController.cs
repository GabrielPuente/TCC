using Microsoft.AspNetCore.Mvc;
using Prototype.ServiceMVC.Interfaces;
using System.Threading.Tasks;

namespace Prototype.ApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInternalApiService _internalApiService;

        public HomeController(IInternalApiService internalApiService)
        {
            _internalApiService = internalApiService;
        }

        /// <summary>
        /// Endpoint principal, ao iniciar a aplicação é aqui o primeiro endpoint a cair.
        /// </summary>
        /// <returns>Retorna a view principal com as informacoes coletadas</returns>
        public async Task<IActionResult> Index()
        {
            var viewModel = await _internalApiService.Index();
            return View(viewModel); // Retorna a view com os dados
        }

        public async Task<IActionResult> Tips()
        {
            var viewModel = await _internalApiService.Tips();
            return View(viewModel); // Retorna a view com os dados
        }

        public async Task<IActionResult> Gallery()
        {
            var viewModel = await  _internalApiService.Gallery();
            return View(viewModel); // Retorna a view com os dados
        }
    }
}
