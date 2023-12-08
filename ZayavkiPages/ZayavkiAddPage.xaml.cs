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
    /// Логика взаимодействия для ZayavkiAddPage.xaml
    /// </summary>
    public partial class ZayavkiAddPage : Page
    {
        public ZayavkiAddPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Applications appObj = new Applications()
                {
                    NameApp = TxtNameApp.Text,
                    Descroption = TxtDescription.Text,
                    DateAdd = System.DateTime.Now,
                    IdStatus = 3
                };
                OdbConnectHelper.entObj.Applications.Add(appObj);
                OdbConnectHelper.entObj.SaveChanges();
                pop.IsOpen = true;
            }
            catch
            { 
            
            }
        }
    }
}
