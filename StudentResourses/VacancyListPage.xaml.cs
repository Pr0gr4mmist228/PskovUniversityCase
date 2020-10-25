using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.Entity;
using PskovUniversityCase.DbEntities;
using System.Linq;
using System.Collections.ObjectModel;
using System.Globalization;
using System.ComponentModel;
using PskovUniversityCase.StudentResourses;
using System.Windows.Threading;

namespace PskovUniversityCase
{
	/// <summary>
	/// Interaction logic for VacancyListPage.xaml
	/// </summary>
	
	public partial class VacancyListPage : Page
	{
		User student;
		List<Vacancy> vac;
		
		public VacancyListPage(User student)
		{			
			vac = DbUsingContext.db.Vacancy.ToList();
			
			InitializeComponent();
			
			Application.Current.MainWindow.Width=850;
			Application.Current.MainWindow.Height=575;
			
			vacanciesList.ItemsSource = vac;
			
			this.student = student;
			
			textCountVac.Text += " " + vac.Count;
			
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(5);
			timer.Tick += UpdateList;
			timer.Start();
		}
		
		void UpdateList(object sender, object e){
			vacanciesList.ItemsSource = vac;
		}
		
		void ButtonVacancyAcc_Click(object sender, RoutedEventArgs e)
		{
			try{
			int id = Convert.ToInt32(((Button)sender).Tag);
			
			VacancyResponding newResponding = new VacancyResponding{
				VacancyId = id,
				StudentId = student.Student.Id,
				OrganizationId = DbUsingContext.db.Vacancy.Where(x => x.VacancyId == id).First().OrganizationId,
				Status = "AddedToEmployer"
			};
			DbUsingContext.db.VacancyResponding.Add(newResponding);
			DbUsingContext.db.SaveChanges();
				MessageBox.Show("Заявка успешно отправлена работодателю","Успех",MessageBoxButton.OK,MessageBoxImage.Information);
			}
			catch(Exception ex){
				MessageBox.Show("При подаче заявки возникла ошибка: "+ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
			}
		}
		void ButtonBack_Click(object sender, RoutedEventArgs e)
		{
			Frames.mainFrame.GoBack();
			Application.Current.MainWindow.Height = 500;
			Application.Current.MainWindow.Width = 815;
		}
		void RadioSortByDateOld_Checked(object sender, RoutedEventArgs e)
		{
			vacanciesList.ItemsSource = vac.OrderBy(x => x.Date);
		}
		void RadioSortByDateNew_Checked(object sender, RoutedEventArgs e)
		{
			vacanciesList.ItemsSource = vac.OrderByDescending(x => x.Date);
		}
		void RadioSortBySalaryDesc_Checked(object sender, RoutedEventArgs e)
		{
			vacanciesList.ItemsSource = vac.OrderByDescending(x => x.Salary);
		}
		void RadioSortBySalary_Checked(object sender, RoutedEventArgs e)
		{
			vacanciesList.ItemsSource = vac.OrderBy(x => x.Salary);
		}
		void VacanciesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
				if (e.ClickCount > 1) {
				int id = Convert.ToInt32(((StackPanel)sender).Tag);
				Vacancy vac = DbUsingContext.db.Vacancy.Where(x => x.VacancyId == id).First();
				new WatchVacancyWindow(vac).ShowDialog();
			}
		}
	}
}