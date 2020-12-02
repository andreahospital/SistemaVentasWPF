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

namespace SistemaVentasWPF
{
    /// <summary>
    /// Lógica de interacción para Consultawpf.xaml
    /// </summary>
    public partial class Consultawpf : Window
    {
        AguilaCurdaEntities datos;
        public Consultawpf()
        {
            InitializeComponent();
            datos = new AguilaCurdaEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstConsultas.ItemsSource = datos.Consulta.ToList();
        }
    }
}
