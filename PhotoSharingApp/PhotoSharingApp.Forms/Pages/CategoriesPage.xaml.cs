using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using PhotoSharingApp.Frontend.Portable.ViewModels;
using Xamarin.Forms;

namespace PhotoSharingApp.Forms
{
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();
            BindingContext = SimpleIoc.Default.GetInstance<CategoriesViewModel>();
        }
    }
}
