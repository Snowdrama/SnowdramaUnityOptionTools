using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.ClassExtensions{
    public static class Vector2Extension{
        public static Vector2 VectorFromAngleRads(float angle)
        {
            Vector2 V = new Vector2();
            V.x = Mathf.Cos(angle);
            V.y = Mathf.Sin(angle);
            return V.normalized;
        }

        public static Vector2 VectorFromAngle(float angle)
        {
            angle = Mathf.Deg2Rad * angle;
            return VectorFromAngleRads(angle).normalized;
        }

        public static float AngleFromVector(this Vector2 dir)
        {
            float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x);
            if (angle < 0)
            {
                angle += 360;
            }
            return angle;
        }

        public static float AngleFromVectorRads(this Vector2 dir)
        {
            var angle = Mathf.Atan2(dir.y , dir.x);
            if (angle < 0)
            {
                angle += 2 * Mathf.PI;
            }
            return angle;
        }

        public static Vector2 PerpendicularClockwise(this Vector2 vec)
        {
            return new Vector2(vec.y, -vec.x);
        }

        public static Vector2 PerpendicularCounterClockwise(this Vector2 vec)
        {
            return new Vector2(-vec.y, vec.x);
        }
        public static float AngleTo(this Vector2 self, Vector2 to)
        {
            Vector2 direction = to - self;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (angle < 0f) angle += 360f;
            return angle;
        }
    }
}