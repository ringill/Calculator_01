using Common;
using Logger.Abstract;
using Logger.Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    /// <summary>
    /// Класс, отвечающий за взаимодействие с хранилищем логов
    /// </summary>
    public class LoggerService
    {
        private IRepository _repository;

        public LoggerService(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Сохраняет информацию  в лог
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public Task<bool> SaveToLog(CalculModel arguments)
        {
            //Преобразовывает выражение в строку
            //и записывает информацию в хранилище в отдельном потоке
            return Task.Factory.StartNew(() => _repository.Add(OperList.CalculString(arguments.Arg1.ToString(),
                arguments.Arg1.ToString(), arguments.Result.ToString(), arguments.OperationName)));
        }

        /// <summary>
        /// Получает из хранилища последние 5 записей
        /// и возвращает их в виде массива строк
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public async Task<string[]> GetString5(int n = 5)
        {
            //Получаем данные из хранилища
            //Преобразовываем их в массив строк
            return await Task.Run(
                () => _repository.Get5(n)
                    .Select(r => OperList.HistoryString(r.When, r.What))
                    .ToArray<string>());
        }
    }
}
