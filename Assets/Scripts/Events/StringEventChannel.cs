using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "StringEventChannel", menuName = "Scriptable Objects/Event Channels/String")]
    public class StringEventChannel : TypeEventChannelBase<string> { }
}
