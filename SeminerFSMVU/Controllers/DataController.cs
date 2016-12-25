using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DAL;

namespace SeminerFSMVU.Controllers
{
    public class DataController : ApiController
    {
		public List<DAL.Student> Get()
		{
			using (ServiceManager service = new ServiceManager())
			{
				return service.StudentList;
			}
		}

		public List<DAL.Lesson> Get(int ID)
		{ 
			using (ServiceManager service = new ServiceManager())
			{
				return service.LessonList.Where(le => le.StudentID == ID).ToList();
			}
		}
    }
}
