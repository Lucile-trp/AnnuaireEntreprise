using annuaireEntreprise.DB.Model;
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

namespace annuaireEntreprise.View.Admin
{
    /// <summary>
    /// Logique d'interaction pour AddNewSite.xaml
    /// </summary>
    public partial class AddNewSite : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public AddNewSite()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (InputSiteText.Text != null)
            {
                _context.Database.EnsureCreated();

                // Verification du duplicat de la donnée
                if (_context.Sites.Where(se => se.Name_site == InputSiteText.Text).Count() > 0)
                {
                    MessageBox.Show($"Le site : {InputSiteText.Text} existe déjà", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Sites NewSite = new Sites();
                NewSite.Name_site = InputSiteText.Text;

                try
                {
                    _context.Sites.Add(NewSite);
                    _context.SaveChanges();
                    MessageBox.Show($"Nouveau Site : {InputSiteText.Text} disponible", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Une erreur s'est produite lors de la procédure. Veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Votre champ est vide. Veuillez insérer du texte", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
