
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Linq;
using PskovUniversityCase.DbEntities;
using PskovUniversityCase.EmployerResourses;
using PskovUniversityCase.StudentResourses;

namespace PskovUniversityCase.StudentResourses
{
	/// <summary>
	/// Interaction logic for StudentSettingsWindow.xaml
	/// </summary>
	public partial class StudentSettingsWindow : Window
	{
		User student;
		public StudentSettingsWindow(User student)
		{
			InitializeComponent();
			this.student = student;
			
			comboGroups.ItemsSource = DbUsingContext.db.Group.ToList();
			comboGroups.SelectedIndex = Convert.ToInt32(student.Student.Group.Id-1);
			
			DataContext = DbUsingContext.db.User.ToList();
		}
		void ButtonChangeData_Click(object sender, RoutedEventArgs e)
		{
			student.Login = boxLogin.Text;
			student.Name = boxName.Text;
			student.Student.GroupId = comboGroups.SelectedIndex + 1;
			DbUsingContext.db.SaveChanges();
		}
	}
}