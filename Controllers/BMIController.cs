using BMICalcWithJquery.Data;
using BMICalcWithJquery.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMICalcWithJquery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BMIController : Controller
    {
        private readonly BMIDbContext _context;

        public BMIController(BMIDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("calculate")]
        public async Task<IActionResult> Calculate([FromBody] BMICalculation model)
        {
            //if (model.Weight.HasValue && model.Height.HasValue)
            //{
            //    var bmi = model.Weight.Value / (model.Height.Value * model.Height.Value);
            //    return Json(bmi);
            //}
            //return Json(0);

            if (model.Weight.HasValue && model.Height.HasValue)
            {
                var bmiValue = model.Weight.Value / (model.Height.Value * model.Height.Value);

                var bmiEntity = new BMIEntity
                {
                    Weight = model.Weight.Value,
                    Height = model.Height.Value,
                    BMI = bmiValue
                };

                _context.BMIs.Add(bmiEntity);
                await _context.SaveChangesAsync();

                return Json(bmiValue);
            }
            return Json(0);
        }
    }
}
