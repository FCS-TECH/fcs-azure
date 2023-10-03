// ***********************************************************************
// Assembly         : FCS.Lib.Azure
// Author           : 
// Created          : 2023 10 02 13:17
// 
// Last Modified By : root
// Last Modified On : 2023 10 02 15:24
// ***********************************************************************
// <copyright file="AzureToken.cs" company="FCS">
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

public class AzureToken
{
    /// <summary>
    ///     Token Type
    /// </summary>
    public string TokenType { get; set; } = "";

    /// <summary>
    ///     Access Token
    /// </summary>
    public string AccessToken { get; set; } = "";

    /// <summary>
    ///     Expires
    /// </summary>
    public long Expires { get; set; }

    /// <summary>
    ///     Token Has Expired
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns></returns>
    public bool HasExpired(long timestamp)
    {
        return timestamp > Expires;
    }
}