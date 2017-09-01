using System;
using GalaSoft.MvvmLight;
namespace PhotoSharingApp.Frontend.Portable
{
    public class AsyncViewModelBase : ViewModelBase
    {
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; RaisePropertyChanged(); }
        }

        private bool isLoaded;
        public bool IsLoaded
        {
            get { return isLoaded; }
            set { isLoaded = value; RaisePropertyChanged(); }
        }
    }
}
