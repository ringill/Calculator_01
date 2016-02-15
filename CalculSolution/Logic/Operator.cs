using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Operator
    {
        public static Result Plus(int a, int b)
        {
            Result result = new Result{Success = false};
            decimal c;
            try
            {
                c = (decimal) a + (decimal) b;
            }
            catch (Exception)
            {
                return result;
            }
            result.Number = c;
            result.Success = true;
            return result;
        }

        public static Result Minus(int a, int b)
        {
            Result result = new Result { Success = false };
            decimal c;
            try
            {
                c = (decimal)a - (decimal)b;
            }
            catch (Exception)
            {
                return result;
            }
            result.Number = c;
            result.Success = true;
            return result;
        }

        public static Result Multi(int a, int b)
        {
            Result result = new Result { Success = false };
            decimal c;
            try
            {
                c = (decimal)a * (decimal)b;
            }
            catch (Exception)
            {
                return result;
            }
            result.Number = c;
            result.Success = true;
            return result;
        }

        public static Result Div(int a, int b)
        {
            Result result = new Result { Success = false };
            //деление на ноль недопустимо
            if (b == 0) return result;

            decimal c;
            
            try
            {
                c = (decimal)a / (decimal)b;
            }
            catch (Exception)
            {
                return result;
            }
            result.Number = c;
            result.Success = true;
            return result;
        }
    }
}
