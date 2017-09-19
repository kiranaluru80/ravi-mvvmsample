using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace ReadDataFromJson
{
	public class ReadDataViewModel : ViewModelBase
	{

		public List<RootObjectSecond> RootObjectSe => rootObjectSe;
		List<RootObjectSecond> rootObjectSe = new List<RootObjectSecond>();


		RootObjectSecond selectedMajorGroup;
		public RootObjectSecond SelectedMajorGroup
		{
			get { return selectedMajorGroup; }
			set
			{
				if (selectedMajorGroup != value)
				{
					selectedMajorGroup = value;
					OnPropertyChanged();
					OnPropertyChanged("SelectedMajorGroup");
				}
			}
		}



		public ReadDataViewModel()
		{
			
			var assembly = typeof(ReadDataViewModel).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("ReadDataFromJson.getbannerdata.json");

			using (var reader = new System.IO.StreamReader(stream))
			{
				var json = reader.ReadToEnd();
				List<RootObjectSecond> data = JsonConvert.DeserializeObject<List<RootObjectSecond>>(json);

				for (int i = 0; i < data.Count; i++)
				{
					RootObjectSecond dataObject = data[i];
					Debug.WriteLine("First Major ID :" +i + "= " +dataObject.MajorGroup_Id);
					Debug.WriteLine("First Major Name :" +i + "= " +dataObject.MajorGroup_Name);
					rootObjectSe.Add(dataObject);
					List<Organization> organizationData = dataObject.Organizations;
					for (int j = 0; j < organizationData.Count; j++)
					{
						Organization orgData = organizationData[j];
						Debug.WriteLine("Organization ID :" +j + "= " +orgData.Org_Id);
						Debug.WriteLine("Organization Name :" +j + "= " +orgData.Org_Name);

						List<Department> departMentData = orgData.Departments;
						for (int k = 0; k < departMentData.Count; k++)
						{
							Department deptData = departMentData[k];
							Debug.WriteLine("Dept ID :" + k + "= " + deptData.Dept_Id);
							Debug.WriteLine("Dept Name :" + k + "= " + deptData.Dept_Name);

							List<Section> sectionData = deptData.Sections;
							for (int l = 0; l < sectionData.Count; l++)
							{
								Section sectionsData = sectionData[l];
								Debug.WriteLine("Section ID :" +l+ "= " + sectionsData.Section_Id);
								Debug.WriteLine("Section Name :" +l + "= " + sectionsData.Section_Name);
							}

						}



					}


				}
			}



		}
	}
}
