using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using PskovUniversityCase.DbEntities;
using System.Text.RegularExpressions;
using PskovUniversityCase.StudentResourses;
using System.Threading.Tasks;
using System.Threading;

namespace PskovUniversityCase
{
	/// <summary>
	/// Interaction logic for RegistrationPage.xaml
	/// </summary>
	public partial class RegistrationPage : Page
	{
		ComboBox studentComboBox;
		TextBox textBoxOrganization;
		public RegistrationPage()
		{
			InitializeComponent();
			comboBoxRolesList.ItemsSource = DbUsingContext.db.Role.ToList();
			BitmapImage image = new BitmapImage();
			image.BeginInit();
			image.UriSource = new Uri(Environment.CurrentDirectory + @"\Images\questionmark.png");
			image.EndInit();
			
			imageQuestion.Source = image;
		}
		void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			Frames.mainFrame.GoBack();
		}
		void ButtonRegister_Click(object sender, RoutedEventArgs e)
		{
			if (String.IsNullOrEmpty(textboxLogin.Text) || String.IsNullOrEmpty(textboxName.Text) || comboBoxRolesList.SelectedValue == null) {
				MessageBox.Show("Пожалуйста, заполните все поля!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
			} 
			else if(DbUsingContext.db.User.Count(i => i.Login == textboxLogin.Text) == 0){
				
				if (comboBoxRolesList.SelectedIndex == 0) {
					User newUser = new User{
						Login = textboxLogin.Text,
						Name = textboxName.Text,
						Password = textboxPassword.Password,
						RoleId = comboBoxRolesList.SelectedIndex + 1
					};
					DbUsingContext.db.User.Add(newUser);
					DbUsingContext.db.SaveChanges();
					Student newStudent = new Student{
						Id=newUser.Id,
						GroupId = studentComboBox.SelectedIndex + 1
					};
					DbUsingContext.db.Student.Add(newStudent);
					DbUsingContext.db.SaveChanges();
					Frames.mainFrame.Navigate(new AuthAndRegPage());
					MessageBox.Show("Вы успешно зарегистрировались!","Успех!",MessageBoxButton.OK,MessageBoxImage.Information);
				}
				else{
						Organization newOrganization = new Organization{
						Name=textBoxOrganization.Text
					};
					
					DbUsingContext.db.Organization.Add(newOrganization);
					DbUsingContext.db.SaveChanges();
					
						User newUser = new User{
						Login = textboxLogin.Text,
						Name = textboxName.Text,
						Password = textboxPassword.Password,
						RoleId = comboBoxRolesList.SelectedIndex + 1,
					};
					
					DbUsingContext.db.User.Add(newUser);
					DbUsingContext.db.SaveChanges();
					
					Employer newEmployer= new Employer{
						Id=newUser.Id,
						OrganizationId = newOrganization.OrganizationId
					};
						
					DbUsingContext.db.Employer.Add(newEmployer);
					DbUsingContext.db.SaveChanges();
					
					Frames.mainFrame.Navigate(new OrganizationRegistrationPage(newOrganization));
				}
			} else
				MessageBox.Show("Такой пользователь уже существует!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
		}
		void TextboxPasswordRepeat_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if(textboxPassword.Password != textboxPasswordRepeat.Password || (String.IsNullOrEmpty(textboxPasswordRepeat.Password) || String.IsNullOrEmpty(textboxPassword.Password)) || !(Regex.Match(textboxPassword.Password,"[0-9]").Success) || textboxPassword.Password.Length < 7){
				textboxPassword.Background = Brushes.Red;
				textboxPasswordRepeat.Background = Brushes.Red;
				buttonRegister.IsEnabled = false;
			} else {
				textboxPassword.Background = Brushes.Green;
				textboxPasswordRepeat.Background = Brushes.Green;
				buttonRegister.IsEnabled = true;
			}
		}
		
		StackPanel panel;

		void ComboBoxRolesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(comboBoxRolesList.SelectedIndex == 0){
				mainPanel.Children.Remove(panel);
				panel = new StackPanel{ Orientation= Orientation.Horizontal, Margin= new Thickness(0,10,0,0)};
				TextBlock text = new TextBlock { Text = "В какой группе Вы обучаетесь?",Width=225};
				studentComboBox = new ComboBox{DisplayMemberPath="Name", ItemsSource=DbUsingContext.db.Group.ToList(),Width=130};
				
				panel.Children.Add(text);
				panel.Children.Add(studentComboBox);
				mainPanel.Children.Add(panel);
			}
			else{
				mainPanel.Children.Remove(panel);
				panel = new StackPanel{ Orientation= Orientation.Horizontal, Margin= new Thickness(0,10,0,0)};
				TextBlock text = new TextBlock { Text = "Какую организацию вы представляете ?",Width=225};
				textBoxOrganization = new TextBox{Width=130,Height=30};
				
				panel.Children.Add(text);
				panel.Children.Add(textBoxOrganization);
				mainPanel.Children.Add(panel);
			}
		}
	}
}