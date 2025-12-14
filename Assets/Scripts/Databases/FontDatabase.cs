using UnityEngine;

namespace Databases
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Databases/TMP Font Database")]
    public class TMPFontDatabase : DatabaseBase<TMPFontData>
    {
        protected override string GetKey(TMPFontData entry) => entry.id;
    }
}