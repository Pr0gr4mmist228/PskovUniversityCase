
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
		User student;
		public AccountMenu(User student)
		{
			InitializeComponent();
			this.student = student;
			
			Application.Current.MainWindow.Height = 500;
			Application.Current.MainWindow.Width = 815;
			
			textWelcome.Text += student.Name + "!";
		}
		void buttonWatchVacClick(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.Navigate(new VacancyListPage(student));
			
		}
		void ButtonSettingsAcc_Click(object sender, RoutedEventArgs e)
		{
			new StudentSettingsWindow(student).ShowDialog();
		}
		void ButtonWatchStatus_Click(object sender, RoutedEventArgs e)
		{
			new StudentWatchStatusWindow(student).ShowDialog();
		}
		void ButtonWatchSummary_Click(object sender, RoutedEventArgs e)
		{
			new AddEditSummaryWindow(student).ShowDialog();
		}
		void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
			Application.Current.MainWindow.Width=550;
			Application.Current.MainWindow.Height=518;
		}
	}
}