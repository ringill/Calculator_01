using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Logger.Abstract;
using Logger.Entities;

namespace Mvc4App.Controllers
{
    public class HistoryController : Controller
    {
        /// <summary>
        /// хранилище данных
        /// </summary>
        private IRepository _repository;

        public HistoryController(IRepository repsitory)
        {
            this._repository = repsitory;
        }

        /// <summary>
        /// Основная страничка истории
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get5()
        {
            //если false, то Partial фрагмент не встроится в представление
            //и данные НЕ будут подкачиваться из хранилища и отображаться
            bool model = false;
            return View(model);
        }

        /// <summary>
        /// Реакция на кнопку "Обновить"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Get5(bool model)
        {
            //если true, то Partial фрагмент встроится в представление
            //и данные БУДУТ подкачиваться из хранилища и отображаться
            model = true;
            return View(model);
        }

        /// <summary>
        /// Partial кусочек, который заполняется данными и встраивается в форму через AJAX
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Get5Partial()
        {
            var data = _repository.Get5();
            return PartialView(data);
        }
    }
}
