
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
	/// Interaction logic for SettingsWindow.xaml
	/// </summary>
	public partial class SettingsWindow : Window
	{
		User employer;
		public SettingsWindow(User employer)
		{
			InitializeComponent();
			
			this.employer =employer;
			
			comboOrgType.ItemsSource = DbUsingContext.db.OrganizationType.ToList();
			
			this.DataContext = DbUsingContext.db.User.Where(x => x.Employer.Id == employer.Id).ToList();
			
			comboOrgType.SelectedIndex = Convert.ToInt32(employer.Employer.Organization.TypeId-1);
		}
		// пароль нужно добавлять туда и в StudentsSettings toje
		void ButtonChangeData_Click(object sender, RoutedEventArgs e)
		{
			try{
			employer.Login = boxLogin.Text;
			employer.Name = boxName.Text;
			employer.Employer.Organization.Name = boxNameOrg.Text;
			employer.Employer.Organization.TypeId = comboOrgType.SelectedIndex + 1;
			employer.Employer.Email = boxEmail.Text;
			employer.Employer.Phone = boxPhone.Text;
			DbUsingContext.db.SaveChanges();
			MessageBox.Show("Настройки успешно изменены","Успех!",MessageBoxButton.OK,MessageBoxImage.Information);
			Close();
			}
			catch(Exception ex){
				MessageBox.Show("Ошибка при изменении настроек "+ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
			}
		}
	}
}