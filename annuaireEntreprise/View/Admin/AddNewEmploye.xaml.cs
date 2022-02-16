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
    /// Logique d'interaction pour AddNewEmploye.xaml
    /// </summary>
    public partial class AddNewEmploye : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public AddNewEmploye()
        {
            InitializeComponent();
            BindingServices();
            BindingSite();
        }

        public void BindingServices()
        {
            _context.Database.EnsureCreated();
            ComboBoxServices.ItemsSource = _context.Services.ToList();
        }

        public void BindingSite()
        {
            _context.Database.EnsureCreated();
            ComboBoxSites.ItemsSource = _context.Sites.ToList();
        }

        private void ButtonAddEmp_Click(object sender, RoutedEventArgs e)
        {
            if (InputFirstName.Text != null && InputLastName.Text != null && InputEmail.Text != null && InputPhoneNumber.Text != null)
            {
                try
                {
                    _context.Database.EnsureCreated();

                    Employes newEmp = new Employes();
                    newEmp.FirstName_employe = InputFirstName.Text;
                    newEmp.LastName_employe = InputLastName.Text;
                    newEmp.PhoneNumber_employe = InputPhoneNumber.Text;
                    newEmp.Email_employe = InputEmail.Text;
                    newEmp.Id_service = (int) ComboBoxServices.SelectedValue;
                    newEmp.Id_site = (int) ComboBoxSites.SelectedValue;

                    newEmp.FixeNumber_employe = (InputFixeNumber != null) ? InputFixeNumber.Text : "Non renseigné";

                    _context.Employes.Add(newEmp);
                    _context.SaveChanges();
                    MessageBox.Show("Nouvel employé ajouté", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;

                } catch (Exception)
                {
                    MessageBox.Show("Erreur lors de la procédure", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Les informations necessaire ne sont pas fournies", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
