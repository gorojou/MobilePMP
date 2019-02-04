using System;
namespace mobilePMP.ViewModels
{
    public interface IBaseViewModel
    {
        string Icon { get; set; }
        bool IsBusy { get; set; }
        string Title { get; set; }
    }
}
