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
using TSwim.Core.Infrastructure.Provision.Models.Storages;

namespace TSwim.Core.Infrastructure.Provision.Services.Foundations.CloudManagements
{
    public interface ICloudManagementService
    {
        ValueTask<IResourceGroup> ProvisionResourceGroupAsync(
            string projectName,
            string environment);

        ValueTask<IAppServicePlan> ProvisionAppServicePlanAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup);

        ValueTask<ISqlServer> ProvisionSqlServerAsync(
            string projectName,
            string environment,
            IResourceGroup resourceGroup);

        ValueTask<SqlDatabase> ProvisionSqlDatabaseAysnc(
            string projectName,
            string environment,
            ISqlServer sqlServer);
    
        ValueTask<IWebApp> ProvisionWebAppAsync(
            string projectName,
            string environment,
            string databaseConnectionString,
            IAppServicePlan appServicePlan,
            IResourceGroup resourceGroup);

        ValueTask DeprovisionResourceGroupAsync(
            string projectName,
            string environment);

    }
}
