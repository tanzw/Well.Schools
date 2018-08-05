using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Well.Schools.Common
{
    public static class TypeConvertExtensions
    {
        public static int ToInt(this object val)
        {
            if (val == null)
            {
                throw new Exception("当前对象为null,不能转型");
            }

            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                throw new Exception("非数字不能转Int类型");
            }

        }

        public static int TryToInt(this object val, int errorDefaultValue = 0)
        {
            if (val == null)
            {
                throw new Exception("当前对象为null,不能转型");
            }

            int o = errorDefaultValue;
            int.TryParse(val.ToString(), out errorDefaultValue);
            return o;
        }

        public static int ToInt(this string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                throw new Exception("当前对象为null,不能转型");
            }

            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                throw new Exception("非数字不能转Int类型");
            }

        }

        public static int TryToInt(this string val, int errorDefaultValue = 0)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                throw new Exception("当前对象为null,不能转型");
            }

            int o = errorDefaultValue;
            int.TryParse(val, out errorDefaultValue);
            return o;
        }

        public static decimal ToToDecimal(this string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                throw new Exception("当前对象为null,不能转型");
            }

            try
            {
                return Convert.ToDecimal(val);
            }
            catch
            {
                throw new Exception("非数字不能转Decimal类型");
            }

        }

        public static decimal TryToDecimal(this string val, decimal errorDefaultValue = 0)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                throw new Exception("当前对象为null,不能转型");
            }

            decimal o = errorDefaultValue;
            decimal.TryParse(val, out errorDefaultValue);
            return o;
        }


    }
}
