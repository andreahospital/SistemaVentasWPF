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
    /// Lógica de interacción para Usuarioswpf.xaml
    /// </summary>
    public partial class Usuarioswpf : Window
    {

        AguilaCurdaEntities datos;
        public Usuarioswpf()
        {
            InitializeComponent();
            datos = new AguilaCurdaEntities();
        }

        private void frmUsuario_Loaded(object sender, RoutedEventArgs e)
        {
            ObtenerDatos();
        }

        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.LoginName = (txtUsuario.Text);
            usuario.Password = (txtContraseña.Text);
            usuario.Nombre = (txtNombre.Text);
            usuario.Apellido = (txtApellido.Text);
            usuario.Cargo = (txtCargo.Text);
            usuario.Email = (txtEmail.Text);


            await Usuarios.AgregarUsuario(usuario);

            LimpiarCampos();

            ObtenerDatos();
        }

        private async void ObtenerDatos()
        {
            List<Usuarios> lista = await Usuarios.ObtenerUsuario();
            lstUsuario.ItemsSource = lista;
        }

        private void LimpiarCampos()
        {

            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtCargo.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }


        private void lstUsuario_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (lstUsuario.SelectedItem != null)
            {
                Usuarios marcaSelecionada = (Usuarios)lstUsuario.SelectedItem;
                txtUsuario.Text = marcaSelecionada.LoginName;
                txtContraseña.Text = marcaSelecionada.Password;
                txtNombre.Text = marcaSelecionada.Nombre;
                txtApellido.Text = marcaSelecionada.Apellido;
                txtCargo.Text = marcaSelecionada.Cargo;
                txtEmail.Text = marcaSelecionada.Email;

            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lstUsuario.SelectedItem != null)
            {
                Usuarios marcaSelecionada = (Usuarios)lstUsuario.SelectedItem;


                marcaSelecionada.LoginName = txtUsuario.Text;
                marcaSelecionada.Password = txtContraseña.Text;
                marcaSelecionada.Nombre = txtNombre.Text;
                marcaSelecionada.Apellido = txtApellido.Text;
                marcaSelecionada.Cargo = txtCargo.Text;
                marcaSelecionada.Email = txtEmail.Text;

                datos.Entry(marcaSelecionada).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();

                ObtenerDatos();
            }
            else
                MessageBox.Show("Debe seleccionar un Dispositivo de la grilla para modificar!");
            LimpiarCampos();
        }

    }
}
