using annuaireEntreprise.View;
using annuaireEntreprise.View.Admin;
using System;
using System.Windows;
using System.Windows.Input;

namespace annuaireEntreprise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Boolean IsAdminAuth = false;

        public MainWindow()
        {

            InitializeComponent();
            MainContent.Content = new Annuaire(IsAdminAuth);
        }

        // Ouverture de la page de connexion Administrateur
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F5)
            {
                var newWindows = new AdminAuth();
                var result = newWindows.ShowDialog();

                IsAdminAuth =  (result == true) ? true : false;
                ButtonDisconnect.Visibility = (IsAdminAuth) ? Visibility.Visible : Visibility.Hidden;
                MainContent.Content = new Annuaire(IsAdminAuth);
            }

        }

        // Se déconnecter // ADMIN ONLY
        private void ButtonDisconnect_Click(object sender, RoutedEventArgs e)
        {
            IsAdminAuth = false;
            ButtonDisconnect.Visibility = (IsAdminAuth) ? Visibility.Visible : Visibility.Hidden;
            MainContent.Content = new Annuaire(IsAdminAuth);

        }
    }
}
