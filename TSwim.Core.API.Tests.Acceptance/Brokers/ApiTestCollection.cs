// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using Xunit;

namespace TSwim.Core.Api.Tests.Acceptance.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection : ICollectionFixture<ApiBroker> { }
}
