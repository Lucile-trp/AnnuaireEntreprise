using annuaireEntreprise.DB.ReturnModel;
using annuaireEntreprise.View.Admin;
using annuaireEntreprise.View.Filtres;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace annuaireEntreprise.View
{
    /// <summary>
    /// Logique d'interaction pour Annuaire.xaml
    /// </summary>
    public partial class Annuaire : Page
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public Boolean IsAdminAuth { get; set; }

        public Annuaire(Boolean IsAdminAuth)
        {
            this.IsAdminAuth = IsAdminAuth;
            InitializeComponent();
            BindDataGrid();

            
            if (IsAdminAuth == true)
            {
                ButtonAddEmp.Visibility = Visibility.Visible;
                ButtonAddService.Visibility = Visibility.Visible;
                ButtonAddSite.Visibility = Visibility.Visible;
                ButtonDeleteService.Visibility = Visibility.Visible;
                ButtonDeleteSite.Visibility = Visibility.Visible;
                ButtonUpdateSite.Visibility = Visibility.Visible;
                ButtonUpdateService.Visibility = Visibility.Visible;
                ColumnUpdate.Visibility = Visibility.Visible;
                ColumnDelete.Visibility = Visibility.Visible;

            }
        }

        // Charge les données dans le DataGrid
        public void BindDataGrid()
        {
            using ( var db = new AnnuaireEntreriseContext())
            {
                var ListDB = db.Employes.ToList();

                List<EmployeReturn> EmpReturn = new List<EmployeReturn>();
                foreach (var obj in ListDB)
                {
                    var site = db.Sites.Where(s => s.Id_site == obj.Id_site).First();
                    var service = db.Services.Where(s => s.Id_service == obj.Id_service).First();

                    EmployeReturn emp = new EmployeReturn(
                        obj.Id_employe, obj.FirstName_employe, obj.LastName_employe, obj.PhoneNumber_employe, obj.Email_employe, service.Id_service, service.Name_service, site.Id_site, site.Name_site, obj.FixeNumber_employe);
                    EmpReturn.Add(emp);

                }
                DataGrid.ItemsSource = EmpReturn;
            }
        }

        // Filtre l'affichage du DATAGRID en fonction des conditions remplies
        private void Filtrer(object sender, RoutedEventArgs e)
        {
            var newWindow = new WinFiltres(IsAdminAuth);
            var res = newWindow.ShowDialog();

            if(res == false)
            {
                BindDataGrid();

            } else
            {
                var result = newWindow.Choice;
                if (result[0] == "Sites" && result[1] != null)
                {
                    _context.Database.EnsureCreated();
                    var ListDB = _context.Employes.Where(o => o.Id_site == Int32.Parse(result[1])).ToList();

                    List<EmployeReturn> EmpReturn = new List<EmployeReturn>();
                    foreach (var obj in ListDB)
                    {
                        var site = _context.Sites.Where(s => s.Id_site == obj.Id_site).First();
                        var service = _context.Services.Where(s => s.Id_service == obj.Id_service).First();

                        EmployeReturn emp = new EmployeReturn(
                            obj.Id_employe, obj.FirstName_employe, obj.LastName_employe, obj.PhoneNumber_employe, obj.Email_employe, service.Id_service, service.Name_service, site.Id_site, site.Name_site, obj.FixeNumber_employe);
                        EmpReturn.Add(emp);
                    }
                    DataGrid.ItemsSource = EmpReturn;

                }
                else if (result[0] == "Services" && result[1] != null)
                {
                    _context.Database.EnsureCreated();
                    var ListDB = _context.Employes.Where(o => o.Id_service == Int32.Parse(result[1])).ToList();

                    List<EmployeReturn> EmpReturn = new List<EmployeReturn>();
                    foreach (var obj in ListDB)
                    {
                        var site = _context.Sites.Where(s => s.Id_site == obj.Id_site).First();
                        var service = _context.Services.Where(s => s.Id_service == obj.Id_service).First();

                        EmployeReturn emp = new EmployeReturn(
                            obj.Id_employe, obj.FirstName_employe, obj.LastName_employe, obj.PhoneNumber_employe, obj.Email_employe, service.Id_service, service.Name_service, site.Id_site, site.Name_site, obj.FixeNumber_employe);
                        EmpReturn.Add(emp);
                    }
                    DataGrid.ItemsSource = EmpReturn;

                }
                else if (result[0] == "Nom" && result[1] != null)
                {
                    _context.Database.EnsureCreated();
                    var ListDB = _context.Employes.Where(e => e.LastName_employe.Contains(result[1])).ToList();

                    List<EmployeReturn> EmpReturn = new List<EmployeReturn>();
                    foreach (var obj in ListDB)
                    {
                        var site = _context.Sites.Where(s => s.Id_site == obj.Id_site).First();
                        var service = _context.Services.Where(s => s.Id_service == obj.Id_service).First();

                        EmployeReturn emp = new EmployeReturn(
                            obj.Id_employe, obj.FirstName_employe, obj.LastName_employe, obj.PhoneNumber_employe, obj.Email_employe, service.Id_service, service.Name_service, site.Id_site, site.Name_site, obj.FixeNumber_employe);
                        EmpReturn.Add(emp);
                    }
                    DataGrid.ItemsSource = EmpReturn;
                }
                else
                {
                    BindDataGrid();
                }

            }
            
        }

        // Ajouter un employé /// ADMIN ONLY
        private void ButtonAddEmp_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddNewEmploye();
            var result = newWindow.ShowDialog();
            BindDataGrid();
        }

        // Ajouter un Service /// ADMIN ONLY
        private void ButtonAddService_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddNewService();
            var result = newWindow.ShowDialog();

        }

        // Ajouter un Site /// ADMIN ONLY
        private void ButtonAddSite_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddNewSite();
            var result = newWindow.ShowDialog();

        }

        // Supprimer un Employé /// ADMIN ONLY
        private void DeleteEmploye_Click(object sender, RoutedEventArgs e)
        {
            var sender_context = sender as Button;

            var context = sender_context!.DataContext as EmployeReturn;

            var MessageBoxDelete = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet employé ?", "Confirmer la suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(MessageBoxDelete == MessageBoxResult.Yes)
            {
                // REcupération de L'entrée en BDD
                _context.Database.EnsureCreated();

                var empDelete = _context.Employes.Where(o => o.Id_employe == context.Id).Single();
                _context.Employes.Remove(empDelete);
                _context.SaveChanges();

            } else
            {
                MessageBox.Show("Supression non autorisée.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            BindDataGrid();
        }

        // Modifier un Employé /// ADMIN ONLY
        private void UpdateEmploye_Click(object sender, RoutedEventArgs e)
        {
            var sender_context = sender as Button;
            var context = sender_context!.DataContext as EmployeReturn;

            var newWindow = new UpdateEmp(context.Id, context.FirstName, context.LastName, context.Email, context.PhoneNumber, context.FixeNumber, context.Id_service, context.Id_site);
            newWindow.ShowDialog();
            DataGrid.ItemsSource = null;
            BindDataGrid();
        }

        // Supprimer un Service /// ADMIN ONLY
        private void ButtonDeleteService_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new DeleteService();
            newWindow.ShowDialog();
        }

        // Supprimer un Site /// ADMIN ONLY
        private void ButtonDeleteSite_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new DeleteSite();
            newWindow.ShowDialog();

        }

        private void ButtonUpdateSite_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new UpdateSite();
            newWindow.ShowDialog();
            BindDataGrid();
        }

        private void ButtonUpdateService_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new UpdateService();
            newWindow.ShowDialog();
            BindDataGrid();

        }
    }
}
