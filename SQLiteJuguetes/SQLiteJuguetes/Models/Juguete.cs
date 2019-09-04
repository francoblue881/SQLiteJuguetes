using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteJuguetes.Models
{
  public class Juguete
  {

    [PrimaryKey,AutoIncrement]
    public int IdJuguete { get; set; }
    public string Tipo { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }

    public DBContext db;

    public Juguete()
    {
    }

    public Juguete(DBContext database)
    {
      this.db = database;
    }

    //METODOS

    //LISTAR
    public Task<List<Juguete>> Query(string sql)
    {
      return this.db.Conexion.QueryAsync<Juguete>(sql);
    }

    //AGREGAR
    public Task<bool> Agregar(Juguete j)
    {
      if (this.db.Conexion.InsertAsync(j).Result == 1)
      {
        return Task.FromResult(true);
      }
      else { return Task.FromResult(false); }
    }

    //ELIMINAR
    public Task<bool> Eliminar(Juguete j )
    {
      if (this.db.Conexion.DeleteAsync(j).Result == 1)
      {
        return Task.FromResult(true);
      }
      else { return Task.FromResult(false); }
    }

    //ACTUALIZAR
    public Task<bool> Actualizar(Juguete j)
    {
      if (this.db.Conexion.UpdateAsync(j).Result == 1)
      {
        return Task.FromResult(true);
      }
      else { return Task.FromResult(false); }
    }

  }
}
