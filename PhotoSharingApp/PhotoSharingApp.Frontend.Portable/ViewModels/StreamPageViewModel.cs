using System;
using PhotoSharingApp.Frontend.Portable.Models;

namespace PhotoSharingApp.Frontend.Portable
{
    public class StreamPageViewModel : AsyncViewModelBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        public StreamPageViewModel()
        {
        }

        public void Init(CategoryPreview categoryPreview)
        {
            Title = categoryPreview.Name;
        }
    }
}
