using System;
using Autodesk.Revit.DB.ExtensibleStorage;

namespace DataStorageSample
{
    public static class AdnCisSampleSchema
    {
        private readonly static Guid schemaId = 
            new Guid("B08287CD-BB06-47AC-88E0-705D5411F962");

        public static Schema GetSchema()
        {
            //Смотрим, Загружена ли схема в память или нет
            Schema schema = Schema.Lookup(schemaId);
            if (schema != null)
                return schema; // возвращаем схему, если она уже созадна и загружена

            // Создаем схему, если ее еще нет.
            SchemaBuilder schemaBuilder = new SchemaBuilder(schemaId);

            // Схема будет содержать одно поле
            // в котором хранится URL
            schemaBuilder
                .SetSchemaName("MyAddinSettings")
                .AddSimpleField("SiteURL", typeof (string));

            return schemaBuilder.Finish();
        }
    }
}