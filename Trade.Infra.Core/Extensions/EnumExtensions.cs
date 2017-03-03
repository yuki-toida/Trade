using System;
using System.Linq;
using System.Reflection;
using Trade.Infra.Core.Attributes;

namespace Trade.Infra.Core.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// EnumValueに設定された値を取得します。
        /// </summary>
        public static T GetValue<T>(this Enum target)
        {
            var fieldInfo = target.GetType().GetField(target.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(EnumValueAttribute), false) as EnumValueAttribute[];
            if (attributes == null)
                return default(T);

            return (T)attributes.Single().Value;
        }
    }
}
