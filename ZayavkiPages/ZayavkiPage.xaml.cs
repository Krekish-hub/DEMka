using DEMka.DataFiles;
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

namespace DEMka.ZayavkiPages
{
    /// <summary>
    /// Логика взаимодействия для ZayavkiPage.xaml
    /// </summary>
    public partial class ZayavkiPage : Page
    {
        public ZayavkiPage()
        {
            InitializeComponent();

            ListViewZayavki.ItemsSource = OdbConnectHelper.entObj.Applications.ToList();

            CmbFiltr.SelectedValuePath = "StatusID";
            CmbFiltr.DisplayMemberPath = "StatusName";
            CmbFiltr.ItemsSource = OdbConnectHelper.entObj.Status.ToList();
        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroup = Convert.ToInt32(CmbFiltr.SelectedValue);
            ListViewZayavki.ItemsSource = OdbConnectHelper.entObj.Applications.Where(x => x.IdApplication == SelectGroup).ToList();
            ListViewZayavki.SelectedIndex = 0;
        }

        private void CreateZayavka_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new ZayavkiAddPage());
        }

        private void BtnFiltr_Click(object sender, RoutedEventArgs e)
        {
            if (SortingPanel.Visibility == Visibility.Visible)
            {
                SortingPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                SortingPanel.Visibility = Visibility.Visible;
            }
        }
    }
}
