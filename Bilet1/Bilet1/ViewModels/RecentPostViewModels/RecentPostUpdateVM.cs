namespace Bilet1.ViewModels.RecentPostViewModels
{
    public class RecentPostUpdateVM
    {
        public RecentPostGetVM recentGet { get; set; }
        public RecentPostPostVM recentPostVm { get; set; }
        public RecentPostUpdateVM()
        {
            recentPostVm = new RecentPostPostVM();
        }
    }
}
