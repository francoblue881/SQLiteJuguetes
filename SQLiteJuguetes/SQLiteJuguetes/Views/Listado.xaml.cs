using SQLiteJuguetes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteJuguetes.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Listado : ContentPage
  {
    public DBContext db;
    public string database = "dbJuguetes.db3";
    public string ruta;
    ObservableCollection<Juguete> oLista;

    public Listado()
    {
      InitializeComponent();
      ruta = Path.Combine(Environment.GetFolderPath
        (Environment.SpecialFolder.LocalApplicationData),
        this.database);
      this.db = new DBContext(this.ruta);
      CargarLista();

    }

    public void CargarLista()
    {
      Juguete j = new Juguete(this.db);
      this.oLista = new ObservableCollection<Juguete>();

      var resultado = j.Query("SELECT * FROM [Juguete]").Result;
      if (!(resultado is null))
      {
        foreach (var item in resultado)
        {
          oLista.Add(item);
        }
      }

      listadoJuguetes.ItemsSource = oLista;
    }



    private void RecargarLista(object sender, EventArgs e)
    {
      CargarLista();
      listadoJuguetes.EndRefresh();
    }

    private void ItemSeleccionado(object sender, ItemTappedEventArgs e)
    {
      if (e.Item is null)
      {
        return;
      }
      var lis = (Xamarin.Forms.ListView)sender;
      var elemento = lis.SelectedItem as Juguete;
      PopupNavigation.PushAsync(new ModalAccion(elemento));
      

      //DisplayAlert(
      //  "Notificacion",
      //  "Click en " + elemento.Nombre,
      //  "OK");
    }
  }
}