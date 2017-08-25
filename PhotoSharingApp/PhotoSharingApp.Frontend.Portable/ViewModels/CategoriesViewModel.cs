using System;
using GalaSoft.MvvmLight;
using PhotoSharingApp.Frontend.Portable.Services;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace PhotoSharingApp.Frontend.Portable.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        private IPhotoService photoService;

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; RaisePropertyChanged(); }
        }

        private RelayCommand refreshCommand;
        public RelayCommand RefreshCommand
        {
            get { return refreshCommand ?? (refreshCommand = new RelayCommand(async () => { await RefreshAsync(); })); }
        }

        public CategoriesViewModel(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        public async Task RefreshAsync()
        {
            IsRefreshing = true;

            var images = await photoService.GetHeroImages(10);

            IsRefreshing = false;
        }
    }
}
