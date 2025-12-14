using UnityEngine;

namespace Databases
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Databases/Sprite Database")]
    public class SpriteDatabase : DatabaseBase<SpriteData>
    {
        protected override string GetKey(SpriteData entry) => entry.id;
    }
}