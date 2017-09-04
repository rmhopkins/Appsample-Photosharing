using System;
using PhotoSharingApp.Frontend.Portable.Models;
using PhotoSharingApp.Frontend.Portable.Services;
using System.Threading.Tasks;
using MvvmHelpers;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace PhotoSharingApp.Frontend.Portable
{
    public class StreamPageViewModel : AsyncViewModelBase
    {
        private INavigationService navigationService;
        private IPhotoService photoService;

        private string categoryId;

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        private ObservableRangeCollection<Photo> photos;
        public ObservableRangeCollection<Photo> Photos
        {
            get { return photos; }
            set { photos = value; RaisePropertyChanged(); }
        }

        private RelayCommand<Photo> showPhotoDetailsCommand;
        public RelayCommand<Photo> ShowPhotoDetailsCommand
        {
            get
            {
                return showPhotoDetailsCommand ?? (showPhotoDetailsCommand = new RelayCommand<Photo>((Photo photo) =>
                {
                    navigationService.NavigateTo(ViewNames.PhotoDetailsPage, photo);
                }));
            }
        }

        public StreamPageViewModel(INavigationService navigationService, IPhotoService photoService)
        {
            this.navigationService = navigationService;
            this.photoService = photoService;

            Photos = new ObservableRangeCollection<Photo>();
        }

        public void Init(CategoryPreview categoryPreview)
        {
            categoryId = categoryPreview.Id;
            Title = categoryPreview.Name;
        }

        public async Task RefreshAsync()
        {
            if (categoryId != null)
            {
                var photos = await photoService.GetPhotosForCategoryId(categoryId);

                Photos.ReplaceRange(photos.Items);
                // TODO: Implement pagination, as this only loads photos for the fist page.
            }
        }
    }
}
