using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    /// <summary>
    /// Моделька, для хранения моментов вычислений
    /// </summary>
    public class CalculModel
    {
        /// <summary>
        /// Первый аргумент
        /// </summary>
        public int Arg1 { get; set; }

        /// <summary>
        /// Второй аргумент
        /// </summary>
        public int Arg2 { get; set; }

        /// <summary>
        /// Результат вычислений
        /// </summary>
        public decimal Result { get; set; }

        /// <summary>
        /// Наименование операции
        /// </summary>
        public string OperationName { get; set; }
    }
}
