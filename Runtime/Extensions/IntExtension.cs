using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.ClassExtensions{
    public static class IntExtension{
        
        /// <summary>
        /// Clamp a value and wrap around to based on the difference
        ///
        /// the wrap clamp maxValue is EXCLUSIVE so
        /// WrapClamp(4, 0, 5) = 4
        /// WrapClamp(5, 0, 5) = 0
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int WrapClamp(int value, int minValue, int maxValue)
        {
            if (value < minValue)
            {
                value = maxValue - Mathf.Abs(minValue - value);
            }

            if (value >= maxValue)
            {
                value = minValue + (value - maxValue);
            }
            return value;
        }
    }
}