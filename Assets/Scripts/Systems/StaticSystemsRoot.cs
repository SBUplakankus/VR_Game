using UnityEngine;

namespace Systems
{
    /// <summary>
    /// Root object for all static singleton systems.  
    /// Children can call DontDestroyOnLoad safely at runtime.  
    /// This object itself is a root and persistent across scenes.
    /// </summary>
    [DefaultExecutionOrder(-1000)] // ensure it initializes early
    public class StaticSystemsRoot : MonoBehaviour
    {
        private static StaticSystemsRoot _instance;

        public static StaticSystemsRoot Instance
        {
            get
            {
                if (_instance != null) return _instance;
                var go = new GameObject("STATIC_SYSTEMS_ROOT");
                _instance = go.AddComponent<StaticSystemsRoot>();
                _instance.Initialize();

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            Initialize();
        }

        private void Initialize()
        {
            if (transform.parent != null)
                transform.SetParent(null);

            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Adds a system as a child and optionally detaches it immediately to remain a root.
        /// </summary>
        public void AddSystem(GameObject system)
        {
            system.transform.SetParent(transform, worldPositionStays: true);
        }
    }
}
