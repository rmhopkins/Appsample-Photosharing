using System;
using PhotoSharingApp.Frontend.Portable.Models;
using System.Linq;
namespace PhotoSharingApp.Frontend.Portable
{
    public class PhotoDetailsViewModel : AsyncViewModelBase
    {
        private Photo photo;
        public Photo Photo
        {
            get { return photo; }
            set { photo = value; RaisePropertyChanged(); }
        }

        public PhotoDetailsViewModel()
        {

        }
    }
}
