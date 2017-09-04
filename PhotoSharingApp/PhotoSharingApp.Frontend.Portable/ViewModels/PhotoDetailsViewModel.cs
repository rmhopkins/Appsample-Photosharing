using System;
using PhotoSharingApp.Frontend.Portable.Models;
using System.Linq;
using System.Threading.Tasks;
using PhotoSharingApp.Frontend.Portable.Services;

namespace PhotoSharingApp.Frontend.Portable
{
    public class PhotoDetailsViewModel : AsyncViewModelBase
    {
        private IPhotoService photoService;

        private Photo photo;
        public Photo Photo
        {
            get { return photo; }
            set { photo = value; RaisePropertyChanged(); }
        }

        public PhotoDetailsViewModel(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        public async Task RefreshAsync()
        {
            IsRefreshing = true;

            // Update photo with detailed information
            Photo = await photoService.GetPhotoDetails(Photo.Id);

            IsRefreshing = false;
        }
    }
}
