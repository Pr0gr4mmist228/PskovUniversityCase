
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
using System.Windows.Media.Imaging;
using System.Linq;

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
			
			Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			Application.Current.MainWindow.Height = 700;
			Application.Current.MainWindow.Width = 855;
			
			vacanciesList.ItemsSource = employer.Employer.Organization.Vacancy.ToList();
			
			this.employer = employer;
			
			textWelcome.Text += employer.Name;
			
			BitmapImage bitImage = new BitmapImage();
			bitImage.BeginInit();
			bitImage.UriSource = new Uri(Encoding.ASCII.GetString(employer.Employer.Organization.PhotoPath));
			bitImage.EndInit();
			imageOrg.Source = bitImage;
		}
		void buttonAddVacancyClick(object sender, RoutedEventArgs e)
		{
			new AddVacancyWindow(employer).ShowDialog();
			vacanciesList.ItemsSource = employer.Employer.Organization.Vacancy.ToList();
		}
		void ButtonWatchResp_Click(object sender, RoutedEventArgs e)
		{
			new EmployerWatchResponseWindow().ShowDialog();
		}
		void ButtonSettings_Click(object sender, RoutedEventArgs e)
		{
			new SettingsWindow(employer).ShowDialog();
		}
		void ButtonVacDelete_Click(object sender, RoutedEventArgs e)
		{
			int vacancyId = Convert.ToInt32(((Button)sender).Tag);
			
			Vacancy vac = DbUsingContext.db.Vacancy.Where(x => x.VacancyId == vacancyId).First();
			
			DbUsingContext.db.Vacancy.Remove(vac);
			DbUsingContext.db.SaveChanges();
			vacanciesList.ItemsSource = employer.Employer.Organization.Vacancy.ToList();
		}
		void ButtonChangeVac_Click(object sender, RoutedEventArgs e)
		{
			int vacancyId = Convert.ToInt32(((Button)sender).Tag);
			
			Vacancy vac = DbUsingContext.db.Vacancy.Where(x => x.VacancyId == vacancyId).First();
			new ChangeVacancyWindow(vac).ShowDialog();
			vacanciesList.ItemsSource = employer.Employer.Organization.Vacancy.ToList();
		}
		void ButtonExitAcc_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
						
			Application.Current.MainWindow.Width=550;
			Application.Current.MainWindow.Height=518;
		}
	}
}