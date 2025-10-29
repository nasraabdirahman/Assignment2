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

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SetupGameDialog : Window
    {
        internal string nameOne;
        internal string nameTwo;
        internal string playerTypeOne;
        internal string playerTypeTwo;
        public SetupGameDialog()
        {
            //InitializeComponent();

        }
        internal void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.IsChecked == true)
            {
                if(radioButton.GroupName.ToString() == "playerTypeOne")
                {
                    playerTypeOne = radioButton.Content.ToString();
                }
                else
                {
                    playerTypeTwo = radioButton.Content.ToString();
                }
            }
            else
            {
            }
        }
    }
}
