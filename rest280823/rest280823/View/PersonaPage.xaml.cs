using rest280823.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rest280823.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace rest280823.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonaPage : ContentPage
    {
        PersonaViewModel contexto = new PersonaViewModel();
        public PersonaPage()
        {
            InitializeComponent();
            BindingContext = contexto;
            LvPersonas.ItemSelected += LvPersonas_ItemSelected;
        }

        private void LvPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null) 
            {
                PersonModel modelo = (PersonModel)e.SelectedItem;
                contexto.Nombre = modelo.Nombre;
                contexto.Apellidos = modelo.Apellidos;
                contexto.Edad = modelo.Edad;
                contexto.DNI = modelo.DNI;
                contexto.Id = modelo.Id;
            }
        }

    }
}