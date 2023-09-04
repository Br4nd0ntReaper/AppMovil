using rest280823.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace rest280823.Servicio
{
    public class PersonaServicio
    {
        public ObservableCollection<PersonModel> personas { get; set; }

        public PersonaServicio()
        {
            if (personas == null) 
            {
                personas = new ObservableCollection<PersonModel>();
            }
        }

        public ObservableCollection<PersonModel> Consultar()
        {
            return personas;
        }

        public void Guardar(PersonModel modelo) 
        {
            personas.Add(modelo);
        }

        public void Modificar(PersonModel modelo) 
        {
            for(int i = 0; i < personas.Count; i++) 
            {
                if (personas[i].Id == modelo.Id)
                {
                    personas[i] = modelo;
                }
            }
        }

        public void Eliminar(string idPersona)
        {
            PersonModel modelo = personas.FirstOrDefault(p => p.Id == idPersona);
            personas.Remove(modelo);
        }

    }
}
