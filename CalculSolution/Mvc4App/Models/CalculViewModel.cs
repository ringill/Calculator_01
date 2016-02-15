using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace Mvc4App.Models
{
    public class CalculViewModel
    {

        public string[] Operators { get; set; }

        public string selectedOperator { get; set; }

        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Недопустимое число")]
        [Required(ErrorMessage = "Поле должно содержать цифры")]
        [Display(Name = "Первый аргумент:")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Агрумент должен быть целым числом")]
        public string Argument1 { get; set; }

        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Недопустимое число")]
        [Required(ErrorMessage = "Поле должно содержать цифры (кроме 0)")]
        [Display(Name = "Второй аргумент:")]
        [RegularExpression(@"^[1-9]+$", ErrorMessage = "Агрумент должен быть целым числом (кроме нуля)")]
        public string Argument2 { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Результат:")]
        public string Result { get; set; }

        /// <summary>
        /// Конструктор представления.
        /// </summary>
        public CalculViewModel()
        {
            //Преобразует все операции кроме последней (конкретно +, -, *, / ; "равно" - последнияя операция - не трогает)
            //и передает в виде массива строк в форму
            Operators = OperList.Opers.Take(OperList.Opers.Length - 1).Select(o => o.Name).ToArray();
        }
    }
}