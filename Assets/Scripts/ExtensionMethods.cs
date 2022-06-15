namespace DevotionEntertainment
{
    using UnityEngine;
    using System.Collections;
    using System;
    using System.Collections.Generic;

    public static class ExtensionMethods
    {
        /// <summary>
        /// Resets the transfrom (position, rotation and scale) of transform
        /// </summary>
        /// <param name="_transform">Transform to reset</param>
        public static void ResetTransform(this Transform _transform)
        {
            _transform.position = Vector3.zero;
            _transform.localRotation = Quaternion.identity;
            _transform.localScale = new Vector3(1, 1, 1);
        }

        /// <summary>
        /// Returns Component if exists on GameObject
        /// </summary>
        /// <param name="gameObject">GameObject component attached to</param>
        /// <param name="component">Component to find</param>
        /// <returns>Component</returns>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.TryGetComponent<T>(out T t))
                return t;
            else
                return gameObject.AddComponent<T>();
        }

        /// <summary>
        /// If object has a compomnent - return true, otherwise - false
        /// </summary>
        /// <typeparam name="T">Type of compomnent to find</typeparam>
        /// <param name="gameObject">Object component should be attached to</param>
        /// <returns></returns>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() != null;
        }

        /// <summary>
        /// Returns a random item from list
        /// </summary>
        /// <typeparam name="T">Type of list (unnecessary)</typeparam>
        /// <param name="list">List we are looking for item</param>
        /// <returns></returns>
        public static T GetRandom<T>(this List<T> list)
        {
            if (list.Count == 0) throw new System.IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}