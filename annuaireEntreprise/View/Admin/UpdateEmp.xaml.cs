using annuaireEntreprise.DB.Model;
using annuaireEntreprise.DB.ReturnModel;
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
    /// Logique d'interaction pour UpdateEmp.xaml
    /// </summary>
    public partial class UpdateEmp : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();

        private int Id_emp { get; set; }
        public UpdateEmp(int Id, string FirstName_emp, string LastName_emp, string Email_emp, string PhoneNumber_emp, string FixeNumber_emp, int Id_service, int Id_site)
        {
            InitializeComponent();
            Id_emp = Id;
            InputEmail.Text = Email_emp;
            InputFirstName.Text = FirstName_emp;
            InputLastName.Text = LastName_emp;
            InputPhoneNumber.Text = PhoneNumber_emp;
            InputFixeNumber.Text = FixeNumber_emp;
            ComboBoxServices.SelectedValue = Id_service;
            ComboBoxSites.SelectedValue = Id_site;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonAddEmp_Click(object sender, RoutedEventArgs e)
        {

            if (InputFirstName.Text != null && InputLastName.Text != null && InputEmail.Text != null && InputPhoneNumber.Text != null)
            {
                try
                {
                    _context.Database.EnsureCreated();
                    Employes emp = _context.Employes.Where(o => o.Id_employe == Id_emp).First();
                    emp.FirstName_employe = InputFirstName.Text;
                    emp.LastName_employe = InputLastName.Text;
                    emp.PhoneNumber_employe = InputPhoneNumber.Text;
                    emp.Email_employe = InputEmail.Text;
                    emp.Id_service = (int)ComboBoxServices.SelectedValue;
                    emp.Id_site = (int)ComboBoxSites.SelectedValue;
                    emp.FixeNumber_employe = (InputFixeNumber.Text != null) ? InputFixeNumber.Text : "Non renseigné";

                    _context.SaveChanges();
                    MessageBox.Show("Modification de l'employé réussie", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                    DialogResult = true;

                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur lors de la procédure", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Les informations necessaire ne sont pas fournies", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
