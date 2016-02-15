using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Logger.Abstract;
using Common;

namespace Mvc4App.Models
{
    public class LoggerService
    {
        private IRepository repository;

        public LoggerService(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Записываем в лог в другом потоке
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> AddRecord(CalculViewModel model)
        {
            Task<bool> task = Task.Factory.StartNew(() => AddRecordAsync(model));
            return task;
        }

        /// <summary>
        /// Операция записи в лог
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddRecordAsync(CalculViewModel model)
        {
            //Пять секунд спокойствия
            //Task.Delay(5000);
            //Преобразуем операцию в строку лога и записываем в хранилище
            return repository.Add(OperList.CalculString(model.Argument1,
                model.Argument2, model.Result, model.selectedOperator));
        }
    }
}