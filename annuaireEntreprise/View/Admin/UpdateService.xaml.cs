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
    public partial class UpdateService : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public UpdateService()
        {
            InitializeComponent();
            BindingServices();
        }
        public void BindingServices()
        {
            _context.Database.EnsureCreated();
            comboBoxUpdateService.ItemsSource = _context.Services.ToList();
        }

        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            string choice = ValueInput.Text;
            int id = (int)comboBoxUpdateService.SelectedValue;
            if(choice != "")
            {
                try
                {
                    _context.Database.EnsureCreated();
                    Services services = _context.Services.Where(o => o.Id_service == id).SingleOrDefault();
                    services.Name_service = choice;
                    _context.SaveChanges();
                    MessageBox.Show("Le Service à bien été Modifié.", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;

                }
                catch (Exception)
                {
                    MessageBox.Show("Une Erreur s'est produite pendant la procédure", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            } else
            {
                MessageBox.Show("Veuillez renseigner un nom de Service Valide.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void ButtonLeave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
