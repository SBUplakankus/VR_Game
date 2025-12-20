using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/Weapons/Data")]
    public class WeaponData : ScriptableObject
    {
        [Header("Identification")]
        public string weaponID;
        public string displayName;
        public WeaponCategory category;
        public WeaponRarity rarity;
        public GameObject weaponPrefab;
        
        [Header("Base Stats")]
        public int baseDamage = 10;
        public float attackSpeed = 1f;
        public int range = 2;
        public int staminaCost = 10;
        public DamageType damageType;
        
        [Header("VR Settings")]
        public Vector3 gripPositionOffset;
        public Vector3 gripRotationOffset;
        public float hapticStrength = 0.5f;
        public float hapticDuration = 0.1f;
        
        [Header("Visual/Audio")]
        public string swingSoundKey;
        public string hitSoundKey;
        public string hitVFXKey;
        
        [Header("Modifiers")]
        public List<WeaponModifier> activeModifiers = new();
        
        // Calculated stats
        public int GetTotalDamage()
        {
            var total = baseDamage;
            foreach (var mod in activeModifiers)
                total += mod.damageBonus;
            
            return total;
        }
    }
}
