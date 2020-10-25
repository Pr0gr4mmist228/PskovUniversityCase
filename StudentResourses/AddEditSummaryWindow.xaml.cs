
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

namespace PskovUniversityCase.StudentResourses
{
	/// <summary>
	/// Interaction logic for AddEditSummaryWindow.xaml
	/// </summary>
	public partial class AddEditSummaryWindow : Window
	{
		User student;
		
		bool isSummaryExist;
		public AddEditSummaryWindow(User student)
		{
			InitializeComponent();
			
			this.student = student;
			
			if(student.Student.SummaryId != null){
				isSummaryExist = true;
				richSummaryText.AppendText(student.Student.Summary.First().SummaryText);
			} else
				isSummaryExist = false;
		}
		void ButtonSaveSumm_Click(object sender, RoutedEventArgs e)
		{
			if(!isSummaryExist){
			Summary newSummary = new Summary(){
				StudentId = student.Student.Id,
				SummaryText = new TextRange(richSummaryText.Document.ContentStart,richSummaryText.Document.ContentEnd).Text
			};
			DbUsingContext.db.Summary.Add(newSummary);
			DbUsingContext.db.SaveChanges();
			student.Student.SummaryId = newSummary.Id;
			DbUsingContext.db.SaveChanges();
			}
			else{
				student.Student.Summary.First().SummaryText = new TextRange(richSummaryText.Document.ContentStart, richSummaryText.Document.ContentEnd).Text;
				DbUsingContext.db.SaveChanges();
			}
		}
	}
}