using Esper.ESave;
using UnityEngine;

namespace Saves
{
    [RequireComponent(typeof(SaveFileSetup))]
    public abstract class SaveFileManagerBase : MonoBehaviour
    {
        
        [Header("Save Data")] 
        private SaveFileSetup _saveFileSetup;
        protected SaveFile SaveFile;

                
        
        protected abstract void HandleSaveRequested();

        protected abstract void HandleSaveCompleted();

        protected abstract void HandleLoadRequested();

        protected abstract void HandleLoadCompleted();

                
                
        protected void GetSaveFile()
        { 
            _saveFileSetup = GetComponent<SaveFileSetup>();
            SaveFile = _saveFileSetup.GetSaveFile();
        }
        
                
        
    }
}