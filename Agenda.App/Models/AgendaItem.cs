using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.App.Models
{
    public class AgendaItem
    {
        //La clase define cuatro propiedades públicas: 'Name', 'Lastname' y 'Dni'.
        [AutoIncrement, PrimaryKey]
        //La propiedad 'Id' es una propiedad de clave principal que se utiliza para identificar unívocamente cada objeto 'AgendaItem' en la base de datos.
        //El atributo 'AutoIncrement' se utiliza para indicar que la clave principal debe generarse automáticamente.
        //El atributo 'PrimaryKey' se utiliza para indicar que la propiedad decorada con él debe utilizarse como clave principal de la tabla en la base de datos.
        public int Id { get; set; }
        //Las propiedades 'Name' y 'Lastname' son propiedades de tipo string que representan el nombre y apellido de la persona correspondiente al objeto 'AgendaItem'.
        public string Name { get; set; }
        public string Lastname { get; set; }
        //La propiedad 'Dni' es una propiedad de tipo string que representa el número de identificación de la persona correspondiente al objeto 'AgendaItem'.
        //El atributo Unique se utiliza para indicar que el valor de la propiedad decorada con él debe ser único en la tabla en la base de datos.
        [Unique]
        public string Dni { get; set; }
    }
}
//Este código define la estructura de la clase 'AgendaItem' y especifica las propiedades y atributos que se utilizarán para almacenar y recuperar elementos de agenda en la base de datos SQLite de la aplicación.
