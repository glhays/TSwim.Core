// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace TSwim.Core.Infrastructure.Provision.Services.Foundations.CloudManagements
{
    public interface ICloudManagementService
    {
        ValueTask<IResourceGroup> ProvisionResourceGroupAsync(
            string projectName,
            string environment);
    }
}
