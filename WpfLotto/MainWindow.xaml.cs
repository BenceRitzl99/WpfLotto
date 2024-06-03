﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLotto.Data;

namespace WpfLotto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HashSet<int> Bet;
        Context db;
        public MainWindow()
        {
            InitializeComponent();
            Bet = new HashSet<int>();
            db = new Context();
            DrawCheckBox();

            
        }

        private void DrawCheckBox()
        {
            for (int i = 1; i < 91; i++)
            {
                CheckBox box = new CheckBox();
                box.Content = i.ToString();
                box.Tag = i;
                box.Click += new RoutedEventHandler(CheckBox_Checked);
                
                box.Style = (Style)Application.Current.Resources["BetboxStyle"];
                TippPanel.Children.Add(box);
            }
        }

        private void ChBoxTilt()
        {
            foreach (CheckBox item in TippPanel.Children)
            {
                if (item.IsChecked == false) item.IsEnabled = false;
                
            }
        } 
        private void ChBoxEnged()
        {
            foreach (CheckBox item in TippPanel.Children)
            {
                item.IsEnabled = true;
                
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            //MessageBox.Show(box.Content.ToString());
            if (box.IsChecked == true)
            {
                Bet.Add((int)box.Tag);
                if (Bet.Count == 5) 
                {
                    ChBoxTilt();
                }
            }
            else
            {
                Bet.Remove((int)box.Tag);
                
                if (Bet.Count == 4) ChBoxEnged();
                
            }
            Tippek.Text = "Tippek:\n" + String.Join(",", Bet);
        }

        private void Button_ClickSorsol(object sender, RoutedEventArgs e)
        {
            if (Bet.Count == 5)
            {
                HashSet<int> sorsolt = new HashSet<int>();
                Random rnd = new Random();
                do
                {
                    sorsolt.Add(rnd.Next(1, 91));
                }
                while (sorsolt.Count < 5);

                Sorsolas.Text = "Sorsolás:\n" + String.Join(",", sorsolt);

                db.Sorsolasok.Add(new Models.Sorsolas(sorsolt));
                db.SaveChanges();

                Eredmeny.Text = "Eredmeny:\n" + String.Join (",", Bet.Intersect(sorsolt));
            }
        }
    }
}
