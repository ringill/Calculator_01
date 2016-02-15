using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Oper
    {
        public string Name { get; set; }
        public string Sign { get; set; }
    }

    public static class OperList
    {
        public static Oper[] Opers =
            {
                //id = 0
                new Oper
                    {
                        Name = "Сложение",
                        Sign = " + ",
                    }, 
                //id = 1
                new Oper
                    {
                        Name = "Вычитание",
                        Sign = " - ",
                    },
                //id = 2
                new Oper
                    {
                        Name = "Умножение",
                        Sign = " * ",
                    },
                //id = 3
                new Oper
                    {
                        Name = "Деление",
                        Sign = " / ",
                    },
                //id = 4
                new Oper
                    {
                        Name = "Равно",
                        Sign = " = ",
                    }
            };

        /// <summary>
        /// Возвращает выражение в виде строки
        /// </summary>
        /// <param name="arg1">первый аргумент</param>
        /// <param name="arg2">второй аргумент</param>
        /// <param name="result">результат вычисления</param>
        /// <param name=" operationName">наименование операции</param>
        /// <returns>суммарное выражение</returns>
        public static string CalculString(string arg1, string arg2, string result, string operationName)
        {
            //build operation string
            StringBuilder builder = new StringBuilder();
            builder.Append(arg1);
            builder.Append(Opers.Single(o => o.Name == operationName).Sign);
            builder.Append(arg2);
            builder.Append(Opers[Opers.Length-1].Sign);
            builder.Append(result);
            //return it
            return builder.ToString();
        }

        /// <summary>
        /// Преобразует входящие значения в строку определенного формата
        /// </summary>
        /// <param name="when">строка даты</param>
        /// <param name="what">строка выражения</param>
        /// <returns>результирующая общая строка</returns>
        public static string HistoryString(string when, string what)
        {
            return when + " | " + what;
        }
    }
}
