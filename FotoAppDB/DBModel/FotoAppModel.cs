﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoAppDB.DBModel
{
    class FotoAppModel : DbContext
    {
        // Your context has been configured to use a 'FotoAppModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FotoAppDB.FotoAppModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FotoAppModel' 
        // connection string in the application configuration file.
        public FotoAppModel()
            : base("name=FotoAppModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
