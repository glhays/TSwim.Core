﻿// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System.Threading.Tasks;

namespace TSwim.Core.Tests.Acceptance.Brokers
{
    public partial class TSwimCoreBroker
    {
        private const string HomeRelativeUrl = "api/home";

        public async ValueTask<string> GetHomeMessage() =>
            await this.apiFactoryClient.GetContentStringAsync(HomeRelativeUrl);
    }
}
