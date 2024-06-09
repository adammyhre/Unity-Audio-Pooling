using UnityEngine;

namespace AudioSystem {
    public static class GameObjectExtensions {
        public static T GetOrAdd<T>(this GameObject gameObject) where T : Component {
            T component = gameObject.GetComponent<T>();
            if (!component) component = gameObject.AddComponent<T>();

            return component;
        }
    }
}