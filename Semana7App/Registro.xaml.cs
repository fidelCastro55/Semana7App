using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
         
        }

        private void btnCrear_Clicked(object sender, EventArgs e)
        {
            var datosRegistro = new Modelo.Estudiante { nombre = txtNombre.Text, usuario = txtUsuario.Text, contrasenia = txtContrasenia.Text };
            con.InsertAsync(datosRegistro);
            this.txtNombre.Text = "";
            this.txtUsuario.Text = "";
            this.txtContrasenia.Text = "";
            DisplayAlert("Aviso", "Se agregó correctamente", "OK");
            Navigation.PushAsync(new Login());
        }
    }
}