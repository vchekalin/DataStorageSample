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
            //�������, ��������� �� ����� � ������ ��� ���
            Schema schema = Schema.Lookup(schemaId);
            if (schema != null)
                return schema; // ���������� �����, ���� ��� ��� ������� � ���������

            // ������� �����, ���� �� ��� ���.
            SchemaBuilder schemaBuilder = new SchemaBuilder(schemaId);

            // ����� ����� ��������� ���� ����
            // � ������� �������� URL
            schemaBuilder
                .SetSchemaName("MyAddinSettings")
                .AddSimpleField("SiteURL", typeof (string));

            return schemaBuilder.Finish();
        }
    }
}