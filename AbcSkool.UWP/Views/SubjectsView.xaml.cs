using AbcSkool.Models;
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
            object @object;
            if (this.VM.IsItemSelected)
            {
                @object = new UpdateSubjectDTO
                {
                    SubjectName = SubjectName.Text,
                    Description = Description.Text,
                    SubjectId = this.VM.SubjectId
                };
            }
            else
            {
                @object = new AddSubjectDTO
                {
                    SubjectName = SubjectName.Text,
                    Description = Description.Text,
                };
            }


            try
            {
                if (this.VM.IsItemSelected)
                    await AppData.Client.PutAsync(Config.REST_Endpoints_Subjects, @object);
                else
                    await AppData.Client.Post(Config.REST_Endpoints_Subjects, @object);


                await AppData.RefreshSubjectAsync();
                this.VM.Subjects = AppData.Subjects;
                this.VM.SubjectName = string.Empty;
                this.VM.Description = string.Empty;

            }
            catch (Exception ex)
            {
                string title = $"OH SNAP! Failed to add the following subject : {((Subject)@object).SubjectName}";

                string msg = $"Couldn't add subject : {((Subject)@object).ToString()}. \n Exception : {ex.Message}. \n Inner Exception : {ex.InnerException?.Message}.";
                var dialog = new MessageDialog(msg, title);
                await dialog.ShowAsync();
                // Log error
            }
        }

        private void SubjectsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            Subject subject = e.ClickedItem as Subject;
            this.VM.SubjectName = subject.SubjectName;
            this.VM.Description = subject.Description;
            this.VM.SubjectId = subject.SubjectId;
            
            this.VM.IsItemSelected = true;
        }

        private void ClearSelection_Click(object sender, RoutedEventArgs e)
        {
            SubjectsGrid.SelectedItem = null;
            this.VM.IsItemSelected = false;
            this.VM.SubjectName = string.Empty;
            this.VM.Description = string.Empty;


        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            await AppData.Client.DeleteAsync(Config.REST_Endpoints_Subjects, VM.SubjectId);
            await AppData.RefreshSubjectAsync();
            this.VM.Subjects = AppData.Subjects;
            this.VM.SubjectName = string.Empty;
            this.VM.Description = string.Empty;
            SubjectsGrid.SelectedItem = null;
            this.VM.IsItemSelected = false;


        }
    }
}
