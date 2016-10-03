using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApi.Models
{
    interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int studentID);
        void RemoveStudent(int studentID);
        void AddStudent(Student student);
        bool UpdateStudent(Student student);




    }
}
