
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using PskovUniversityCase.DbEntities;
using System.Linq;

namespace PskovUniversityCase.StudentResourses
{
	/// <summary>
	/// Interaction logic for StudentWatchStatusWindow.xaml
	/// </summary>
	public partial class StudentWatchStatusWindow : Window
	{
		public StudentWatchStatusWindow(User student)
		{
			InitializeComponent();
			
			DbEntitiesContext db = new DbEntitiesContext();
			
			List<VacancyResponding> vac = db.VacancyResponding.Where(x =>  x.StudentId == student.Student.Id).ToList();
				
				for (int i = 0; i < vac.Count; i++) {
								
				vac[i].Vacancy.Header = "Название вакансии: " + vac[i].Vacancy.Header;
				vac[i].Organization.Name = "Название организации: " + vac[i].Organization.Name;
				
				if(vac[i].Status == "Canceled"){
					vac[i].Status = "Статус вакансии: Отменено работодателем";
				}
				else if(vac[i].Status == "Accepted"){
					vac[i].Status = "Статус вакансии: Подтверждено работодателем";
				}
				else if(vac[i].Status == "AddedToEmployer"){
					vac[i].Status = "Статус вакансии: Отправлено работодателю";
				}
			}
			responsesList.ItemsSource = vac;
		}
	}
}