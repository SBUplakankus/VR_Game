using Audio;
using UnityEngine;

namespace Databases
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Databases/World Audio Database")]
    public class WorldAudioDatabase : DatabaseBase<WorldAudioData>
    {
        protected override string GetKey(WorldAudioData entry) => entry.ID;
    }
}