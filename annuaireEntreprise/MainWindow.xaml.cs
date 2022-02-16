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



        private void ShowAnnuaire(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Annuaire(IsAdminAuth);


        }


        private void ShowFormEmployeAdd(object sender, RoutedEventArgs e)
        {
            if(IsAdminAuth == true)
            {
                var newWindows = new AddNewEmploye();
                var result = newWindows.ShowDialog();
                MainContent.Content = new Annuaire(IsAdminAuth);

            } else
            {
                MessageBox.Show("Vous n'avez pas les droits", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            

        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.F5)
            {
                var newWindows = new AdminAuth();
                var result = newWindows.ShowDialog();

                IsAdminAuth =  (result == true) ? true : false;
                MainContent.Content = new Annuaire(IsAdminAuth);
            }

        }
    }
}
