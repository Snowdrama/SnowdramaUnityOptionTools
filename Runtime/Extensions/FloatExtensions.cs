using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{

    public static float Clamp(this float f, float min, float max)
    {
        return Mathf.Clamp(f, min, max);
    }

    public static float Remap(this float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    /// <summary>
    /// Clamp a value and wrap around to based on the difference
    ///
    /// the wrap clamp maxValue is EXCLUSIVE so 
    /// WrapClamp(0, 5, 4.99f) = 4.99f
    /// WrapClamp(0, 5, 5.00f) = 0.0f
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float WrapClamp(float minValue, float maxValue, float value)
    {
        //prevent issues where the min and max are the same
        if (minValue == maxValue)
        {
            return minValue;
        }

        //swap the values if they're entered wrong.
        if(minValue > maxValue)
        {
            Debug.LogErrorFormat("Wrap Clamp's minValue {0} is greater than it's maxValue {1}, we've swapped the values.", minValue, maxValue);
            var temp = minValue;
            minValue = maxValue;
            maxValue = temp;
        }

        if (value < minValue)
        {
            value = maxValue - Mathf.Abs(minValue - value);
        }

        if (value >= maxValue)
        {
            value = minValue + (value - maxValue);
        }

        //recurse if we're still outside the range.
        if (value >= maxValue || value < minValue)
        {
            value = WrapClamp(minValue, maxValue, value);
        }

        return value;
    }

}