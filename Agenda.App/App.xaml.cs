using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Agenda.App.Views;
using Agenda.App.Data;

namespace Agenda.App
{
    public partial class App : Application
    {
        //La clase define una propiedad estática 'Context' para acceder a la instancia de la base de datos.
        public static DatabaseContext Context { get; set; }
        public App()
        {
            //Inicializamos los componentes visuales de la aplicación
            InitializeComponent();
            //Se llama al método para inicializar la base de datos.
            InitializeDatabase();
            //La página principal de la aplicación se establece como una nueva instancia de la clase 'NavigationPage' que contiene una instancia de la clase 'HomePage'.
            MainPage = new NavigationPage(new HomePage());
        }

        //El método 'InitializeDatabase()' crea una instancia de la clase 'DatabaseContext' pasando como parámetro la ruta de la base de datos en el sistema de archivos local. La instancia se guarda en la propiedad estática 'Context'.
        private void InitializeDatabase()
        {
            //Obtiene la ruta de la carpeta de la aplicación local donde se almacenará la base de datos.
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //Combinamos la ruta de la carpeta de la aplicación local con el nombre del archivo de la base de datos 'Agenda.db3'. Este será el camino completo hacia la base de datos en la ubicación de la aplicación.
            var dbPath = System.IO.Path.Combine(folderApp, "Agenda.db3");
            //Finalmente, se crea una nueva instancia de la clase 'DatabaseContext' pasando la ruta completa de la base de datos como argumento y se asigna a la propiedad 'Context' de la clase 'App'.
            Context = new DatabaseContext(dbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
//Este código se utiliza para inicializar la base de datos local de la aplicación. La ruta de la base de datos se combina con la ubicación de la carpeta de la aplicación local y se utiliza para crear una nueva instancia de la clase 'DatabaseContext' que se utilizará para interactuar con la base de datos.
