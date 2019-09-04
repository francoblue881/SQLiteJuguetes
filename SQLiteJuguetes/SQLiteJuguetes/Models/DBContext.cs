using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SQLite;

namespace SQLiteJuguetes.Models
{
  public class DBContext
  {
    public SQLiteAsyncConnection Conexion { get; set; }

    public DBContext(string path)
    {
      try
      {
        this.Conexion = new SQLiteAsyncConnection(path);
        this.Conexion.CreateTableAsync<Juguete>().Wait();

      }
      catch (Exception ex)
      {

        Debug.Write("EEROR:" +ex.Message);
      }
    }

  }
}
