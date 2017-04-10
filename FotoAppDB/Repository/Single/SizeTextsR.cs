using System;
using FotoAppDB.DBModel;
using FotoAppDB.Exception;
using FotoAppDB.Repository.Interface;
using System.Linq;

namespace FotoAppDB.Repository.Single
{

    public class SizeTextsR : FotoAppR<FotoAppDbContext, SizeTexts>, ISizeTextsR
    {
        public override SizeTexts Get(SizeTexts FAobject)
        {
            SizeTexts o = Context.SizeText.Find(FAobject.Height, FAobject.Length, FAobject.Language);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new NotExistInDataBaseException("Nie znaleziono tłumaczenia!");
            }
        }

        public SizeTexts GetSizeTextBySizeALang(Sizes size, Languages lang)
        {
            SizeTexts sizeText = Context.SizeText.Find(size.Height, size.Length, lang.Language);
            if (sizeText == null)
            {
                Settings baseLang = Context.Setting.Find("lang", lang.Language);
                if (baseLang == null || baseLang.Value.Length>Languages.maxLengthLanguage)
                {
                    throw new NotExistInDataBaseException("Nie znaleziono tłumaczenia!");
                }
                else
                {
                    return GetSizeTextBySizeALang(size, new Languages() { Language = baseLang.Value });
                }
            }
            else
            {
                return sizeText;
            }
        }

        public override bool Is(SizeTexts FAobject)
        {
            return Context.SizeText.Find(FAobject.Height, FAobject.Length, FAobject.Language) != null;
        }
    }
}
