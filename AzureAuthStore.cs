// ***********************************************************************
// Assembly         : FCS.Lib.Azure
// Author           : FH
// Created          : 05-10-2022
//
// Last Modified By : FH
// Last Modified On : 05-10-2022
// ***********************************************************************
// <copyright file="AzureAuthStore.cs" company="FCS-TECH">
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

namespace FCS.Lib.Azure
{
    public class AzureAuthStore
    {
        public AzureAuthStore(
            string azureLoginUrl, string azureOAuthEndpoint, string azureLoginScope, string azureGrantType, 
            string azureTenantId, string azureClientId, string azureSecret)
        {
            AzureLoginUrl = azureLoginUrl;
            AzureOAuthEndpoint = azureOAuthEndpoint;
            AzureTenantId = azureTenantId;
            AzureClientId = azureClientId;
            AzureGrantType = azureGrantType;
            AzureSecret = azureSecret;
            AzureLoginScope = azureLoginScope;
        }

        protected string AzureLoginUrl { get; set; }
        protected string AzureOAuthEndpoint { get; set; }
        protected string AzureTenantId { get;}
        public string AzureClientId { get;}
        public string AzureGrantType { get;}
        public string AzureSecret { get; }
        public string AzureLoginScope { get; }

        public string AzureTokenEndpoint()
        {
            return $"{AzureLoginUrl}/{AzureTenantId}/{AzureOAuthEndpoint}";
        }
    }
}