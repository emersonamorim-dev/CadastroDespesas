
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CadastroDespesas.Services;
using CadastroDespesas.Models;
using CadastroDespesas.DTOs;

namespace CadastroDespesas.Controllers
{
    public class DespesasController : Controller
    {
        private readonly ILogger<DespesasController> _logger;
        private readonly IDespesasService _despesasService;

        public DespesasController(ILogger<DespesasController> logger,
            IDespesasService despesasService)
        {
            _logger = logger;
            _despesasService = despesasService;
        }

        public async Task <IActionResult> Index()
        {
            var listDespesasDTO = new ListDespesasDTO();

            listDespesasDTO.Items = await _despesasService.FindBy(listDespesasDTO.StartDate, listDespesasDTO.EndDate);

            return View(listDespesasDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ListDespesasDTO listDespesasDTO)
        {
            try
            {
                listDespesasDTO.Items = await _despesasService.FindBy(listDespesasDTO.StartDate, listDespesasDTO.EndDate);

                return View(listDespesasDTO);
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("CustomError", ex.Message);
                return View(listDespesasDTO);
            }

        }

        public async Task<IActionResult> Create()
        {
            var createDespesasDTO = new CreateDespesasDTO();

            return View(createDespesasDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDespesasDTO createDespesasDTO)
        {
            try
            {
                await _despesasService.Create(createDespesasDTO);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("CustomError", ex.Message);
                return View(createDespesasDTO);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
