// ***********************************************************************
// Assembly         : FCS.Lib.Azure
// Author           : FH
// Created          : 05-10-2022
//
// Last Modified By : FH
// Last Modified On : 05-10-2022
// ***********************************************************************
// <copyright file="AzureTokenHttpRequest.cs" company="FCS-TECH">
//    Copyright (C) 2022 FCS Frede's Computer Services.
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Affero General Public License as
//    published by the Free Software Foundation, either version 3 of the
//    License, or (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Affero General Public License for more details.
//
//    You should have received a copy of the GNU Affero General Public License
//    along with this program.  If not, see [https://www.gnu.org/licenses]
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FCS.Lib.Azure
{
    public class AzureTokenHttpRequest
    {
        public static async Task<ResponseView> RequestTokenAsync(AzureAuthStore azureAuth)
        {
            var credentials = new Dictionary<string, string>
            {
                { "grant_type", azureAuth.AzureGrantType },
                { "client_id", azureAuth.AzureClientId },
                { "client_secret", azureAuth.AzureSecret },
                { "scope", azureAuth.AzureLoginScope}
            };

            using var client = new HttpClient();

            var content = new FormUrlEncodedContent(credentials);

            var responseMessage = await client.PostAsync(azureAuth.AzureTokenEndpoint(), content).ConfigureAwait(true);

            var azureResponse = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(true);

            return new ResponseView
            {
                Code = responseMessage.StatusCode,
                IsSuccessStatusCode = responseMessage.IsSuccessStatusCode,
                Message = azureResponse
            };
        }
    }
}
