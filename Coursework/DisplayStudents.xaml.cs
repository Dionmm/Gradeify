using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Coursework
{
    /// <summary>
    /// Interaction logic for DisplayStudents.xaml
    /// </summary>
    public partial class DisplayStudents : Page
    {
        private bool buttonDisabled = true;
        private MainWindow mw;
        private StudentList studentList;
        public DisplayStudents()
        {
            InitializeComponent();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    mw = (window as MainWindow);

                }
            }
        }
        private void editSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (buttonDisabled)
            {
                mw.editStudent.IsEnabled = true;
                buttonDisabled = false;
            }
            studentList = (StudentList)studentGrid.DataContext;
            //When deleting a student the list box can become confused due to
            //the selected index disappearing. If it gets confused this resets
            //the selected item back to the default -1
            try
            {
                mw.SelectedStudent = studentList[studentListBox.SelectedIndex];
            }
            catch
            {
                studentListBox.SelectedIndex = -1;
                mw.editStudent.IsEnabled = false;
                buttonDisabled = true;
            }
            e.Handled = true;
        }
        public void OnPropertyChanged(object source, EventArgs e)
        {
            studentListBox.Items.Refresh();
        }
    }
}
