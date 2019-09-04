using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using SQLiteJuguetes.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteJuguetes.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ModalAccion 
  {
    public DBContext db;
    public string database = "dbJuguetes.db3";
    public string ruta;

    Juguete oJ;
    public ModalAccion(Juguete ju)
    {
      InitializeComponent();
      oJ = ju;

      ruta = Path.Combine(Environment.GetFolderPath 
        (Environment.SpecialFolder.LocalApplicationData),
        this.database);
      this.db = new DBContext(ruta);

    }

    private async void btn_eliminar(object sender, EventArgs e)
    {
      var accion = await DisplayAlert(
        "Notificacion","Desea eliminar este item","Si","No");
      if (accion)
      {
        Juguete ju = new Juguete(this.db);
        await ju.Eliminar(oJ);
        await DisplayAlert(
        "Notificacion", "Se ha eliminado el item" + oJ.Nombre, "OK");

      }
      else {
        await DisplayAlert(
         "Notificacion", "No se ha eliminado", "OK");
      }

     
    }

    private void btn_actualizar(object sender, EventArgs e)
    {
      PopupNavigation.PopAsync();
      PopupNavigation.PushAsync(new Views.ModalActualizar(oJ) );
    }

    private void btn_regresar(object sender, EventArgs e)
    {
      PopupNavigation.PopAsync();
    }
  }
}