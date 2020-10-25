
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using PskovUniversityCase.DbEntities;
using PskovUniversityCase.EmployerResourses;
using System.Linq;

namespace PskovUniversityCase
{
	/// <summary>
	/// Interaction logic for OrganizationRegistrationPage.xaml
	/// </summary>
	public partial class OrganizationRegistrationPage : Page
	{
		Organization organization;
		
		byte[] orgSource;
		public OrganizationRegistrationPage(Organization organization)
		{		
			InitializeComponent();
			
			this.organization = organization;
			
			Application.Current.MainWindow.Height = 300;
			Application.Current.MainWindow.Width = 500;
			
			comboTypeOrg.ItemsSource = DbUsingContext.db.OrganizationType.ToList();
		}
		void ButtonSetImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog imageDialog = new OpenFileDialog();
			imageDialog.Filter = "Файлы изображений (.bmp, .jpg, .png, .jpeg)|*.bmp;*.jpg;*.png;*.jpeg";
			imageDialog.Multiselect = false;
			imageDialog.ShowDialog();
			if (!String.IsNullOrEmpty(imageDialog.FileName)) {
				BitmapImage imageBit = new BitmapImage();
				imageBit.BeginInit();
				imageBit.UriSource = new Uri(imageDialog.FileName);
				imageBit.EndInit();
				//MessageBox.Show("Вы успешно зарегистрировались!","Успех!",MessageBoxButton.OK,MessageBoxImage.Information);
				imageOrg.Source = imageBit;
				orgSource = new byte[imageDialog.FileName.Length];
				orgSource = Encoding.ASCII.GetBytes(imageDialog.FileName);// доработать конверт в байт
			}
		}
		void ButtonAddFromUrl_Click(object sender, RoutedEventArgs e)
		{
			BitmapImage imageBit = new BitmapImage();
			imageBit.BeginInit();
			imageBit.DecodeFailed += imageBit_DecodeFailed;
			imageBit.DownloadFailed += imageBit_DecodeFailed;
			imageBit.UriSource = new Uri(boxUrl.Text);
			imageBit.EndInit();
			imageOrg.Source = imageBit;
			orgSource = new byte[boxUrl.Text.Length]; 
			orgSource = Encoding.ASCII.GetBytes(boxUrl.Text);// доработать конверт в байт
		}

		void imageBit_DecodeFailed(object sender, ExceptionEventArgs e)
		{
			MessageBox.Show("Не удалось вставить изображение, проверьте соединение с интернетом и повторите снова","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
		}
		void ButtonAccept_Click(object sender, RoutedEventArgs e)
		{
			try{
            organization.TypeId = comboTypeOrg.SelectedIndex+1;
            organization.PhotoPath = orgSource;
            DbUsingContext.db.SaveChanges();
            Frames.mainFrame.Navigate(new AuthAndRegPage());
            }
			catch(Exception ex){
			MessageBox.Show("Не удалось зарегистрироваться " + ex.Message,"Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
			}
		}
	}
}