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

namespace annuaireEntreprise.View
{
    /// <summary>
    /// Logique d'interaction pour AdminAuth.xaml
    /// </summary>
    public partial class AdminAuth : Window
    {
        public AdminAuth()
        {
            InitializeComponent();
        }

        private void ButtonConnection_Click(object sender, RoutedEventArgs e)
        {
            PasswordVerify();

        }

        //Fonction Validation du mot de passe
        public void PasswordVerify()
        {

            if (textBoxPassword.Text == "AdminPassword" && textBoxUsername.Text == "Admin")
            {

                DialogResult = true;

            }
            else
            {
                MessageBox.Show("Mot de passe incorrect", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
