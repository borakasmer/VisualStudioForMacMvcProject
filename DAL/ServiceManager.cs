using System; using System.Collections.Generic;  namespace DAL { 	public class ServiceManager:IDisposable 	{ 		public List<Lesson> LessonList
		{ 			get; 			set; 		} 		public List<Student> StudentList 		{ 			get; 			set; 		} 		public ServiceManager() 		{ 			StudentList = new List<Student>(); 			StudentList.AddRange(new Student[] { 				new Student(){Name="Cem",SurName="Hızlı",ID=1,BirthDate=new DateTime(1982,8,12)}, 				new Student(){Name="Hasan",SurName="Demir",ID=2,BirthDate=new DateTime(1985,3,20)}, 				new Student(){Name="Demir",SurName="Büer",ID=3,BirthDate=new DateTime(2000,1,17)}, 				new Student(){Name="Veli",SurName="Yapar",ID=4,BirthDate=new DateTime(1978,6,3)}, 				new Student(){Name="Emin",SurName="Çlışkan",ID=5,BirthDate=new DateTime(1993,4,18)} 				}); 			LessonList = new List<Lesson>(); 			LessonList.AddRange(new Lesson[] { 				new Lesson(){Name="Matematik",ID=1,StudentID=1}, 				new Lesson(){Name="Fen",ID=2,StudentID=1}, 				new Lesson(){Name="Kimya",ID=3,StudentID=2}, 				new Lesson(){Name="Beden",ID=4,StudentID=2}, 				new Lesson(){Name="Muzik",ID=5,StudentID=3}, 				new Lesson(){Name="Bioyloji",ID=6,StudentID=3}, 				new Lesson(){Name="Felsefe",ID=7,StudentID=4}, 				new Lesson(){Name="Din",ID=8,StudentID=4}, 				new Lesson(){Name="Milli Güvenlik",ID=9,StudentID=5}, 				new Lesson(){Name="Edebiyat",ID=10,StudentID=5} 				}); 		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~ServiceManager() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			 GC.SuppressFinalize(this);
		}
		#endregion
	} } 