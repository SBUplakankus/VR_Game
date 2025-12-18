using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "WeaponModifier", menuName = "Scriptable Objects/Weapons/Modifier")]
    public class WeaponModifier : ScriptableObject
    {
        public string modifierName;
        public DamageType addedDamageType;
        public int damageBonus = 0;
        public float speedBonus = 0f;
        public GameObject visualEffect;
        public Color trailColor = Color.white;
        
        [TextArea]
        public string description;
    }
}
