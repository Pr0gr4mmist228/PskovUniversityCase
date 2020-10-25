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

namespace PskovUniversityCase
{
	/// <summary>
	/// Interaction logic for AuthAndRegPage.xaml
	/// </summary>
	public partial class AuthAndRegPage : Page
	{
		public AuthAndRegPage()
		{
			InitializeComponent();
			
			Application.Current.MainWindow.Width=550;
			Application.Current.MainWindow.Height=518;
		}
		
		void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			Frames.mainFrame.Navigate(new RegistrationPage());
		}
		void ButtonAuth_Click(object sender, RoutedEventArgs e)
		{
			if(!String.IsNullOrEmpty(textboxLogin.Text) && !String.IsNullOrEmpty(textboxPassword.Password)){
				var user = DbUsingContext.db.User.FirstOrDefault(x => x.Login == textboxLogin.Text && x.Password == textboxPassword.Password);
				if(user != null){
					switch(user.RoleId){
						case 1:
							Frames.mainFrame.Navigate(new StudentResourses.AccountMenu(user));
						break;
						
						case 2:
						Frames.mainFrame.Navigate(new EmployerResourses.EmployerAccountMenu(user));
						break;
					}
			} else
					MessageBox.Show("Данные указаны неверно или такого пользователя не существует!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
				}
			else
				MessageBox.Show("Заполните все поля!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
		}
	}
}