namespace Events.Registries
{
    public static class UIEvents
    {
        
        public static readonly EventChannel FadeIn = new();
        public static readonly EventChannel FadeOut = new();
        
                
        
        public static void Clear()
        {
            FadeIn.Clear();
            FadeOut.Clear();
        }
        
            }
}