using rest280823.Model;
using rest280823.Servicio;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rest280823.ViewModel
{
    public class PersonaViewModel:PersonModel
    {
        public  ObservableCollection<PersonModel> Personas { get; set; }
        PersonaServicio servicio = new PersonaServicio();
        PersonModel modelo;

        public PersonaViewModel()
        {
            Personas = servicio.Consultar();
            GuardarCommand = new Command(async () => await Guardar(), () => !Isbusy);
            ModificarCommand = new Command(async () => await Modificar(), () => !Isbusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !Isbusy);
            LimpiarCommand = new Command(Limpiar, () => !Isbusy);
        }

        public Command GuardarCommand { get; set; }
        public Command ModificarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

        private async Task Guardar()
        {
            Isbusy = true;
            Guid IdPersona = Guid.NewGuid();
            modelo = new PersonModel()
            {
                Nombre = Nombre,
                Apellidos = Apellidos,
                Edad = Edad,
                DNI = DNI,
                Id = IdPersona.ToString()
            };
            servicio.Guardar(modelo);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private async Task Modificar()
        {
            Isbusy = true;
            modelo = new PersonModel()
            {
                Nombre = Nombre,
                Apellidos = Apellidos,
                Edad = Edad,
                DNI = DNI,
                Id = Id
            };
            servicio.Modificar(modelo);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private async Task Eliminar()
        {
            Isbusy = true;
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            Isbusy = false;
        }

        private void Limpiar()
        {
            Nombre = "";
            Apellidos = "";
            Edad = 0;
            DNI = 0;
            Id = "";
        }
    }
}
