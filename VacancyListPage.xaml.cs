
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

namespace PskovUniversityCase
{
	/// <summary>
	/// Interaction logic for VacancyListPage.xaml
	/// </summary>
	/// 
	
	public partial class VacancyListPage : Page
	{
		public VacancyListPage()
		{
			InitializeComponent();
			
			VacancyLoad();
		}
		void VacancyLoad()
		{
				var vacancies = DbUsingContext.db.Vacancy;

				foreach (var vac in vacancies) {
					TextBlock text = new TextBlock();
					Button butt = new Button{ Height = 80, Content = text.Text=vac.Header + "\n" + vac.Text};
										text.TextAlignment = TextAlignment.Center;
					text.VerticalAlignment = VerticalAlignment.Center;
				text.HorizontalAlignment = HorizontalAlignment.Center;
					butt.Click += butt_Click;
					stackPan.Children.Add(butt);
			}
		}

		void butt_Click(object sender, RoutedEventArgs e)
		{
			string content = ((Button)sender).Content.ToString();
			MessageBox.Show(content);
		}
	}
}