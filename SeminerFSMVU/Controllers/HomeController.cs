using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SeminerFSMVU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			if (MemoryCache.Default.Get("StudentList") == null)
			{
				//var data = GetStudentList().Result;
				var data = GetDataList<Student>(null).Result;
				MemoryCache.Default.Set("StudentList", data, DateTime.Now.AddMinutes(1));
			}
			var model = MemoryCache.Default.Get("StudentList");
            return View (model);
        }
		public ActionResult Detail(int ID)
		{ 
			if (MemoryCache.Default.Get("StudentDetail"+ID) == null)
			{
				var data = GetDataList<Lesson>(ID).Result;
				MemoryCache.Default.Set("StudentDetail" + ID, data, DateTime.Now.AddMinutes(1));
			}
			var model = MemoryCache.Default.Get("StudentDetail" + ID);
			return View(model);
		}

		//public async Task<List<Student>> GetStudentList()
		//{ 
		//	using (HttpClient client = new HttpClient())
		//	{
		//		var response = await client.GetAsync("http://localhost:1453/api/data");
		//		var data = JsonConvert.DeserializeObject<List<Student>>(response.Content.ReadAsStringAsync().Result);
		//		return data;
		//	}
		//}
		//public async Task<List<Lesson>> GetStudentDetail(int ID)
		//{
		//	using (HttpClient client = new HttpClient())
		//	{
		//		var response = await client.GetAsync("http://localhost:1453/api/data/"+ID);
		//		var data = JsonConvert.DeserializeObject<List<Lesson>>(response.Content.ReadAsStringAsync().Result);
		//		return data;
		//	}
		//}

		//public async Task<List<T>>GetDataList<T>(int? ID)
		//{ 
		//	using (HttpClient client = new HttpClient())
		//	{
		//		var response = await client.GetAsync("http://localhost:1453/api/data/"+ID);
		//		var data = JsonConvert.DeserializeObject<List<T>>(response.Content.ReadAsStringAsync().Result);
		//		return data;
		//	}
		//}

		public async Task<List<T>> GetDataList<T>(int? ID)
		{
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync("http://localhost:1453/api/data/" + ID);
				var data = JsonConvert.DeserializeObject<List<T>>(response.Content.ReadAsStringAsync().Result);
				switch (typeof(T).Name)
				{
					case "Student":
						{
							return data.Take(2).ToList();
							break;
						}
					case "Lesson":
						{
							return data;
							break;
						}
					default:
						{
							return null;
						}
				}
			}
		}

    }
}
