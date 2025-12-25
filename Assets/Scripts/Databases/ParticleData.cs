using System;
using Systems;
using UnityEngine;

namespace Databases
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Data/Particle Data")]
    public class ParticleData : ScriptableObject
    {
        [SerializeField] private string particleId;
        [SerializeField] private GameObject particlePrefab;
        [SerializeField] private VFXPriority vfxPriority =  VFXPriority.Low;
        
        public GameObject Prefab => particlePrefab;
        public string ID => particleId;
        public VFXPriority Priority => vfxPriority;
    }
}