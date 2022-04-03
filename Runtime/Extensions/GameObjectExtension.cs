using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.ClassExtensions
{
    public static class GameObjectExtension
    {
            
        /// <summary>
        /// Runs an action if the component is present
        ///
        /// myGameObject.RunIfHasComponent<Rigidbody>((Rigidbody rigid) => {
        ///    
        /// })
        /// </summary>
        /// <param name="go"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void RunIfHasComponent<T>(this GameObject go, Action<T> action)
        {
            var component = go.GetComponent<T>();
            if(component != null)
            {
                action?.Invoke(component);
            }
        }

    }
}
