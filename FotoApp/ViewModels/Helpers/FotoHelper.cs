using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoAppDB;
using FotoAppDB.DBModel;

namespace FotoApp.ViewModels.Helpers
{
    public class FotosHelper
    {
        private string _nameFoto;
        private Fotos _foto;
        public FotosHelper(string nameFoto)
        {
            _nameFoto = nameFoto;
        }

        public Fotos Foto => _foto;  

        public void AddFoto()
        {
            _foto = new Fotos();
            _foto.Name = _nameFoto;
            FotoAppRAll all = FotoAppRAll.Ins;
            all.Fotos.Add(_foto);
            all.Fotos.Save();
            _foto = all.Fotos.Get(_foto);
        }
    }
}