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
    /// Logique d'interaction pour DeleteService.xaml
    /// </summary>
    public partial class DeleteService : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public DeleteService()
        {
            InitializeComponent();
            BindingServices();
        }
        public void BindingServices()
        {
            _context.Database.EnsureCreated();
            ComboBoxServicesDelete.ItemsSource = _context.Services.ToList();
        }

        private void ButtonLeave_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            int choice = (int)ComboBoxServicesDelete.SelectedValue;
            _context.Database.EnsureCreated();
            // On regarde si des employés y sont rattachés.

            var ListEmp = _context.Employes.Where(o => o.Id_service == choice).SingleOrDefault();
            if(ListEmp != null)
            {
                MessageBox.Show("impossible de supprimer ce Service car des employés y sont rattachés.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } else
            {
                Services Serv = _context.Services.Where(o => o.Id_service == choice).First();
                _context.Services.Remove(Serv);
                _context.SaveChanges();
                MessageBox.Show("Le Service à bien été supprimé.", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;

            }
        }
    }
}
