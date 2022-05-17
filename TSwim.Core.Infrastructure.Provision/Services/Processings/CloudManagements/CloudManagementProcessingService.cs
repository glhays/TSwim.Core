// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Sql.Fluent;
using TSwim.Core.Infrastructure.Provision.Brokers.Configuations;
using TSwim.Core.Infrastructure.Provision.Models.Configurations;
using TSwim.Core.Infrastructure.Provision.Models.Storages;
using TSwim.Core.Infrastructure.Provision.Services.Foundations.CloudManagements;

namespace TSwim.Core.Infrastructure.Provision.Services.Processings.CloudManagements
{
    public class CloudManagementProcessingService : ICloudManagementProcessingService
    {
        private readonly ICloudManagementService cloudManagementService;
        private readonly IConfigurationBroker configurationBroker;

        public CloudManagementProcessingService()
        {
            this.cloudManagementService = new  CloudManagementService();
            this.configurationBroker = new ConfigurationBroker();
        }

        public async ValueTask ProcessAsync()
        {
            CloudManagementConfiguration cloudManagementConfiguration =
                this.configurationBroker.GetCloudConfiguration();

            await ProvisionAsync(
                    projectName: cloudManagementConfiguration.ProjectName,
                    cloudAction: cloudManagementConfiguration.Up);
        }

        private async ValueTask ProvisionAsync(
            string projectName,
            CloudAction cloudAction)
        {
            IList<string> environments = RetrieveEnvironments(cloudAction);

            foreach (string environmentName in environments)
            {
                IResourceGroup resourceGroup = await this.cloudManagementService
                    .ProvisionResourceGroupAsync(
                        projectName,
                        environmentName);

                IAppServicePlan appServicePlan = await this.cloudManagementService
                    .ProvisionAppServicePlanAsync(
                        projectName,
                        environmentName,
                        resourceGroup);

                ISqlServer sqlServer = await this.cloudManagementService
                    .ProvisionSqlServerAsync(
                        projectName,
                        environmentName,
                        resourceGroup);

                SqlDatabase sqlDatabase = await this.cloudManagementService
                    .ProvisionSqlDatabaseAysnc(
                        projectName,
                        environmentName,
                        sqlServer);

                IWebApp webApp = await this.cloudManagementService
                    .ProvisionWebAppAsync(
                        projectName,
                        environmentName,
                        sqlDatabase.ConnectionString,
                        appServicePlan,
                        resourceGroup);
            }
        }

        private static List<string> RetrieveEnvironments(CloudAction cloudAction) =>
            cloudAction?.Environments ?? new List<string>();
    }
}
