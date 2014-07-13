#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace DataStorageSample
{
    [Transaction(TransactionMode.Manual)]
    public class CommandWriteSettings : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;

            using (Transaction trans = new Transaction(doc,"Сохранение настроек"))
            {
                trans.Start();

                AdnSettingsDataStorageHelper settingsDataStorageHelper = 
                    new AdnSettingsDataStorageHelper(doc);

                settingsDataStorageHelper.WriteURL("http://adn-cis.org");

                var res = trans.Commit();

                if (res == TransactionStatus.Committed)
                    TaskDialog.Show("ADN-CIS", "Настройки сохранены");
            }

            return Result.Succeeded;
        }
    }
}
