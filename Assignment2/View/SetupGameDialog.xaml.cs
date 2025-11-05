using System;
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
using System.Windows.Shapes;

namespace Assignment2.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SetupGameDialog : Window
    {
        public string nameOne;
        public string nameTwo;
        public string playerOneType;
        public string playerTwoType;
        public SetupGameDialog()
        {
            InitializeComponent();

        }
        internal void Button_Clicked(object sender, RoutedEventArgs e)
        {
            var Button = (Button)sender;
            SetupGame();
            this.Close();
        }

        internal void SetupGame()
        {
            nameOne = playerOneName.Text;
            nameTwo = playerTwoName.Text;
        }

        internal void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                if(radioButton.GroupName.ToString() == "playerTypeOne")
                {
                    playerOneType = radioButton.Content.ToString();
                }
                else
                {
                    playerTwoType = radioButton.Content.ToString();
                }
            }
        }
    }
}
