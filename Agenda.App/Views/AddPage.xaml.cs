using Agenda.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        // Metodo que se utiliza cuando se presiona el botón "Agregar"
        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            //Inicio de la Validación para las entradas de datos del Nombre, Apellido y Dni

            // Si en el campo Nombre no se ingresaron datos (si lo dejaron en blanco)
            if (!string.IsNullOrEmpty(nombre.Text) == false)
            {   
                // Si en el campo Apellido no se ingresaron datos (si lo dejaron en blanco)
                if (!string.IsNullOrEmpty(apellido.Text) == false)
                {   
                    // Si en el campo Dni no se ingresaron datos (si lo dejaron en blanco)
                    if (!string.IsNullOrEmpty(dni.Text)== false)
                    {   
                        // Mensaje de Error.
                        await DisplayAlert("Error", "Inserte datos en el campo 'Nombre', 'Apellido' y 'Dni'.", "Aceptar");
                    }
                }
                  // De lo contrario (Solo se encontraron datos en el campo Apellido)  
                else
                {
                    // Si en el campo Dni no se ingresaron datos (si lo dejaron en blanco)
                    if (!string.IsNullOrEmpty(dni.Text) == false)
                    {
                        // Mensaje de Error.
                        await DisplayAlert("Error", "Inserte datos en el campo 'Nombre' y 'Dni'.", "Aceptar");
                    }
                      // De lo contrario (Solo se encontraron datos los campos Apellido y Dni)  
                    else
                    {
                        // Mensaje de Error.
                        await DisplayAlert("Error", "Inserte datos en el campo 'Nombre'.", "Aceptar");
                    }
                }
            }
              // De lo contrario (Solo se encontraron datos en el campo Nombre)  
            else
            {
                  // Si en el campo Apellido no se ingresaron datos (si lo dejaron en blanco)
                if (!string.IsNullOrEmpty(apellido.Text) == false)
                {
                      // Si en el campo Dni no se ingresaron datos (si lo dejaron en blanco)
                    if (!string.IsNullOrEmpty(dni.Text) == false)
                    {
                         // Mensaje de Error.
                        await DisplayAlert("Error", "Inserte datos en el campo 'Apellido' y 'Dni'.", "Aceptar");
                    }
                      // De lo contrario solo encontraron datos en los campos Nombre y Dni
                    else
                    {
                        // Mensaje de Error.
                        await DisplayAlert("Error", "Inserte datos en el campo 'Apellido'.", "Aceptar");
                    }
                }
                  // De lo contrario (Solo encontraron datos en los campos Nombre y Apellido)
                else
                {
                    // Si en el campo Dni no se ingresaron datos (si lo dejaron en blanco)
                    if (!string.IsNullOrEmpty(dni.Text) == false)
                    {
                        // Mensaje de Error.
                        await DisplayAlert("Error", "Inserte datos en el campo 'Dni'.", "Aceptar");
                    }
                     // De lo contrario encontraron llenados los datos de los campos Nombre, Apellido y Dni
                    else
                    {
                        // Comfirmación de la existencia de datos ingresados en el campo Nombre
                        if (!string.IsNullOrEmpty(nombre.Text))
                        {
                            // Validación y comprobación de caracteres especiales, números y cantidad de nombres ingresados para su bloqueo 
                            var regexnom = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]+\s?[a-zA-Z]+\s?[a-zA-Z]+\s?\w+?\s?\w+?\s?$");

                            // Si el campo nombre tiene caracteres especiales, números y una cantidad de nombres no aceptados
                            if (!regexnom.IsMatch(nombre.Text))
                            {
                                // Mensaje de Error.
                                await DisplayAlert("Error", "El nombre no debe tener caracteres especiales y muchos espacios en blanco.", "Aceptar");
                            }
                            // De lo contrario (Solo se aprobo el envio de datos en el campo Nombre)
                            else
                            {
                                // Comfirmación de la existencia de datos ingresados en el campo Apellido
                                if (!string.IsNullOrEmpty(apellido.Text))
                                {
                                    // Validación y comprobación de caracteres especiales, números y cantidad de apellidos ingresados para su bloqueo
                                    var regexape = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]+\s?[a-zA-Z]+\s?[a-zA-Z]+\s?\w+?\s?\w+?\s?$");

                                    // Si el campo Apellido tiene caracteres especiales, números y una cantidad de nombres no aceptados
                                    if (!regexape.IsMatch(apellido.Text))
                                    {
                                        // Mensaje de Error.
                                        await DisplayAlert("Error", "El Apellido no debe tener caracteres especiales y muchos espacios en blanco.", "Aceptar");
                                    }
                                    // De lo contrario (Solo se aprobo el envio de datos en el campo Nombre y Apellido)
                                    else
                                    {
                                        // Comfirmación de la existencia de datos ingresados en el campo Dni
                                        if (!string.IsNullOrEmpty(dni.Text))
                                        {
                                            // Validación y comprobación de caracteres especiales y números decimales ingresados para su bloqueo
                                            var regexdni = new System.Text.RegularExpressions.Regex("^[0-9]{8}$");

                                            // Si el campo Dni tiene caracteres especiales y números decimales no aceptados
                                            if (!regexdni.IsMatch(dni.Text))
                                            {
                                                // Mensaje de Error.
                                                await DisplayAlert("Error", "El Dni no debe tener caracteres especiales.", "Aceptar");
                                            }
                                            // De lo contrario (Se aprobaron el envio de datos en los campos Nombre, Apellido y Dni)
                                            else
                                            {
                                                // Envio de datos a la tabla de la base de datos
                                                try
                                                {
                                                    var item = new AgendaItem
                                                    {
                                                        Name = nombre.Text,
                                                        Lastname = apellido.Text,
                                                        Dni = dni.Text,
                                                    };
                                                    var result = await App.Context.InsertItemAsync(item);
                                                    if (result == 1)
                                                    {
                                                        await Navigation.PopAsync();
                                                    }
                                                    else
                                                    {
                                                        await DisplayAlert("Error", "No se pudo guardar la tarea", "Aceptar");
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    await DisplayAlert("Error", ex.Message, "Aceptar");
                                                    
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}