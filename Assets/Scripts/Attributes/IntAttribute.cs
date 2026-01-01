using System;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace Attributes
{
    [CreateAssetMenu(fileName = "IntAttribute", menuName = "Scriptable Objects/Attributes/Int")]
    public class IntAttribute : ScriptableObject, INotifyBindablePropertyChanged
    {
        #region Fields
        
        [SerializeField] private string attributeName;
        [SerializeField] private int value;
        
        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;

        #endregion
        
        #region Properties
        
        [CreateProperty]
        public int Value
        {
            get => value;
            set 
            {
                if (this.value == value) return;
                this.value = value;
                Notify();
            }
        }
        
        public string AttributeName => attributeName;
        
        #endregion
        
        #region Methods

        private void Notify([CallerMemberName] string property = "") => propertyChanged?.Invoke(this, new BindablePropertyChangedEventArgs(property));
        
        public void Add(int amount) => Value += amount;
        public void Reset() => Value = 0;
        public void Refresh() => Notify(nameof(Value));
        public float GetPercentage(int maxValue) => (float)Value / maxValue;
        public bool IsAtLeast(int amount) => Value >= amount;
        public bool IsAtMost(int amount) => Value <= amount;
        public bool IsBetween(int min, int max) => Value >= min && Value <= max;
        public bool IsExactly(int amount) => Value == amount;
        
        #endregion

    }
}
