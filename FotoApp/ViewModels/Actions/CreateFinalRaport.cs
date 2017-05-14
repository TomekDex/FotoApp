using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoAppDB;
using FotoAppDB.DBModel;

namespace FotoApp.ViewModels.Actions
{
    public class CreateFinalRaport
    {
        public void CreateRaport()
        {
            var all = FotoAppRAll.Ins;
            var order = NewOrder.New_Order;
            var raport = all.OrderFotos.GetAllFotosInOrder(order.GetNewOrders());
            var raportBuilder = new StringBuilder();
            raportBuilder.Append(order.GetNewOrders().OrderID);
            raportBuilder.AppendLine(order.GetNewOrders().Description);

            
            foreach (var r in raport)
            {
                raportBuilder.Append(all.Fotos.Get(new Fotos {FotoID = r.FotoID}).Name);
                raportBuilder.Append("\tPapier - ");
                raportBuilder.Append(all.TypeTexts.GetTypeTextByTypeALang(new Types {TypeID = r.TypeID},
                    new Languages {Language = Pref.Preference.Lang }).Text);
                raportBuilder.Append("\tRozmiar - ");
                raportBuilder.Append(all.SizeTexts.GetSizeTextBySizeALang(
                    new Sizes {Height = r.Height, Width = r.Width}, new Languages {Language = Pref.Preference.Lang}).Text);
                raportBuilder.Append("\t\tIlość - ");
                raportBuilder.Append(r.Quantity);
                raportBuilder.Append(Environment.NewLine);
            }
            string pathRaport = Path.Combine(Pref.Preference.DefaultPath ,$"{order.GetNewOrders().Date:Y}/{order.GetNewOrders().OrderID}", "Raport.txt");
            File.AppendAllText( pathRaport, raportBuilder.ToString());
        }
    }
}
