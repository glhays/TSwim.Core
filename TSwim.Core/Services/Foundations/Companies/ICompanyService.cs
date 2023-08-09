// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System.Threading.Tasks;
using TSwim.Core.Models.Companies;

namespace TSwim.Core.Services.Foundations.Companies
{
    public partial interface ICompanyService
    {
        ValueTask<Company> AddCompanyAsync(Company company);
    }
}