using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace DataStorageSample
{
    [Transaction(TransactionMode.Manual)]
    public class CommandReadSettings : IExternalCommand
    {
        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;

            AdnSettingsDataStorageHelper settingsDataStorageHelper =
                   new AdnSettingsDataStorageHelper(doc);

            var url = settingsDataStorageHelper.ReadURL();

            if (url == null)
                TaskDialog.Show("ADN-CIS", "Настройки не заданы");

            else
                TaskDialog.Show("ADN-CIS", string.Format("Значение URL: {0}", url));
                    
            

            return Result.Succeeded;
        }
    }
}