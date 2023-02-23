﻿/*
 * Copyright (c) 2023 Proton AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using ProtonVPN.Common.Extensions;

namespace ProtonVPN.Core.OS.Net.Dns
{
    public static class DnsClientExtensions
    {
        public static async Task<string> Resolve(this IDnsClient dnsClient, string host, TimeSpan timeout)
        {
            var cts = new CancellationTokenSource();
            try
            {
                return await dnsClient.Resolve(host, cts.Token).TimeoutAfter(timeout);
            }
            catch (TimeoutException)
            {
                cts.Cancel();
                return string.Empty;
            }
        }
    }
}
