// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using TSwim.Core.Infrastructure.Provision.Brokers.Clouds;
using TSwim.Core.Infrastructure.Provision.Brokers.Loggings;
using TSwim.Core.Infrastructure.Provision.Models.Storages;

namespace TSwim.Core.Infrastructure.Provision.Services.Foundations.CloudManagements
{
    public class CloudManagementService : ICloudManagementService
    {
        private readonly ICloudBroker cloudBroker;
        private readonly ILoggingBroker loggingBroker;

        public CloudManagementService()
        {
            this.cloudBroker = new CloudBroker();
            this.loggingBroker = new LoggingBroker();
        }
        public async ValueTask<IResourceGroup> ProvisionResourceGroupAsync(
            string projectName,
            string environment)
        {
            string resourceGroupName =
                $"{projectName}-RESOURCES-{environment}".ToUpper();

            this.loggingBroker.LogActivity(
                message: $"Provisioning {resourceGroupName} ...");

            IResourceGroup resourceGroup = await this.cloudBroker.CreateResourceGroupAsync(
                resourceGroupName);

            this.loggingBroker.LogActivity(
                $"Provisioning {resourceGroupName} Completed.");

            return resourceGroup;
        }

        public async ValueTask<IAppServicePlan> ProvisionAppServicePlanAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup)
        {
            string appServicePlanName =
                $"{projectName}-PLAN-{environment}".ToUpper();

            this.loggingBroker.LogActivity(
                message: $"Provisioning {appServicePlanName} ...");

            IAppServicePlan appServicePlan = await this.cloudBroker.CreatePlanAsync(
                appServicePlanName,
                resourceGroup);

            this.loggingBroker.LogActivity($"Provisioning {appServicePlanName} completed.");

            return appServicePlan;
        }

        public async ValueTask<ISqlServer> ProvisionSqlServerAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup)
        {
            string sqlServerName =
                $"{projectName}-dbserver-{environment}".ToLower();

            this.loggingBroker.LogActivity(
                message: $"Provisioning {sqlServerName} ...");

            ISqlServer sqlServer = await this.cloudBroker.CreateSqlServerAsync(
                sqlServerName,
                resourceGroup);

            this.loggingBroker.LogActivity(
                message: $"Provisioning {sqlServerName} completed.");

            return sqlServer;
        }

        public async ValueTask<SqlDatabase> ProvisionSqlDatabaseAysnc(
            string projectName,
            string environment,
            ISqlServer sqlServer)
        {
            string databaseName =
                $"{projectName}-databasename-{environment}".ToLower();

            this.loggingBroker.LogActivity(
                message: $"Provisioning {databaseName} ....");

            ISqlDatabase sqlDatabase = await this.cloudBroker.CreateSqlDatabaseAsync(
                projectName, sqlServer);

            this.loggingBroker.LogActivity(
                message: $"Provisioning {databaseName} completed.");

            return new SqlDatabase
            {
                Database = sqlDatabase,
                ConnectionString = GenerateConnectionString(sqlDatabase)
            };
        }


        public async ValueTask<IWebApp> ProvisionWebAppAsync(
            string projectName,
            string environment,
            string databaseConnectionString,
            IAppServicePlan appServicePlan,
            IResourceGroup resourceGroup)
        {
            string webAppName = $"{projectName}-{environment}".ToLower();

            this.loggingBroker.LogActivity(
                message: $"Provisioning {webAppName} ...");

            IWebApp webApp = await this.cloudBroker.CreateWebAppAsync(
                webAppName,
                databaseConnectionString,
                appServicePlan,
                resourceGroup);

            this.loggingBroker.LogActivity(
                message: $"Provisioning {webAppName} completed.");

            return webApp;

        }
        public async ValueTask DeprovisionResourceGroupAsync(
            string projectName,
            string environment)
        {
            string resourceGroupName =
                $"{projectName}-RESOURCES-{environment}".ToUpper();

            bool isResourceGroupExist =
                await this.cloudBroker.CheckResourceGroupExistAsync(resourceGroupName);

            if (isResourceGroupExist)
            {
                this.loggingBroker.LogActivity(
                    message: $"Deprovisioning {resourceGroupName}...");

                await this.cloudBroker.DeleteResourceGroupAsync(resourceGroupName);

                this.loggingBroker.LogActivity(
                    message: $"{resourceGroupName} Deprovisioned.");
            }
            else
            {
                this.loggingBroker.LogActivity(
                    message: $"Resource group {resourceGroupName} doesn't exist. No action executed.");
            }

        }

        private string GenerateConnectionString(ISqlDatabase sqlDatabase)
        {
            SqlDatabaseAccess sqlDatabaseAccess = this.cloudBroker.GetDatabaseAccess();

            return $"Server=tcp:{sqlDatabase.SqlServerName}.database.windows.net,1433;" +
                $"Initial Catalog={sqlDatabase.Name};" +
                $"User ID={sqlDatabaseAccess.AdminName};" +
                $"Password={sqlDatabaseAccess.AdminAccess};";
        }
    }
}
