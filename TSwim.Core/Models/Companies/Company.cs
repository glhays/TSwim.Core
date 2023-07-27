// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System;
using TSwim.Core.Models.Companies.Enums;

namespace TSwim.Core.Models.Companies
{
    public class Company : IAuditable
    {
        Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDbaName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int FEIN { get; set; }
        public int SEAN { get; set; }
        public ActiveStatus Status { get; set; }
        public InventoryControlMethod ICMethod { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}