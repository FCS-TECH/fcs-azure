// ***********************************************************************
// Assembly         : FCS.Lib.Azure
// Author           : 
// Created          : 2023 10 02 13:19
// 
// Last Modified By : root
// Last Modified On : 2023 10 02 15:24
// ***********************************************************************
// <copyright file="AzureTokenHttpRequest.cs" company="FCS">
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

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FCS.Lib.Common;

namespace FCS.Lib.Azure;

public class AzureTokenHttpRequest
{
    public static async Task<HttpResponseView> RequestTokenAsync(AzureAuthStore auth)
    {
        var credentials = new Dictionary<string, string>
        {
            { "grant_type", auth.AzureGrantType },
            { "client_id", auth.AzureClientId },
            { "client_secret", auth.AzureClientSecret },
            { "scope", auth.AzureLoginScope }
        };

        using var client = new HttpClient();
        //using var azureRequest = new HttpRequestMessage(HttpMethod.Post, auth.AzureTokenEndpoint());
        //azureRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var content = new FormUrlEncodedContent(credentials);

        // todo - check for network connection - mitigate server fail
        var responseMessage = await client.PostAsync(auth.AzureTokenEndpoint(), content).ConfigureAwait(true);

        var azureResponse = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(true);

        return new HttpResponseView
        {
            Code = responseMessage.StatusCode,
            IsSuccessStatusCode = responseMessage.IsSuccessStatusCode,
            Message = azureResponse
        };
    }
}