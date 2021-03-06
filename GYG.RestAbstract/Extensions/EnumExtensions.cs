﻿namespace GYG.RestAbstract.Extensions
{
    using System;
    public static class EnumExtensions
    {
        public static int ToInt(this Enum e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            int value = Convert.ToInt32(e);
            return value;
        }
    }
}
