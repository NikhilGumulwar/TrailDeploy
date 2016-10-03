using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    //[Route("api/[controller]")]
    public class StudentsController : ApiController
    {

        static IStudentRepository repo = new StudentRepository();
     
        public IEnumerable<Student> GetStudents()
        {
            return repo.GetAllStudents();
        }
        
       // [HttpGet(Name = "GetAllStudent")]
        public Student GetStudentById(int id)
        {
            Student stud = repo.GetStudent(id);
            if(stud == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return stud;
        }
        public HttpResponseMessage PostStudent(Student student)
        {
            /////
             repo.AddStudent(student);
            var response = Request.CreateResponse<Student>(HttpStatusCode.Created, student);

            string uri = Url.Link("DefaultApi", new { id = student.StudentID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutStudent(int id,Student Student)
        {
            Student.StudentID = id;
            if(repo.UpdateStudent(Student))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
          
        }
        public void DeleteStudent(int id)
        {
            repo.RemoveStudent(id);
        }
    }
}
