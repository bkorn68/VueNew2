namespace VueTOView.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public static class EnumExtension
    {
        public static int ToInt(this Enum code)
        {
            return Convert.ToInt32(code, CultureInfo.InvariantCulture);
        }

        public static string AsText(this Enum code)
        {
            if (code == null)
            {
                code = Errorcode.The_errorcode_was_not_defined;
            }

            return Enum.GetName(code.GetType(), code).Replace('_', ' ');
        }
    }
}
