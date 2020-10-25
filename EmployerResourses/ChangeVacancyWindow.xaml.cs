
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

namespace PskovUniversityCase.EmployerResourses
{
	/// <summary>
	/// Interaction logic for ChangeVacancyWindow.xaml
	/// </summary>
	public partial class ChangeVacancyWindow : Window
	{
		Vacancy vac;
		public ChangeVacancyWindow(Vacancy vac)
		{
			InitializeComponent();
			this.vac = vac;
			richTextVac.AppendText(vac.Text);
			
			this.DataContext = vac;
			
		}
		void ButtonChangeVacancy_Click(object sender, RoutedEventArgs e)
		{
			try{
			vac.Header = textBoxHeader.Text;
			vac.Salary = decimal.Parse(boxSalary.Text);
			vac.Text = new TextRange(richTextVac.Document.ContentStart, richTextVac.Document.ContentEnd).Text;
			DbUsingContext.db.SaveChanges();
			MessageBox.Show("Вакансия успешно изменена","Успех!",MessageBoxButton.OK,MessageBoxImage.Information);
			Close();
			}
			catch(Exception ex){
				MessageBox.Show("Ошибка при добавлении вакансии "+ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
			}
		}
		void BoxSalary_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = "1234567890".IndexOf(boxSalary.Text) < 0;
		}
	}
}