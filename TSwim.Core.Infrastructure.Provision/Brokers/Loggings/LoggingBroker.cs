﻿// -----------------------------------------------------------------------------------
// Participation to the Coalition of the Good-Hearted Engineers WorldWide
// Copyright © TSwim and contributors. All rights reserved.
// GLHays ©2022 Founder,Developer - (TS)Warehouse Inventory Management
// Licensed under the MIT license. See LICENSE file in the project root for details.
// -----------------------------------------------------------------------------------

using System;

namespace TSwim.Core.Infrastructure.Provision.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        public void LogActivity(string message) =>
            Console.WriteLine(message);
    }
}
