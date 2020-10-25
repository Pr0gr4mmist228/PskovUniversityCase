
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
using PskovUniversityCase.EmployerResourses;
using PskovUniversityCase.StudentResourses;
using System.Linq;
using System.Text.RegularExpressions;

namespace PskovUniversityCase.EmployerResourses
{
	/// <summary>
	/// Interaction logic for AddVacancyWindow.xaml
	/// </summary>
	public partial class AddVacancyWindow : Window
	{
		User employer;
		public AddVacancyWindow(User employer){
			this.employer = employer;
			InitializeComponent();
		}
		void buttonAddVacancy_Click(object sender, RoutedEventArgs e)
		{
			try{
			Vacancy newVacancy = new Vacancy{
					OrganizationId = employer.Employer.OrganizationId,
					EmployerId = employer.Id,
					Header = textBoxHeader.Text,
					Text = new TextRange(richTextBoxText.Document.ContentStart, richTextBoxText.Document.ContentEnd).Text,
					Date = DateTime.Today.Date,
					Salary = decimal.Parse(boxSalary.Text)
				};
			
			DbUsingContext.db.Vacancy.Add(newVacancy);
			DbUsingContext.db.SaveChanges();
			
			MessageBox.Show("Вакансия успешно добавлена","Успех!",MessageBoxButton.OK,MessageBoxImage.Information);
			Close();
			}
			catch(Exception ex){
				MessageBox.Show("Ошибка при создании вакансии "+ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
			}
		}
		void BoxSalary_TextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = "1234567890".IndexOf(e.Text) < 0;
		}
	}
}