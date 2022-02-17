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

namespace annuaireEntreprise.View.Filtres
{
    /// <summary>
    /// Logique d'interaction pour WinFiltres.xaml
    /// </summary>
    public partial class WinFiltres : Window
    {
        private readonly AnnuaireEntreriseContext _context = new AnnuaireEntreriseContext();
        public string[] FiltreValue { get; set; }
        public string[] Choice = new string[] { };

        public WinFiltres(Boolean IsAdminAuth)
        {
            InitializeComponent();
            FiltreValue = new string[] { "Sites", "Services", "Nom" };
            ComboBoxSelectedFiltre.ItemsSource = FiltreValue;
        }


        private void ComboBoxSelectedFiltre_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBoxSelectedFiltre.Text == "Sites")
            {
                StackpanelSecondComboBox.Visibility = Visibility.Visible;
                StackpanelResearchName.Visibility = Visibility.Hidden;
                _context.Database.EnsureCreated();
                var Data = _context.Sites.ToList();
                ComboBoxSecondChoice.ItemsSource = Data;
                ComboBoxSecondChoice.DisplayMemberPath = "Name_site";
                ComboBoxSecondChoice.SelectedValuePath = "Id_site";


            }
            else if (ComboBoxSelectedFiltre.Text == "Services")
            {
                StackpanelSecondComboBox.Visibility = Visibility.Visible;
                StackpanelResearchName.Visibility = Visibility.Hidden;
                _context.Database.EnsureCreated();
                var Data = _context.Services.ToList();
                ComboBoxSecondChoice.ItemsSource = Data;
                ComboBoxSecondChoice.DisplayMemberPath = "Name_service";
                ComboBoxSecondChoice.SelectedValuePath = "Id_service";

            } else if(ComboBoxSelectedFiltre.Text == "Nom")
            {
                StackpanelSecondComboBox.Visibility = Visibility.Hidden;
                StackpanelResearchName.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Choice = new string[] { "", null };
            DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if(ComboBoxSelectedFiltre.Text == "Sites" && ComboBoxSecondChoice != null)
            {
                 Choice = new string[] { "Sites", $"{ComboBoxSecondChoice.SelectedValue}" };
            } else if (ComboBoxSelectedFiltre.Text == "Services" && ComboBoxSecondChoice != null)
            {
                 Choice = new string[] { "Services", $"{ComboBoxSecondChoice.SelectedValue}" };

            } else if (ComboBoxSelectedFiltre.Text == "Nom" && NameInput.Text != null)
            {
                 Choice = new string[] { "Nom", $"{NameInput.Text}" };
            } 
            else
            {
                 Choice = new string[] {"", null};
            }
            DialogResult = true;

        }

    }
}
