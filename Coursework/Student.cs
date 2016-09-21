namespace Coursework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Text.RegularExpressions;

    public partial class Student : INotifyPropertyChanged
    {
        //init
        private string matriculation, firstName, lastName, component1, component2, component3, finalGrade;
        public bool gradeChanged;
        public string previousFinalGrade = string.Empty;

        //Constructor
        public Student()
        {
            matriculation = null;
            firstName = null;
            lastName = null;
            component1 = null;
            component2 = null;
            component3 = null;
            finalGrade = null;
            gradeChanged = true;

        }

        //Properties
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(7)]
        public string Matriculation
        {
            get { return matriculation; }
            set
            {
                matriculation = value;
                OnPropertyChanged("Matriculation");
            }
        }

        [Required]
        [StringLength(50)]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        [Required]
        [StringLength(50)]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        [Required]
        [StringLength(1)]
        public string Component1
        {
            get { return component1; }
            set
            {
                component1 = value;
                OnPropertyChanged("Component1");
            }
        }

        [Required]
        [StringLength(1)]
        public string Component2
        {
            get { return component2; }
            set
            {
                component2 = value;
                OnPropertyChanged("Component2");
            }
        }

        [Required]
        [StringLength(1)]
        public string Component3
        {
            get { return component3; }
            set
            {
                component3 = value;
                OnPropertyChanged("Component3");
            }
        }

        [Required]
        [StringLength(1)]
        public string FinalGrade
        {
            get { return finalGrade; }
            set
            {
                finalGrade = value;
                OnPropertyChanged("FinalGrade");
            }
        }

        public bool GradeChanged
        {
            get { return gradeChanged; }
        }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        //Methods
        public void FinalGradeCalc()
        {
            int AGrades = 0;
            int BGrades = 0;
            int CGrades = 0;
            int DGrades = 0;
            int EGrades = 0;
            int[] weighting = new int[] { 3, 5, 2 };
            string[] grades = new string[] { Component1, Component2, Component3 };
            int counter = 0;
            

            if(FinalGrade != null)
            {
                previousFinalGrade = FinalGrade;
            }
            
            foreach (var grade in grades)
            {
                switch (grade)
                {
                    case "A":
                        AGrades += weighting[counter];
                        break;
                    case "B":
                        BGrades += weighting[counter];
                        break;
                    case "C":
                        CGrades += weighting[counter];
                        break;
                    case "D":
                        DGrades += weighting[counter];
                        break;
                    case "E":
                        EGrades += weighting[counter];
                        break;
                    default:
                        break;
                }
                counter++;
            }
            if (AGrades >= 5 && (AGrades + BGrades) >= 7 && (AGrades + BGrades + CGrades) == 10)
            {
                FinalGrade = "A";
            } else if ((AGrades + BGrades) >= 5 && (AGrades + BGrades + CGrades) >= 7 && (AGrades + BGrades + CGrades + DGrades) == 10)
            {
                FinalGrade = "B";
            } else if ((AGrades + BGrades + CGrades) >= 5 && (AGrades + BGrades + CGrades + DGrades) >= 7)
            {
                FinalGrade = "C";
            } else if ((AGrades + BGrades + CGrades + DGrades) >= 5 && (AGrades + BGrades + CGrades + DGrades + EGrades) >= 7)
            {
                FinalGrade = "D";
            } else if ((AGrades + BGrades + CGrades + DGrades + EGrades) >= 7)
            {
                FinalGrade = "E";
            }
            else
            {
                FinalGrade = "F";
            }

            if (previousFinalGrade != string.Empty)
            {
                PassingGradeUpdated(previousFinalGrade);
            }
            
        }

        //This method detects if a grade has been changed from a passing grade
        //to a failing grade or vice versa. Used in MainWindow.xaml.cs to change
        //student from passedStudents StudentList to FailedStudents StudentList
        private void PassingGradeUpdated(string previous)
        {
            if ((gradePassed(previous) && gradePassed(FinalGrade)) || (!gradePassed(previous) && !gradePassed(FinalGrade)))
            {
                gradeChanged = false;
            }
            else
            {
                gradeChanged = true;
            }
        }

        public bool gradePassed(string grade)
        {
            if (Regex.Matches(grade, @"[ABCD]").Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Overrides
        public override string ToString()
        {
            return String.Format("{0} {1} ({2})", FirstName, LastName, FinalGrade);
        }

        //Publisher
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler localPropChanged = PropertyChanged;
            if (localPropChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                localPropChanged(this, args);
            }
        }
    }
}