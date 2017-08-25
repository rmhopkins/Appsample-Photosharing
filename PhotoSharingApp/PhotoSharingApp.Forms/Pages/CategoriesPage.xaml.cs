using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using PhotoSharingApp.Frontend.Portable.ViewModels;
using Xamarin.Forms;

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
    }
}
