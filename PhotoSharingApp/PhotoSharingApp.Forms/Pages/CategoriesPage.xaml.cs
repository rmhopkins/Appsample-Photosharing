using System;
using System.Collections.Generic;
using FFImageLoading.Transformations;
using GalaSoft.MvvmLight.Ioc;
using PhotoSharingApp.Frontend.Portable.ViewModels;
using Xamarin.Forms;
using PhotoSharingApp.Frontend.Portable.Models;

namespace PhotoSharingApp.Forms
{
    public partial class CategoriesPage : ContentPage
    {
        private CategoriesViewModel viewModel;

        public CategoriesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = SimpleIoc.Default.GetInstance<CategoriesViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.RefreshAsync();
        }

        void Handle_FlowItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as PhotoThumbnail;
            if (selectedItem != null)
                viewModel.ShowCategoryStreamCommand.Execute(selectedItem);
        }
    }
}
