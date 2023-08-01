// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System.Threading.Tasks;
using TSwim.Core.Brokers.DateTimes;
using TSwim.Core.Brokers.Loggings;
using TSwim.Core.Brokers.Storages;
using TSwim.Core.Models.Companies;

namespace TSwim.Core.Services.Foundations.Companies
{
    public partial class CompanyService : ICompanyService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public CompanyService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Company> AddCompanyAsync(Company company)
        {
            throw new System.NotImplementedException();
        }
    }
}