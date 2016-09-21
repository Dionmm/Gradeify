/// Author: Dion MacIntyre
/// Date: 31/03/2016
/// Application to add, calculate and track students' grades

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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Init
        private DisplayStudents dis1;
        private Student selectedStudent;
        private Model1 context;
        private IQueryable<Student> all; //Will contain an object of all students in the database, used for clearing all
        private StudentList oc;
        private StudentList passedStudents;
        private StudentList failedStudents;

        //Set variables to calculate percentage passed
        private int totalCounter;
        private int passedCounter;

        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            dis1 = new DisplayStudents();
            selectedStudent = null;
            context = new Model1();
            passedStudents = new StudentList();
            failedStudents = new StudentList();
        }
        //Properties
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set { selectedStudent = value; }
        }

        //Window Loaded
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Find the resource
            oc = FindResource("myStudentList") as StudentList;

            //Query for all students
            all = from student in context.Students
                        select student;

            totalCounter = 0;
            passedCounter = 0;

            //Add students to resource and count how many students
            foreach (var result in all)
            {
                oc.Add(result);
                totalCounter++;
            }
            
            //Count students that have achieved either an A, B, C or D passing grade
            foreach (var student in oc)
            {
                if (student.gradePassed(student.FinalGrade))
                {
                    studentPassed(student);
                }
                else
                {
                    studentFailed(student);
                };
            }
            PercentPassedCalc(totalCounter, passedCounter);

            //Displays the listbox, labels, etc. in the frame
            Main.Content = dis1;

        }

        //Button Clicks
        public void OnAddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                EditStudent add1 = new EditStudent("Add");
                Main.Content = add1;
                add1.StudentAltered += this.OnStudentAltered;
                //show back button
                backButton.Visibility = Visibility.Visible;
            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            e.Handled = true;
        }
        public void OnEditClick(object sender, RoutedEventArgs e)
        {
            try
            {
                EditStudent edi1 = new EditStudent("Edit");
                edi1.SelectedStudent = selectedStudent;
                selectedStudent.PropertyChanged += dis1.OnPropertyChanged;
                edi1.StudentAltered += this.OnStudentAltered;
                Main.Content = edi1;
                //Show back button
                backButton.Visibility = Visibility.Visible;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            e.Handled = true;
        }
        public void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Clear all students from the database?", "Delete All", MessageBoxButton.OKCancel);
            //Clear the resource list and use variable all to remove all students 
            if (result == MessageBoxResult.OK)
            {
                context.Students.RemoveRange(all);
                context.SaveChanges();
                oc.Clear();
                passedStudents.Clear();
                failedStudents.Clear();
                totalCounter = 0;
                passedCounter = 0;
                PercentPassedCalc(totalCounter, passedCounter);
                editStudent.IsEnabled = false;
            }
            e.Handled = true;
        }
        public void OnBackClick(object sender, RoutedEventArgs e)
        {
            Main.Content = dis1;

            //Hide back button
            backButton.Visibility = Visibility.Hidden;
            e.Handled = true;
        }

        //Detects which button was pressed and displays the
        //appropriate StudentList while also changing the heading
        public void OnStudentsFilterClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.Source;

            switch (btn.Name)
            {
                case "studentsAll":
                    dis1.studentGrid.DataContext = oc;
                    dis1.Header.Content = "All Students";
                    break;
                case "studentsPassed":
                    dis1.studentGrid.DataContext = passedStudents;
                    dis1.Header.Content = "Passed Students";
                    break;
                case "studentsFailed":
                    dis1.studentGrid.DataContext = failedStudents;
                    dis1.Header.Content = "Failed Students";
                    break;

            }
        }
        
        //Calculate if a student has passed or failed and add to the appropriate StudentList
        //These lists are then used when filtering passed/failed students
        public bool hasStudentPassed(Student student)
        {
            if (Regex.Matches(student.FinalGrade, @"[ABCD]").Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void studentPassed(Student student)
        {
            passedStudents.Add(student);
            passedCounter++;
        }
        public void studentFailed(Student student)
        {
            failedStudents.Add(student);
        }

        //Calculates and sets the percentage of students passed
        public void PercentPassedCalc(int total, int pTotal)
        {
            double percentPassed = 0;

            //Calculate percentage, if no students are in DB this will catch that exception and display 0% passed
            try
            {
                percentPassed = (100 * pTotal) / total;
            }
            catch (DivideByZeroException)
            {
                percentPassed = 0;
            }
            percPassed.Content = Convert.ToString(percentPassed) + "%";

        }

        //When a student is added, edited or deleted
        //remove/add them to appropriate StudentList
        public void OnStudentAltered(object source, StudentEventArgs e)
        {
            try
            {
                dbUpdateOperation(e);
                if (e.Operation == "delete")
                {
                    if (hasStudentPassed(e.SelectedStudent))
                    {
                        passedStudents.Remove(e.SelectedStudent);
                        passedCounter--;
                    }
                    else
                    {
                        failedStudents.Remove(e.SelectedStudent);
                    }
                    totalCounter--;
                }
                else if (e.Operation == "edit")
                {
                    if(e.SelectedStudent.gradeChanged){
                        if (hasStudentPassed(e.SelectedStudent))
                        {
                            failedStudents.Remove(e.SelectedStudent);
                            studentPassed(e.SelectedStudent);
                        }
                        else
                        {
                            passedStudents.Remove(e.SelectedStudent);
                            passedCounter--;
                            studentFailed(e.SelectedStudent);
                        }
                    }
                } else if (e.Operation == "add")
                {
                    if (e.SelectedStudent.gradePassed(e.SelectedStudent.FinalGrade))
                    {
                        studentPassed(e.SelectedStudent);
                    }
                    else
                    {
                        studentFailed(e.SelectedStudent);
                    }
                    totalCounter++;
                }

                PercentPassedCalc(totalCounter, passedCounter);
                backButton.Visibility = Visibility.Hidden;
                Main.Content = dis1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Depending on add, edit or delete, performs a different query
        public void dbUpdateOperation(StudentEventArgs op)
        {
            switch (op.Operation)
            {
                case "add":
                    context.Students.Add(op.SelectedStudent);
                    break;
                case "edit":
                    //Should just jump to savechanges
                    break;
                case "delete":
                    context.Students.Remove(op.SelectedStudent);
                    break;
                default:
                    throw new InvalidOperationException();
            }
            context.SaveChanges();
        }
    }
}
