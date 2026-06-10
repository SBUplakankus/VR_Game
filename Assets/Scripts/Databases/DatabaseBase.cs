using System;
using System.Collections.Generic;
using UnityEngine;

namespace Databases
{
    public abstract class DatabaseBase<T> : ScriptableObject
    {
        [SerializeField] private T[] entries;

        private Dictionary<string, T> _lookup;
        private bool _isLookupBuilt;

        public T[] Entries => entries;

        protected abstract string GetKey(T entry);

        private void BuildLookup()
        {
            if (_isLookupBuilt) return;

            _lookup = new Dictionary<string, T>(entries.Length, StringComparer.Ordinal);

            for (var i = 0; i < entries.Length; i++)
            {
                var entry = entries[i];
                var key = NormalizeKey(GetKey(entry));
                _lookup[key] = entry;
            }

            _isLookupBuilt = true;
        }

        private static string NormalizeKey(string id) => id.Trim().ToLowerInvariant();

        public bool TryGet(string id, out T entry)
        {
            if (!_isLookupBuilt) BuildLookup();
            return _lookup.TryGetValue(NormalizeKey(id), out entry);
        }

        public T Get(string id)
        {
            if (!_isLookupBuilt) BuildLookup();
            return _lookup[NormalizeKey(id)];
        }

        protected virtual void OnEnable() => BuildLookup();

        protected virtual void OnDisable()
        {
            _isLookupBuilt = false;
            _lookup = null;
        }

#if UNITY_EDITOR
        public void EditorRebuildLookup()
        {
            _isLookupBuilt = false;
            BuildLookup();
        }
#endif
    }
}
