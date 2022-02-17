using System.Windows;

namespace annuaireEntreprise.View
{
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
            
            if (textBoxPassword.Password.ToString() == "AdminPassword" && textBoxUsername.Text == "Admin")
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
