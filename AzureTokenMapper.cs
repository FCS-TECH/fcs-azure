// ***********************************************************************
// Assembly         : FCS.Lib.Azure
// Author           : FH
// Created          : 05-08-2022
//
// Last Modified By : FH
// Last Modified On : 05-10-2022
// ***********************************************************************
// <copyright file="AzureTokenMapper.cs" company="FCS-TECH">
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


using System;
using System.Text.Json;
using FCS.Lib.Common;
using FCS.Lib.Utility;

namespace FCS.Lib.Azure
{
    public class AzureTokenMapper
    {
        public AzureToken MapAzureToken(string json)
        {
            if(string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException(nameof(json));

            var token = JsonSerializer.Deserialize<AzureTokenDto>(json);
            return token == null ? null : new AzureToken
            {
                AccessToken = token.AccessToken,
                Expires = Mogrify.CurrentDateTimeToTimeStamp() + token.ExtExpiresIn - 600,
                TokenType = token.TokenType
            };
        }
    }
}