using System;
using GalaSoft.MvvmLight;
using PhotoSharingApp.Frontend.Portable.Services;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MvvmHelpers;
using PhotoSharingApp.Frontend.Portable.Models;
using System.Collections.ObjectModel;

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

        private ObservableCollection<Photo> heroImages;
        public ObservableCollection<Photo> HeroImages
        {
            get { return heroImages; }
            set { heroImages = value; RaisePropertyChanged(); }
        }

        private RelayCommand refreshCommand;
        public RelayCommand RefreshCommand
        {
            get { return refreshCommand ?? (refreshCommand = new RelayCommand(async () => { await RefreshAsync(); })); }
        }

        public CategoriesViewModel(IPhotoService photoService)
        {
            this.photoService = photoService;

            heroImages = new ObservableCollection<Photo>();
        }

        public async Task RefreshAsync()
        {
            IsRefreshing = true;

            heroImages.Clear();
            var images = await photoService.GetHeroImages(5);
            foreach (var img in images)
            {
                heroImages.Add(img);
            }

            IsRefreshing = false;
        }
    }
}
