﻿using System.Collections.Generic;
using AzureDataLakeClient.Rest;
using ADL = Microsoft.Azure.Management.DataLake;

namespace AzureDataLakeClient.Analytics.Commands
{
    public class CatalogCommands
    {
        private AnalyticsCatalogRestWrapper _adlaCatalogRestClientWrapper;
        private AnalyticsAccount account;

        public CatalogCommands(AnalyticsAccount a, AnalyticsCatalogRestWrapper c)
        {
            this.account = a;
            this._adlaCatalogRestClientWrapper = c;
        }

        public ADL.Analytics.Models.USqlDatabase GetDatabase(string name)
        {
            var db = this._adlaCatalogRestClientWrapper.GetDatabase(this.account.GetUri(), name);
            return db;
        }

        public IEnumerable<ADL.Analytics.Models.USqlDatabase> ListDatabases()
        {
            return this._adlaCatalogRestClientWrapper.ListDatabases(this.account.GetUri());
        }

        public IEnumerable<ADL.Analytics.Models.USqlAssemblyClr> ListAssemblies(string dbname)
        {
            return this._adlaCatalogRestClientWrapper.ListAssemblies(this.account.GetUri(), dbname);
        }

        public IEnumerable<ADL.Analytics.Models.USqlExternalDataSource> ListExternalDatasources(string dbname)
        {
            return this._adlaCatalogRestClientWrapper.ListExternalDatasources(this.account.GetUri(), dbname);
        }

        public IEnumerable<ADL.Analytics.Models.USqlProcedure> ListProcedures(string dbname, string schema)
        {
            return this._adlaCatalogRestClientWrapper.ListProcedures(this.account.GetUri(), dbname, schema);
        }

        public IEnumerable<ADL.Analytics.Models.USqlSchema> ListSchemas(string dbname)
        {
            return this._adlaCatalogRestClientWrapper.ListSchemas(this.account.GetUri(), dbname);
        }

        public IEnumerable<ADL.Analytics.Models.USqlView> ListViews(string dbname, string schema)
        {
            return this._adlaCatalogRestClientWrapper.ListViews(this.account.GetUri(), dbname, schema);
        }

        public IEnumerable<ADL.Analytics.Models.USqlTable> ListTables(string dbname, string schema)
        {
            return this._adlaCatalogRestClientWrapper.ListTables(this.account.GetUri(), dbname, schema);
        }

        public IEnumerable<ADL.Analytics.Models.USqlType> ListTypes(string dbname, string schema)
        {
            return this._adlaCatalogRestClientWrapper.ListTypes(this.account.GetUri(), dbname, schema);
        }

        public IEnumerable<ADL.Analytics.Models.USqlTableType> ListTableTypes(string dbname, string schema)
        {
            return this._adlaCatalogRestClientWrapper.ListTableTypes(this.account.GetUri(), dbname, schema);
        }

        public void CreateCredential(string dbname, string credname, ADL.Analytics.Models.DataLakeAnalyticsCatalogCredentialCreateParameters create_parameters)
        {
            this._adlaCatalogRestClientWrapper.CreateCredential(this.account.GetUri(), dbname, credname, create_parameters);
        }

        public void DeleteCredential(string dbname, string credname, ADL.Analytics.Models.DataLakeAnalyticsCatalogCredentialDeleteParameters delete_parameters)
        {
            this._adlaCatalogRestClientWrapper.DeleteCredential(this.account.GetUri(), dbname, credname, delete_parameters);
        }

        public void UpdateCredential(string dbname, string credname, ADL.Analytics.Models.DataLakeAnalyticsCatalogCredentialUpdateParameters update_parameters)
        {
            this._adlaCatalogRestClientWrapper.UpdateCredential(this.account.GetUri(), dbname, credname, update_parameters);
        }

        public ADL.Analytics.Models.USqlCredential GetCredential(string dbname, string credname)
        {
            return this._adlaCatalogRestClientWrapper.GetCredential(this.account.GetUri(), dbname, credname);
        }

        public IEnumerable<ADL.Analytics.Models.USqlCredential> ListCredential(string dbname)
        {
            return this._adlaCatalogRestClientWrapper.ListCredential(this.account.GetUri(), dbname);
        }

    }
}