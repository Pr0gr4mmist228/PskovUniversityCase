
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

namespace PskovUniversityCase.EmployerResourses
{
	/// <summary>
	/// Interaction logic for EmployerWatchResponseWindow.xaml
	/// </summary>
	public partial class EmployerWatchResponseWindow : Window
	{
		public EmployerWatchResponseWindow()
		{
			InitializeComponent();
			
			responsesList.ItemsSource = DbUsingContext.db.VacancyResponding.Where(x => x.Status == "AddedToEmployer").ToList();
		}
		void ButtonAcceptStudent_Click(object sender, RoutedEventArgs e)
		{
			int id = Convert.ToInt32(((Button)sender).Tag);
			
			DbUsingContext.db.VacancyResponding.First(x => x.Id == id).Status = "Accepted";
			DbUsingContext.db.SaveChanges();
		}
		void ButtonCancelStudent_Click(object sender, RoutedEventArgs e)
		{
			int id = Convert.ToInt32(((Button)sender).Tag);
			
			DbUsingContext.db.VacancyResponding.First(x => x.Id == id).Status = "Canceled";
			DbUsingContext.db.SaveChanges();
		}
	}
}