using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Models
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();
        private int _nextId = 1;

        public StudentRepository()
        {
           AddStudent(new Student { FirstName = "Nikhil", LastName = "Gumulwar", StudentID = 1001 });
           AddStudent(new Student { FirstName = "Tony", LastName = "Rambo", StudentID = 1002 });

        }
        public void AddStudent(Student student)
        {
            if(student==null)
            {
                throw new ArgumentNullException("student");
            }
            student.StudentID = _nextId++;
            students.Add(student);
            //return students

        }

        public IEnumerable<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudent(int studentID)
        {
            return students.Find(s => s.StudentID == studentID);
        }

        public void RemoveStudent(int studentID)
        {
            students.RemoveAll(s => s.StudentID == studentID);
        }

        public bool UpdateStudent(Student student)
        {
            if(student == null)
            {
                throw new ArgumentNullException("student");
            }
            int ind = students.FindIndex(s => s.StudentID == student.StudentID);
            if(ind==-1)
            {
                return false;
            }
            students.RemoveAt(ind);
            students.Add(student);
            return true;
        }



    }
}