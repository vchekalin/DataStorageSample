using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;

namespace DataStorageSample
{
    class AdnSettingsDataStorageHelper
    {
        private readonly Document _document;

        public AdnSettingsDataStorageHelper(Document document)
        {
            _document = document;
        }

        public void WriteURL(string url)
        {
            var dataStorage = GetDataStorage(true);

            Entity entity = new Entity(AdnCisSampleSchema.GetSchema());

            entity.Set("SiteURL", url);

            dataStorage.SetEntity(entity);
        }

        public string ReadURL()
        {
            var dataStorage = GetDataStorage();

            if (dataStorage == null)
                return null;

            var entity = dataStorage.GetEntity(AdnCisSampleSchema.GetSchema());

            if (entity == null)
                return null;

            var url = entity.Get<string>("SiteURL");

            return url;
        }

        /// <summary>
        /// метод ищет в документе объект DataStorage, 
        /// в котором хранятся наши нстройки.
        /// В случае, если его нет, то он будет создан.
        /// </summary>
        /// <returns></returns>
        private DataStorage GetDataStorage(bool createIfNotExists = false)
        {
            // DataStorage является Element/
            // Для поиска элементов как и прежде используем
            // FilteredElementColector

            var dataStorages = new FilteredElementCollector(_document)
                .OfClass(typeof (DataStorage))
                .OfType<DataStorage>()
                .ToList();

            foreach (var dataStorage in dataStorages)
            {
                var entity = dataStorage.GetEntity(AdnCisSampleSchema.GetSchema());
                if (entity != null && entity.IsValid())
                    return dataStorage;
            }

            if (!createIfNotExists)
                return null;

            // попадаем сюда, если объект не был найден.
            // Создаем новый
            DataStorage storage = DataStorage.Create(_document);

            return storage;
        }
    }
}