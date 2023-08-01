// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TSwim.Core.Models.Companies;

namespace TSwim.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Company> Companies { get; set; }

        public async ValueTask<Company> InsertCompanyAsync(Company company)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Company> companyEntityEntry =
                await broker.Companies.AddAsync(company);

            await broker.SaveChangesAsync();

            return companyEntityEntry.Entity;
        }

        public IQueryable<Company> SelectAllCompanies()
        {
            using var broker = new StorageBroker(this.configuration);

            return broker.Companies;
        }
    }
}