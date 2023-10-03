// ***********************************************************************
// Assembly         : FCS.Lib.Azure
// Author           : 
// Created          : 2023 10 02 13:17
// 
// Last Modified By : root
// Last Modified On : 2023 10 02 15:24
// ***********************************************************************
// <copyright file="AzureConfigStore.cs" company="FCS">
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

public class AzureConfigStore
{
    /// <summary>
    ///     Azure Config Store Constructor
    /// </summary>
    /// <param name="baseUrl"></param>
    /// <param name="tenantId"></param>
    /// <param name="environment"></param>
    /// <param name="apiPublisher"></param>
    /// <param name="apiGroup"></param>
    /// <param name="apiVersion"></param>
    /// <param name="ledgerId"></param>
    /// <param name="oDataVersion"></param>
    public AzureConfigStore(
        string baseUrl, string tenantId, string environment,
        string apiPublisher, string apiGroup, string apiVersion,
        string ledgerId, string oDataVersion)
    {
        BaseUrl = baseUrl;
        TenantId = tenantId;
        Environment = environment;
        ApiPublisher = apiPublisher;
        ApiGroup = apiGroup;
        ApiVersion = apiVersion;
        LedgerId = ledgerId;
        ODataVersion = oDataVersion;
    }

    /// <summary>
    ///     Azure Api Group
    /// </summary>
    protected string ApiGroup { get; set; }

    /// <summary>
    ///     Azure Api
    /// </summary>
    protected string ApiPublisher { get; set; }

    /// <summary>
    ///     Azure Api Group
    /// </summary>
    protected string ApiVersion { get; set; }

    /// <summary>
    ///     Azure Base Url
    /// </summary>
    protected string BaseUrl { get; set; }

    /// <summary>
    ///     Azure Ledger Id
    /// </summary>
    protected string LedgerId { get; set; }

    /// <summary>
    ///     Azure ODate Version
    /// </summary>
    protected string ODataVersion { get; set; }

    /// <summary>
    ///     Azure Environment
    /// </summary>
    protected string Environment { get; set; }

    /// <summary>
    ///     Azure Tenant Id
    /// </summary>
    protected string TenantId { get; }

    /// <summary>
    ///     Azure Client Api Endpoint
    /// </summary>
    /// <returns></returns>
    public string AzureClientApiEndpoint()
    {
        return
            $"{BaseUrl}/{TenantId}/{Environment}/api/{ApiPublisher}/{ApiGroup}/{ApiVersion}/companies({LedgerId})";
    }

    /// <summary>
    ///     Azure OAuth Endpoint
    /// </summary>
    /// <returns></returns>
    public string AzureClientOAuthEndpoint()
    {
        return $"{BaseUrl}/{TenantId}/{Environment}/{ODataVersion}/Company('{LedgerId}')";
    }
}