
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using PskovUniversityCase.DbEntities;
using PskovUniversityCase.EmployerResourses;
using PskovUniversityCase.StudentResourses;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace PskovUniversityCase.EmployerResourses
{
	/// <summary>
	/// Interaction logic for EmployerAccountMenu.xaml
	/// </summary>
	public partial class EmployerAccountMenu : Page
	{
		User employer;
		public EmployerAccountMenu(User employer)
		{
			InitializeComponent();
			
			this.employer = employer;
			
			Application.Current.MainWindow.Height = 500;
			Application.Current.MainWindow.Width = 800;
			Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			textWelcome.Text += employer.Name;
		}
		void buttonAddVacancyClick(object sender, RoutedEventArgs e)
		{
			new AddVacancyWindow(employer).ShowDialog();
		}
	}
}