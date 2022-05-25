using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Semana7App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Modelo.Estudiante> tablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            this.ObtenerLista();
        }

        private void ListarUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Modelo.Estudiante)e.SelectedItem;
            var Item = obj.id.ToString();
            int id = Convert.ToInt32(Item);
            var _Nombre = obj.nombre.ToString();
            string nombre = _Nombre.ToString();

            var _Usuario = obj.usuario.ToString();
            string usuario = _Usuario.ToString();

            var _Contrasenia = obj.contrasenia.ToString();
            string contrasenia = _Contrasenia.ToString();
            //Navigation.PushAsync(new elemento(id, nombre, usuario, contrasenia));
        }
        public async void ObtenerLista()
        {
            var resultado = await con.Table<Modelo.Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Modelo.Estudiante>(resultado);
            ListarUsuarios.ItemsSource = tablaEstudiante;

        }
    }
}