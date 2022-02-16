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

        public string[] FiltreValue { get; set; }
        public WinFiltres()
        {
            InitializeComponent();
            FiltreValue = new string[] { "Sites", "Services", "Nom" };
        }
    }
}
