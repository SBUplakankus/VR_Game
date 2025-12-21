using System.Collections.Generic;
using UnityEngine;

namespace Characters.Base
{
    public abstract class AnimatorComponent : MonoBehaviour
    {
        private Animator _animator;
        
        protected static readonly int SpeedHash = Animator.StringToHash("Speed");
        protected static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
        
        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public virtual void SetSpeed(float speed)
        {
            _animator.SetFloat(SpeedHash, speed);
        }
        
        public virtual void SetBool(int param, bool value)
        {
            _animator.SetBool(param, value);
        }
        
        public virtual void SetTrigger(int param)
        {
            _animator.SetTrigger(param);
        }
    }
}
