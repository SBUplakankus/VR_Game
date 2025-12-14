namespace Events
{
    public static class GameEvents
    {
        #region Player Events
        
        public static IntEventChannel OnPlayerDamaged;
        
        #endregion
        
        #region Audio Events
        
        public static StringEventChannel OnMusicRequested;
        public static StringEventChannel OnSfxRequested;
        
        #endregion
    }
}
