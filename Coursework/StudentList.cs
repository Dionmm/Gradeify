using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Coursework
{
    public class StudentList : ObservableCollection<Student>
    {
        public void updateStudent(int id)
        {
            foreach (var student in this)
            {
                if (student.id == id)
                {
                    //this.IndexOf();
                }
            }
        }
    }
}
