using System;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;

namespace FotoAppDB.Repository.Single
{
    //AttachDbFilename=F:\FotoApp\FotoApp\FotoAppDB\DB\FotoApp.mdf
    public class TypeTextsR : FotoAppR<FotoAppDbContext, TypeTexts>,ITypeTextsR
    {
        public override TypeTexts Get(TypeTexts FAobject)
        {
            TypeTexts o = Context.TypeText.Find(FAobject.TypeID, FAobject.Language);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono tłumaczenia!");
            }
        }

        public TypeTexts GetTypeTextByTypeALang(Types type, Languages lang)
        {
            TypeTexts typeText = Context.TypeText.Find(type.TypeID, lang.Language);
            if (typeText == null)
            {
                Settings baseLang = Context.Setting.Find("lang", lang.Language);
                if (baseLang == null || baseLang.Value.Length > Languages.maxLengthLanguage)
                {
                    throw new NotExistInDataBaseException("Nie znaleziono tłumaczenia!");
                }
                else
                {
                    return GetTypeTextByTypeALang(type, new Languages() { Language = baseLang.Value });
                }
            }
            else
            {
                return typeText;
            }
        }

        public override bool Is(TypeTexts FAobject)
        {
            return Context.TypeText.Find(FAobject.TypeID, FAobject.Language) != null;
        }
    }
}
