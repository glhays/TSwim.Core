﻿// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Force.DeepCloner;
using TSwim.Core.Models.Companies;
using Xunit;
using Moq;
using FluentAssertions;

namespace TSwim.Core.Tests.Unit.Services.Foundations.Companies
{
    public partial class CompanyServiceTests
    {
        [Fact]
        public async Task ShouldAddCompanyAsync()
        {
            // given
            DateTimeOffset randomDateTime = GetRandomDateTimeOffset();
            Company randomCompany = CreateRandomCompany(randomDateTime);
            Company inputCompany = randomCompany;
            Company storageCompany = inputCompany;
            Company expectedCompany = storageCompany.DeepClone();

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTimeOffset())
                    .Returns(randomDateTime);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertCompanyAsync(inputCompany))
                    .ReturnsAsync(storageCompany);

            // when
            Company actualCompany = await this.companyService
                .AddCompanyAsync(inputCompany);

            // then
            actualCompany.Should().BeEquivalentTo(expectedCompany);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTimeOffset(),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertCompanyAsync(inputCompany),
                    Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}