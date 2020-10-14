
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using PskovUniversityCase.StudentResourses;
using PskovUniversityCase.DbEntities;

namespace PskovUniversityCase.StudentResourses
{
	/// <summary>
	/// Interaction logic for AccountMenu.xaml
	/// </summary>
	public partial class AccountMenu : Page
	{
		public AccountMenu(User student)
		{
			InitializeComponent();
			
			Application.Current.MainWindow.Height = 500;
			Application.Current.MainWindow.Width = 800;
			
			textWelcome.Text += student.Name + "!";
		}
		void buttonWatchVacClick(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new VacancyListPage());
		}
	}
}