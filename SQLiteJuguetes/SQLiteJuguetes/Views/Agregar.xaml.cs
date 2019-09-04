using SQLiteJuguetes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteJuguetes.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class Agregar : ContentPage
  {
    public DBContext db;
    public string database = "dbJuguetes.db3";
    public string ruta;
    public Agregar()
    {
      InitializeComponent();
      ruta = Path.Combine(Environment.GetFolderPath
        (Environment.SpecialFolder.LocalApplicationData),
        this.database);
      this.db = new DBContext(ruta);
    }

    private  void Button_Clicked(object sender, EventArgs e)
    {
      Juguete j = new Juguete(this.db);
      j.Nombre = txtNombre.Text;
      j.Tipo = txtTipo.Text;
      j.Precio = double.Parse(txtPrecio.Text);

      var res =  j.Agregar(j).Result;
      if (res)
      {
        DisplayAlert(
        "Notificacion",
        "Se ha agregado el Juguete " + txtNombre.Text,
        "OK");
      }
      else
      {
        DisplayAlert(
    "Notificacion",
    "No se pudo agregar",
    "OK");
      }

    }
  }
}