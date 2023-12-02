using Microsoft.AspNetCore.Mvc;
using TheSchizoGamblers.Data;
using TheSchizoGamblers.Models;
using TheSchizoGamblers.Models.ViewModels;

namespace TheSchizoGamblers.Controllers
{
    public class GamblersController : Controller
    {
        private readonly GamblersContext gamblersContext;

        public GamblersController(GamblersContext gamblersContext)
        {
            this.gamblersContext = gamblersContext;
        }

        [HttpGet]
        public IActionResult Gamblers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Gamblers(GamblersViewModel addGamblerRequest)
        {
            //if (ModelState.IsValid)
            //{
            //    GamblersModel gambler = new GamblersModel()
            //    {
                    
            //    };
            //}
            //GamblersModel gambler = new GamblersModel()
            //{
            //    ID = Guid.NewGuid(),
            //    Username = addGamblerRequest.Username,
            //    Email = addGamblerRequest.Email,
            //    Password = addGamblerRequest.Password,
            //    DateOfBirth = addGamblerRequest.DateOfBirth
            //};
            //await gamblersContext.Gamblers.AddAsync(gambler);
            await gamblersContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
