// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System.IO;
using Microsoft.Extensions.Configuration;
using TSwim.Core.Infrastructure.Provision.Models.Configurations;

namespace TSwim.Core.Infrastructure.Provision.Brokers.Configuations
{
    public partial class ConfigurationBroker : IConfigurationBroker
    {
        public CloudManagementConfiguration GetCloudConfiguration()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(basePath: Directory.GetCurrentDirectory())
            .AddJsonFile(path: "appSettings.json", optional: false)
            .Build();

            return configurationRoot.Get<CloudManagementConfiguration>();
        }
    }
}
