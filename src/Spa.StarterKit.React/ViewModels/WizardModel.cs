namespace Spa.StarterKit.React.ViewModels
{
    public abstract class WizardModel 
    {
        public bool IsCompleted { get; set; }
        public int PageStateId { get; set; }
        public string CookieId { get; set; }
    }
}