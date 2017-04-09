using FotoAppDB.DBModel;
using System.Collections.Generic;

namespace FotoAppDB.Repository.Interface
{
    interface ISizeTextsR
    {        
        SizeTexts GetSizeTextBySizeALang(Sizes size, Languages lang);
    }
}
