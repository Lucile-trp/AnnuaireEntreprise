using annuaireEntreprise.DB.Model;
using Microsoft.Data.Sqlite;
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
    /// Logique d'interaction pour AddNewService.xaml
    /// </summary>
    public partial class AddNewService : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public AddNewService()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(InputServiceText.Text != null)
            {

                _context.Database.EnsureCreated();

                if(_context.Services.Where(se => se.Name_service == InputServiceText.Text).Count() > 0)
                {
                    MessageBox.Show($"Le service : {InputServiceText.Text} existe déjà", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
    
                }
                Services NewServices = new Services();
                NewServices.Name_service = InputServiceText.Text;

                try
                {
                    _context.Services.Add(NewServices);
                    _context.SaveChanges();
                    MessageBox.Show("Nouveau Service disponible", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                    

                } catch (Exception ex) {
                    MessageBox.Show("Une erreur s'est produite lors de la procédure. Veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }

            } else
            {
                MessageBox.Show("Votre champ est vide. Veuillez insérer du texte", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonLeave_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
