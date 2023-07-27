// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using FluentAssertions;
using System.Threading.Tasks;
using TSwim.Core.Tests.Acceptance.Brokers;
using Xunit;

namespace TSwim.Core.Tests.Acceptance.Apis.Homes
{
    [Collection(nameof(ApiTestCollection))]
    public partial class HomeApiTests
    {
        private readonly TSwimCoreBroker apiBroker;

        public HomeApiTests(TSwimCoreBroker apiBroker) =>
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
