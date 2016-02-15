using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Logger.Abstract;
using Mvc4App.Models;
using System.Threading.Tasks;

namespace Mvc4App.Controllers
{
    public class CalculController : Controller
    {
        private IRepository _repository;
        public CalculController(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Отображает основную форму для вычислений
        /// </summary>
        /// <returns></returns>
        public ActionResult CalculationForm()
        {
            var model = new CalculViewModel();
            return View(model);
        }

        /// <summary>
        /// Вычисляет и отображает результат
        /// в другом потоке пишет результат в лог
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CalculationForm(CalculViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Делаем расчет и добавляем результат в модель
                var calculService = new CalculService();
                model = calculService.AddResult(model);

                //Формируем запись для лога и пишем в хранилище
                var loggerService = new LoggerService(_repository);
                loggerService.AddRecord(model);
            }

            return View(model);
        }

    }
}
