using FotoAppDB.DBModel;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Interface
{
    interface ITypeTextsR
    {        
        TypeTexts GetTypeTextByTypeALang(Types type, Languages lang);
    }
}
