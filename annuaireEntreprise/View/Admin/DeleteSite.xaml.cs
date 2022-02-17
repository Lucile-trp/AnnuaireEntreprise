using annuaireEntreprise.DB.Model;
using System.Linq;
using System.Windows;


namespace annuaireEntreprise.View.Admin
{
    /// <summary>
    /// Logique d'interaction pour DeleteSite.xaml
    /// </summary>
    public partial class DeleteSite : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public DeleteSite()
        {
            InitializeComponent();
            BindingSite();
        }

        public void BindingSite()
        {
            _context.Database.EnsureCreated();
            ComboBoxSiteDelete.ItemsSource = _context.Sites.ToList();
        }

        private void ButtonLeave_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            int choice = (int)ComboBoxSiteDelete.SelectedValue;
            _context.Database.EnsureCreated();
            // On regarde si des employés y sont rattachés.

            var ListEmp = _context.Employes.Where(o => o.Id_site == choice).SingleOrDefault();
            if (ListEmp != null)
            {
                MessageBox.Show("impossible de supprimer ce Site car des employés y sont rattachés.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Sites Site = _context.Sites.Where(o => o.Id_site == choice).First();
                _context.Sites.Remove(Site);
                _context.SaveChanges();
                MessageBox.Show("Le Site à bien été supprimé.", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;

            }
        }
    }
}
