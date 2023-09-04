using Agenda.App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.App.Data
{
    public class DatabaseContext
    {
        public readonly SQLiteAsyncConnection Connection;
        public DatabaseContext(string path)
        {
            //'Connection' es una instancia de 'SQLiteAsyncConnection'. Esta propiedad inicializa en el constructor de la clase al pasarle la ruta de la base de datos 'AgentaItem' en los archivos locales.
            Connection = new SQLiteAsyncConnection(path);

            // Tuvimos problemas con la primera tabla porque no le ingresamos que el item 'Dni' sea unico por eso usamos 'DropTableAsync' utilizando el nombre de nuestra tabla 'AgendaItem' esto elimina la tabla y pudimos crear otra tabla con nuestra modificación.
            // 'Connection.DropTableAsync<AgendaItem>().Wait()'

            //Llamamos al método 'CreateTableAsync()' de la conexión, pasandole el nombre de nuestra tabla 'AgendaItem'. Este método crea la tabla correspondiente en la base de datos si no existe.
            Connection.CreateTableAsync<AgendaItem>().Wait();
        }
        //Definimos tres métodos para realizar operaciones CRUD en la base de datos: 'InsertItemAsync()', 'GetItemsAsync()' y 'DeleteItemAsync()'. Estos métodos son asíncronos y devuelven una tarea que representa la operación.

        //El método 'InsertItemAsync()' inserta un objeto de 'AgendaItem' en la tabla correspondiente de la base de datos. Si el valor de la propiedad 'Dni' del objeto ya existe en la base de datos, se lanza una excepción con un mensaje de error.
        public async Task<int> InsertItemAsync(AgendaItem item)
        {
            try
            {
                return await Connection.InsertAsync(item);
            }
            catch (SQLiteException ex) when (ex.Result == SQLite3.Result.Constraint && ex.Message.Contains("UNIQUE"))
            {
                throw new Exception("El valor de Dni ya existe en la base de datos.");
            }

        }

        //El método 'GetItemsAsync()' devuelve una lista de todos los objetos de 'AgendaItem' en la tabla correspondiente de la base de datos.
        public async Task<List<AgendaItem>> GetItemsAsync()
        {
            return await Connection.Table<AgendaItem>().ToListAsync();
        }

        //El método 'DeleteItemAsync()' elimina un objeto de 'AgendaItem' de la tabla correspondiente de la base de datos.
        public async Task<int> DeleteItemAsync(AgendaItem item)
        {
            return await Connection.DeleteAsync(item);
        }
    }
}
//Estos métodos proporcionan una forma de interactuar con la base de datos SQLite de la aplicación para realizar operaciones de inserción, recuperación y eliminación de elementos de 'Agenda'. Están escritos de manera asincrónica para que las operaciones de base de datos no bloqueen el hilo principal de la aplicación.
