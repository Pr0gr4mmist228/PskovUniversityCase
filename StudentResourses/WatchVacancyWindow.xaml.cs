
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Linq;
using PskovUniversityCase.DbEntities;

namespace PskovUniversityCase.StudentResourses
{
	/// <summary>
	/// Interaction logic for WatchVacancyWindow.xaml
	/// </summary>
	public partial class WatchVacancyWindow : Window
	{
		public WatchVacancyWindow(Vacancy vac)
		{
			InitializeComponent();
			this.DataContext = vac;
			richTextVac.AppendText(vac.Text);
			
			BitmapImage image = new BitmapImage();
			image.BeginInit();
			image.UriSource = new Uri(Encoding.ASCII.GetString(vac.Organization.PhotoPath));
			image.EndInit();
			
			orgImage.Source = image;
		}
	}
}