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

        public Annuaire(Boolean IsAdminAuth)
        {
            InitializeComponent();
            BindDataGrid();
            if (IsAdminAuth == true)
            {
                ButtonAddEmp.Visibility = Visibility.Visible;
                ButtonAddService.Visibility = Visibility.Visible;
                ButtonAddSite.Visibility = Visibility.Visible;
            }
        }


        public void BindDataGrid()
        {
            _context.Database.EnsureCreated();
            var ListDB = _context.Employes.ToList();

            List<EmployeReturn> EmpReturn = new List<EmployeReturn>();
            foreach(var obj in ListDB)
            {
                var site = _context.Sites.Where(s => s.Id_site == obj.Id_site).First();
                var service = _context.Services.Where(s => s.Id_service == obj.Id_service).First();

                EmployeReturn emp = new EmployeReturn(
                    obj.Id_employe, obj.FirstName_employe, obj.LastName_employe, obj.PhoneNumber_employe,obj.Email_employe, service.Name_service , site.Name_site, obj.FixeNumber_employe) ;
                EmpReturn.Add(emp);
                DataGrid.ItemsSource = EmpReturn;

            }
        }

        private void ButtonAddEmp_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddNewEmploye();
            var result = newWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new WinFiltres();
            var result = newWindow.ShowDialog();
        }

        private void ButtonAddService_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddNewService();
            var result = newWindow.ShowDialog();

        }

        private void ButtonAddSite_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AddNewSite();
            var result = newWindow.ShowDialog();

        }
    }
}
