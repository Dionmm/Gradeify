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
using System.Text.RegularExpressions;

namespace Coursework
{

    public class StudentEventArgs : EventArgs
    {
        public Student SelectedStudent { get; set; }
        public String Operation { get; set; }
    }

    /// <summary>
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Page
    {
        //Init
        private Student selectedStudent;
        private string editOrAdd;
        private ObservableCollection<Student> oc;

        //Constructor
        public EditStudent(string editOrAdd)
        {
            InitializeComponent();
            
            //EditOrAdd is used to determine which operation the user is
            //trying to perform and therefore decide which controls to
            //show to the user.
            if (editOrAdd.ToLower() != "edit" && editOrAdd.ToLower() != "add")
            {
                throw new KeyNotFoundException();
            }

            this.editOrAdd = editOrAdd;
            selectedStudent = new Student();

            if (EditOrAdd == "add")
            {
                deleteStudent.Visibility = Visibility.Hidden;
                Header.Content = "Add Student";
            }

            oc = FindResource("myStudentList") as ObservableCollection<Student>;

        }
        
        //Properties
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                UpdateTextBox();
            }
        }
        public string EditOrAdd
        {
            get { return editOrAdd.ToLower(); }
            set { editOrAdd = value; }
        }

        //Events
        public void OnSaveClick(object sender, RoutedEventArgs e)
        {
            string sMatric = studentMatric.Text;
            string sFName = studentFirstName.Text;
            string sLName = studentLastName.Text;
            string sCom1 = com1.Text;
            string sCom2 = com2.Text;
            string sCom3 = com3.Text;
            
            //Validate all the user's input
            if (ValidateStudent(sMatric, sFName, sLName, sCom1, sCom2, sCom3))
            {
                selectedStudent.Matriculation = sMatric;
                selectedStudent.FirstName = sFName;
                selectedStudent.LastName = sLName;
                selectedStudent.Component1 = sCom1;
                selectedStudent.Component2 = sCom2;
                selectedStudent.Component3 = sCom3;

                if (EditOrAdd == "add")
                {
                    selectedStudent.FinalGradeCalc();
                    oc.Add(selectedStudent);
                }
                OnStudentAltered(EditOrAdd);
            } else{
                MessageBox.Show("Some details you entered are invalid, please check the highlighted boxes. Hover over textboxes for more information.");
            }


        }
        public void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Delete this student from the database?", "Delete Student", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                oc.Remove(selectedStudent);
                OnStudentAltered("delete");
            }
        }

        //Displays a thick red border around a textbox with invalid input
        public void OnLostFocus(object sender, RoutedEventArgs e)
        {
            //Grab the textbox that sent the lostfocus event
            TextBox tb = (TextBox)e.Source;
            bool validated;

            //Perform the appropriate validation depending on the textbox
            switch (tb.Name)
            {
                case "studentMatric":
                    validated = ValidateMatriculation(tb.Text);
                    break;
                case "studentFirstName":
                case "studentLastName":
                    validated = ValidateName(tb.Text);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (!validated)
            {
                tb.BorderBrush = Brushes.Red;
                tb.BorderThickness = new Thickness(2);
            }
            else
            {
                tb.ClearValue(Border.BorderBrushProperty);
                tb.ClearValue(Border.BorderThicknessProperty);
            }
        }

        //Create event when editing, adding or deleting student
        public event EventHandler<StudentEventArgs> StudentAltered;

        protected virtual void OnStudentAltered(string operation)
        {
            EventHandler<StudentEventArgs> localStudentAltered = StudentAltered;
            if (localStudentAltered != null)
            {
                if (operation == "edit")
                {
                    selectedStudent.FinalGradeCalc();
                }
                StudentEventArgs args = new StudentEventArgs() { SelectedStudent = selectedStudent, Operation = operation };
                StudentAltered(this, args);
            }
        }

        //Methods
        public void UpdateTextBox()
        {
            studentMatric.Text = selectedStudent.Matriculation;
            studentFirstName.Text = selectedStudent.FirstName;
            studentLastName.Text = selectedStudent.LastName;
            com1.Text = selectedStudent.Component1;
            com2.Text = selectedStudent.Component2;
            com3.Text = selectedStudent.Component3;
        }

        //Validate the student
        public bool ValidateStudent(string matric, string firstName, string lastName, string com1, string com2, string com3)
        {
            if (!ValidateMatriculation(matric))
            {
                return false;
            } else if (!ValidateName(firstName) || !ValidateName(lastName))
            {
                return false;
            } else if (!ValidateGrade(com1) || !ValidateGrade(com2) || !ValidateGrade(com3))
            {
                return false;
            }
            return true;
        }

        //Validation Methods
        public bool ValidateMatriculation(string matric)
        {
            if (matric.Length != 7 || !Regex.IsMatch(matric, "^[0-9]+$"))
            {
                return false;
            }
            return true;
        }
        public bool ValidateName(string name)
        {
            if (!Regex.IsMatch(name, "^[a-zA-Z '-]+$") || name.Length > 50 )
            {
                return false;
            }
            return true;
        }
        public bool ValidateGrade(string component)
        {
            if (!Regex.IsMatch(component, "[ABCDEF]"))
            {
                return false;
            }
            return true;
        }
    }
}