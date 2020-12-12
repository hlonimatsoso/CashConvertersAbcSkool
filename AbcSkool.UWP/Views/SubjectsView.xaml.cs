using AbcSkool.Models.DTO;
using AbcSkool.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AbcSkool.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectsView : Page
    {
        SubjectsViewModel VM;

        public SubjectsView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.VM = e.Parameter as SubjectsViewModel;
            this.DataContext = VM;

            base.OnNavigatedTo(e);
        }

        private async void AddSubject_Click(object sender, RoutedEventArgs e)
        {
            AddSubjectDTO subject = new AddSubjectDTO
            {
                SubjectName = SubjectName.Text,
                Description = Description.Text,
            };


            try
            {
                await AppData.Client.Post(Config.REST_Endpoints_Subjects, subject);
                await AppData.RefreshSubjectAsync();
                this.VM.Subjects = AppData.Subjects;
                this.VM.SubjectName = string.Empty;
                this.VM.Description = string.Empty;

            }
            catch (Exception ex)
            {
                string title = $"OH SNAP! Failed to add the following subject : {subject.SubjectName}";

                string msg = $"Couldn't add subject : {subject.ToString()}. \n Exception : {ex.Message}. \n Inner Exception : {ex.InnerException?.Message}.";
                var dialog = new MessageDialog(msg, title);
                await dialog.ShowAsync();
                // Log error
            }
        }

 
    }
}
