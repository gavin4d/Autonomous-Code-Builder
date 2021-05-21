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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Autonomous_Code_Builder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        static string blankName = "No Info";
        byte side = 0;
        static readonly string[] buttonSideNames = {"Side: Red", "Side: Blue"};

        public MainWindow()
        {
            InitializeComponent();
            pathList.SelectionMode = SelectionMode.Single;
        }

        private void add(object sender, RoutedEventArgs e)
        {
            buttonAdd.IsEnabled = false;
            buttonEdit.IsEnabled = false;
            int index = pathList.Items.IndexOf(pathList.SelectedItem);
            pathList.Items.Insert(index + 1, blankName);

            pathList.SelectedIndex = index + 1;

            edit(sender, e);

        }
        
        private void edit(object sender, RoutedEventArgs e)
        {
            if (pathList.SelectedItem != null)
            {
                StepConfig stepConfig = new StepConfig();
                stepConfig.setMain(this);
                stepConfig.Show();
            }
        }

        public void delete(object sender, RoutedEventArgs e)
        {
            int index = pathList.Items.IndexOf(pathList.SelectedItem);
            if (index != -1)
            {
                pathList.Items.RemoveAt(index);
                if (index > 0)
                {
                    pathList.SelectedIndex = index - 1;
                }
                else
                {
                    pathList.SelectedIndex = index;
                }
            }
        }

        private void reorderDown(object sender, RoutedEventArgs e)
        {
            int index = pathList.Items.IndexOf(pathList.SelectedItem);
            if (index < pathList.Items.Count - 1 && index != -1)
            {
                pathList.Items.Insert(index+2, pathList.SelectedItem);
                pathList.Items.RemoveAt(index);
                pathList.SelectedIndex = index + 1;
            }

        }

        private void reorderUp(object sender, RoutedEventArgs e)
        {
            int index = pathList.Items.IndexOf(pathList.SelectedItem);
            if (index > 0)
            {
                pathList.Items.Insert(index - 1, pathList.SelectedItem);
                pathList.Items.RemoveAt(index + 1);
                pathList.SelectedIndex = index - 1;
            }

        }

        private void SwitchSides(object sender, RoutedEventArgs e)
        {
            side++;
            if (side == 2) side = 0;
            Side.Content = buttonSideNames[side];
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            rectangle.Width = rectangle.ActualHeight;
        }
    }
}
