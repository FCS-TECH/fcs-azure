// ***********************************************************************
// Assembly         : FCS.Lib.Azure
// Author           : 
// Created          : 2023 10 02 13:17
// 
// Last Modified By : root
// Last Modified On : 2023 10 02 15:24
// ***********************************************************************
// <copyright file="AzureAuthStore.cs" company="FCS">
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

namespace FCS.Lib.Azure;

public class AzureAuthStore
{
    /// <summary>
    ///     Azure Auth Store Constructor
    /// </summary>
    /// <param name="azureLoginUrl"></param>
    /// <param name="azureOAuthEndpoint"></param>
    /// <param name="azureTenantId"></param>
    /// <param name="azureClientId"></param>
    /// <param name="azureGrantType"></param>
    /// <param name="azureClientSecret"></param>
    /// <param name="azureLoginScope"></param>
    public AzureAuthStore(
        string azureLoginUrl, string azureOAuthEndpoint, string azureTenantId,
        string azureClientId, string azureGrantType, string azureClientSecret,
        string azureLoginScope)
    {
        AzureLoginUrl = azureLoginUrl;
        AzureOAuthEndpoint = azureOAuthEndpoint;
        AzureTenantId = azureTenantId;
        AzureClientId = azureClientId;
        AzureGrantType = azureGrantType;
        AzureClientSecret = azureClientSecret;
        AzureLoginScope = azureLoginScope;
    }

    /// <summary>
    ///     Azure Client Id
    /// </summary>
    public string AzureClientId { get; }

    /// <summary>
    ///     Azure Client Secret
    /// </summary>
    public string AzureClientSecret { get; }

    /// <summary>
    ///     Azure Grant Type
    /// </summary>
    public string AzureGrantType { get; }

    /// <summary>
    ///     Azure Login Scope
    /// </summary>
    public string AzureLoginScope { get; }

    /// <summary>
    ///     Azure Login Url
    /// </summary>
    protected string AzureLoginUrl { get; set; }

    /// <summary>
    ///     Azure OAuth Endpoint
    /// </summary>
    protected string AzureOAuthEndpoint { get; set; }

    /// <summary>
    ///     Azure Tenant Id
    /// </summary>
    protected string AzureTenantId { get; }

    public string AzureTokenEndpoint()
    {
        return $"{AzureLoginUrl}/{AzureTenantId}/{AzureOAuthEndpoint}";
    }
}