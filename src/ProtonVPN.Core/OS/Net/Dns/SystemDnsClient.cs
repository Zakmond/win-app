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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ProtonVPN.Core.OS.Net.Dns
{
    public class SystemDnsClient : IDnsClient
    {
        public async Task<string> Resolve(string host, CancellationToken token)
        {
            var ip = await GetHostAddress(host);
            return ip != null ? ip.ToString() : string.Empty;
        }

        public IReadOnlyCollection<IPEndPoint> NameServers => throw new NotSupportedException();

        private async Task<IPAddress> GetHostAddress(string host)
        {
            return (await System.Net.Dns.GetHostAddressesAsync(host)).FirstOrDefault();
        }
    }
}
