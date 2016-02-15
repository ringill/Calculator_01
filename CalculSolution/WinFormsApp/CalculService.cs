using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    /// <summary>
    /// Класс, отвечающий за вычисления и взаимодействие с библиотекой Logic
    /// </summary>
    public class CalculService
    {
        /// <summary>
        /// Main function!
        /// </summary>
        /// <returns></returns>
        public CalculModel Calculate(CalculModel arguments)
        {
            Result result;

            switch (arguments.OperationName)
            {
                //addition
                case "Сложение":
                    result = Logic.Operator.Plus(arguments.Arg1, arguments.Arg2);
                    break;
                //subtraction
                case "Вычитание":
                    result = Logic.Operator.Minus(arguments.Arg1, arguments.Arg2);
                    break;
                //multiplication
                case "Умножение":
                    result = Logic.Operator.Multi(arguments.Arg1, arguments.Arg2);
                    break;
                //division
                case "Деление":
                    result = Logic.Operator.Div(arguments.Arg1, arguments.Arg2);
                    break;
                default:
                    result = new Result { Success = false };
                    break;
            }
            //если вычисление не удалось - возвращаем null
            if (result.Success == false) return null;

            //если удалось возвращаем число
            arguments.Result = result.Number;
            return arguments;
        }
    }
}
