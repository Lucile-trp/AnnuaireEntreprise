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
    /// Logique d'interaction pour UpdateSite.xaml
    /// </summary>
    public partial class UpdateSite : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public UpdateSite()
        {
            InitializeComponent();
            BindingSite();
        }

        public void BindingSite()
        {
            _context.Database.EnsureCreated();
            comboBoxSiteUpdate.ItemsSource = _context.Sites.ToList();
        }

        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            string choice = ValueInput.Text;
            if(choice != "")
            {
                int id = (int)comboBoxSiteUpdate.SelectedValue;

                try
                {
                    _context.Database.EnsureCreated();
                    Sites site = _context.Sites.Where(o => o.Id_site == id).SingleOrDefault();
                    site.Name_site = choice;
                    _context.SaveChanges();
                    MessageBox.Show("Le Site à bien été Modifié.", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;

                }
                catch (Exception)
                {
                    MessageBox.Show("Une Erreur s'est produite pendant la procédure", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            } else
            {
                MessageBox.Show("Veuillez renseigner un nom de Site Valide.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
