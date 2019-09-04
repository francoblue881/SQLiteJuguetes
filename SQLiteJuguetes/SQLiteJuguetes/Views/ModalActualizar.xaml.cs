using SQLiteJuguetes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace SQLiteJuguetes.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ModalActualizar
  {
    public DBContext db;
    public string database = "dbJuguetes.db3";
    public string ruta;

    public Juguete oJ;

    int IDJ;
    public ModalActualizar(Juguete ju)
    {
     this.oJ = ju;
      InitializeComponent();
      ruta = Path.Combine(Environment.GetFolderPath
        (Environment.SpecialFolder.LocalApplicationData),
        this.database);
      this.db = new DBContext(ruta);

      IDJ = oJ.IdJuguete;
      txtNombre.Text = oJ.Nombre;
      txtPrecio.Text = oJ.Precio.ToString();
      txtTipo.Text = oJ.Tipo;

    }

    private async void btn_actualizar(object sender, EventArgs e)
    {
      Juguete nj = new Juguete(this.db);

      nj.IdJuguete = IDJ;
      nj.Nombre = txtNombre.Text;
      nj.Tipo = txtTipo.Text;
      nj.Precio = double.Parse(txtPrecio.Text);

      var res = await nj.Actualizar(nj);
      if (res)
      {
        await DisplayAlert(
         "Notificacion", "Se ha actualizado el elemento", "OK");
      }
      else {
        await DisplayAlert(
        "Notificacion", "No se pudo actualizar", "OK");
      }
    }
  }
}