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

namespace Autonomous_Code_Builder
{
    /// <summary>
    /// Interaction logic for StepConfig.xaml
    /// </summary>
    public partial class StepConfig : Window
    {

        MainWindow MainWindow;

        public StepConfig()
        {
            InitializeComponent();
        }

        public void setMain(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            action.Items.Add("Action 1");
            action.Items.Add("Action 2");

            function.Items.Add("Function 1");
            function.Items.Add("Function 2");
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MainWindow.delete(sender, e);
            close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            int index = MainWindow.pathList.SelectedIndex;
            if (index != -1) MainWindow.pathList.Items[index] = action.SelectedItem.ToString() + ": " + function.SelectedItem.ToString() + " To (" + param1.Text.ToString() + ", " + param2.Text.ToString() + ")" + " at speed " + param3.Text.ToString();
            close();
        }


        private void close()
        {
            MainWindow.buttonAdd.IsEnabled = true;
            MainWindow.buttonEdit.IsEnabled = true;
            this.Close();
        }
    }
}