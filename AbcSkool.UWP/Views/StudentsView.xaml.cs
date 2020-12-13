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
    public sealed partial class StudentsView : Page
    {
        StudentsViewModel VM;

        public StudentsView()
        {
            this.InitializeComponent();
        }

        private async void AddSTudent_Click(object sender, RoutedEventArgs e)
        {
      

            object @object;
            if (this.VM.IsItemSelected)
            {
                @object = new UpdateStudentDTO
                {
                    Name = Name.Text,
                    Surname = Surname.Text,
                    StudentId = this.VM.StudentId,
                    StudentNumber = this.VM.StudentNumber
                };
            }
            else
            {
                @object = new AddStudentDTO
                {
                    Name = Name.Text,
                    Surname = Surname.Text,
                    StudentNumber = Factory.RandomStudentNumberGenerator.Next(Config.StudentNumber_MinValue, Config.StudentNumber_MaxValue)
                };
            }


            try
            {
                if (this.VM.IsItemSelected)
                    await AppData.Client.PutAsync(Config.REST_Endpoints_Students, @object);
                else
                    await AppData.Client.Post(Config.REST_Endpoints_Students, @object);

                await AppData.RefreshStudentsAsync();
                this.VM.Students = AppData.Students;
                this.VM.Name = string.Empty;
                this.VM.Surname = string.Empty;
                this.VM.StudentNumber = 0;
            }
            catch (Exception ex)
            {
                string title = $"OH SNAP! Failed to add the following student : {((Student)@object).StudentNumber}";

                string msg = $"Couldn't add student : {((Student)@object).ToString()}. \n Exception : {ex.Message}. \n Inner Exception : {ex.InnerException?.Message}.";
                var dialog = new MessageDialog(msg, title);
                await dialog.ShowAsync();
                // Log error
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            this.VM = e.Parameter as StudentsViewModel;
            this.DataContext = VM;

            base.OnNavigatedTo(e);
        }

        private void StudentsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            Student subject = e.ClickedItem as Student;
            this.VM.Name = subject.Name;
            this.VM.Surname = subject.Surname;
            this.VM.StudentId = subject.StudentId;
            this.VM.StudentNumber = subject.StudentNumber;

            this.VM.IsItemSelected = true;
        }

        private void ClearSelection_Click(object sender, RoutedEventArgs e)
        {
            StudentsGrid.SelectedItem = null;
            this.VM.IsItemSelected = false;
            this.VM.Name = string.Empty;
            this.VM.Surname = string.Empty;
            this.VM.StudentNumber = 0;

        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            await AppData.Client.DeleteAsync(Config.REST_Endpoints_Students, VM.StudentId);
            await AppData.RefreshSubjectAsync();
            this.VM.Students = AppData.Students;
            this.VM.Name = string.Empty;
            this.VM.Surname = string.Empty;
            this.VM.StudentNumber = 0;

            StudentsGrid.SelectedItem = null;
            this.VM.IsItemSelected = false;
        }
    }
}
