using UnityEngine;

namespace ebac.Core.Singleton
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T instance;

        private void Awake()
        {
            if (instance == null)
                instance = GetComponent<T>();
            else
                Destroy(instance);
        }
    }

}
