using UnityEngine;

namespace Systems
{
    public class DetachOnAwake :  MonoBehaviour
    {
        private void Awake()
        {
            if (transform.parent != null)
                transform.SetParent(null, worldPositionStays: true);
        }
    }
}