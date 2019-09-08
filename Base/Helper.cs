//**********************
//SwEx.PMPage - data driven framework for SOLIDWORKS Property Manager Pages
//Copyright(C) 2019 www.codestack.net
//License: https://github.com/codestackdev/swex-pmpage/blob/master/LICENSE
//Product URL: https://www.codestack.net/labs/solidworks/swex/pmp/
//**********************

using CodeStack.SwEx.Common.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CodeStack.SwEx.PMPage
{
    internal static class Helper
    {
        internal static Dictionary<Enum, string> GetEnumFields(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new InvalidCastException($"{enumType.FullName} must be an enum");
            }

            var enumValues = Enum.GetValues(enumType).Cast<Enum>().ToList();

            var values = enumValues.ToDictionary(e => e,
                e =>
                {
                    var text = "";

                    e.TryGetAttribute<DisplayNameAttribute>(a => text = a.DisplayName);

                    if (string.IsNullOrEmpty(text))
                    {
                        text = e.ToString();
                    }

                    return text;

                });

            return values;
        }
    }
}
