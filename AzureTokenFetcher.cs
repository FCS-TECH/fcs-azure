// ***********************************************************************
// Assembly         : FCS.Lib.Azure
// Author           : 
// Created          : 2023 10 02 13:25
// 
// Last Modified By : root
// Last Modified On : 2023 10 02 15:24
// ***********************************************************************
// <copyright file="AzureTokenFetcher.cs" company="FCS">
//     Copyright (C) 2023-2023 FCS Frede's Computer Services.
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as
//     published by the Free Software Foundation, either version 3 of the
//     License, or (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
// 
//     You should have received a copy of the GNU Affero General Public License
//     along with this program.  If not, see [https://www.gnu.org/licenses]
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;
using FCS.Lib.Azure;

namespace Inno.Azure;

/// <summary>
///     Implements IAzureTokenFetcher
/// </summary>
public class AzureTokenFetcher : IAzureTokenFetcher
{
    private readonly AzureAuthStore _config;

    /// <summary>
    ///     Construct a new Azure Token Fetcher from configuration
    /// </summary>
    /// <param name="config"></param>
    public AzureTokenFetcher(AzureAuthStore config)
    {
        _config = config;
    }

    /// <summary>
    ///     Fetch Azure Token
    /// </summary>
    /// <returns></returns>
    public async Task<AzureToken> FetchAzureToken()
    {
        var result = await AzureTokenHttpRequest.RequestTokenAsync(_config).ConfigureAwait(true);
        return !result.IsSuccessStatusCode
            ? new AzureToken { Expires = -1 }
            : new AzureTokenMapper().MapAzureToken(result.Message);
    }
}