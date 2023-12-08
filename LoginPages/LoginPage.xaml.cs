using DEMka.DataFiles;
using DEMka.ZayavkiPages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace DEMka.LoginPages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LinkReg_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new RegistrationPage());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = OdbConnectHelper.entObj.User.FirstOrDefault
                    (
                        x => x.Login == TxtLogin.Text && x.Password == PsbPass.Password
                    );
                if ( userObj == null )
                {
                    pop.IsOpen = true;
                }
                else
                {
                    switch (userObj.RoleID)
                    {
                        case 1:
                            FrameApp.frmObj.Navigate (new ZayavkiPage());
                            break;

                        case 2:
                            MessageBox.Show("Второй");
                            break; 

                        case 3:
                            MessageBox.Show("Третий");
                            break;
                    }   
                }
            }
            catch ( Exception ex ) 
            {
                MessageBox.Show("Критическая сбор в работе приложения:" + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void HidePop_Click(object sender, RoutedEventArgs e)
        {
            pop.IsOpen = false;
        }
    }
}
