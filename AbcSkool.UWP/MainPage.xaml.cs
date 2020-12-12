using AbcSkool.UWP.ViewModels;
using AbcSkool.UWP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AbcSkool.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageViewModel MainPageViewModel;
        StudentsViewModel StudentsViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            Loading += MainPage_Loading;
            Loaded += MainPage_Loaded;

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            this.DataContext = this.MainPageViewModel;
            MainFrame.Navigate(typeof(HomeView));
        }

        private void MainPage_Loading(FrameworkElement sender, object args)
        {
            this.MainPageViewModel = new MainPageViewModel { };
            this.StudentsViewModel = new StudentsViewModel { };
            this.MainPageViewModel.Students = AppData.Students;
            this.StudentsViewModel.Students = AppData.Students;
        }

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            HambergerSplit.IsPaneOpen = !HambergerSplit.IsPaneOpen;
        }

        private void HomeLink_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(HomeView), this.MainPageViewModel);
            HambergerSplit.IsPaneOpen = false;

        }


        private void SubjectLink_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(SubjectsView));
            HambergerSplit.IsPaneOpen = false;
        }

        private void StudentLink_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(StudentsView), StudentsViewModel);
            HambergerSplit.IsPaneOpen = false;
        }
    }
}
