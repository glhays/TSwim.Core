// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using TSwim.Core.Api.Tests.Acceptance.Brokers;
using Xunit;

namespace TSwim.Core.Api.Tests.Acceptance.Apis.Homes
{
    [Collection(nameof(ApiTestCollection))]
    public class HomeApiTests
    {
        private readonly TSwimCoreApiBroker apiBroker;

        public HomeApiTests(TSwimCoreApiBroker apiBroker) =>
            this.apiBroker = apiBroker;

        [Fact]
        public async Task ShouldReturnHomeMessageAsync()
        {
            // given
            string expectedMessage =
                "Thank you Mario! But the princess is in another castle.";

            // when
            string actualMessage =
                await this.apiBroker.GetHomeMessage();

            // then
            actualMessage.Should().Be(expectedMessage);
        }
    }
}
