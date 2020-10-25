﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace PskovUniversityCase
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			
			Frames.mainFrame = mainFrame;
			
			mainFrame.Navigate(new AuthAndRegPage());
			
			DbEntities.DbUsingContext.db = new DbEntities.DbEntitiesContext();
		}
	}
}