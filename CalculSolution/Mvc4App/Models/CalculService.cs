using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic;

namespace Mvc4App.Models
{
    public class CalculService
    {
        public CalculViewModel AddResult(CalculViewModel model)
        {
            Result resultResult;
            string resultString;
            int arg1, arg2;
            //Проверка корректности значений
            //arg1
            if (!int.TryParse(model.Argument1, out arg1))
            {
                model.Result = "Неудачен первый аргумент";
                return model;
            }
            //arg2
            if (!int.TryParse(model.Argument2, out arg2))
            {
                model.Result = "Неудачен второй аргумент";
                return model;
            }

            //производим соответствующие вычисления
            switch (model.selectedOperator)
            {
                //addition
                case "Сложение":
                    resultResult = Operator.Plus(arg1, arg2);
                    break;
                //subtraction
                case "Вычитание":
                    resultResult = Operator.Minus(arg1, arg2);
                    break;
                //multiplication
                case "Умножение":
                    resultResult = Operator.Multi(arg1, arg2);
                    break;
                //division
                case "Деление":
                    resultResult = Operator.Div(arg1, arg2);
                    break;
                default:
                    resultResult = new Result { Success = false };

                    break;
            }

            //если успешно - меняем модель (добавляем информацию о результате расчета), если неудачно - информируем
            model.Result = resultResult.Success ? resultResult.Number.ToString() : "Неудачен результат расчета";

            return model;
        }
    }
}