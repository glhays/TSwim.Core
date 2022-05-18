// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using TSwim.Core.Infrastructure.Provision.Models.Configurations;

namespace TSwim.Core.Infrastructure.Provision.Brokers.Configuations
{
    public partial interface IConfigurationBroker
    {
        CloudManagementConfiguration GetCloudConfiguration();
    }
}
