using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Semana7App.Modelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }
        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Modelo.Estudiante>("Select * from estudiante where usuario=? and contrasenia=?", usuario, contrasena);
        }
        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "semana7.db3");
                var db = new SQLiteConnection(documentPath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUser.Text, txtContrasenia.Text);
                if (resultado.Count() > 0)
                {

                }
                else
                {
                    DisplayAlert("Alerta", "Usuario no existe, por favor registrarse", "ok");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Alerta", "Usuario no existe", "ok");
            }
        }

        private IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, object text1, object text2)
        {
            throw new NotImplementedException();
        }
        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}