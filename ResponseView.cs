﻿// ***********************************************************************
// Assembly         : Inno.Business
// Filename         : ResponseView.cs
// Author           : Frede Hundewadt
// Created          : 2023 12 05 09:34
// 
// Last Modified By : root
// Last Modified On : 2024 03 29 12:28
// ***********************************************************************
// <copyright company="FCS">
//     Copyright (C) 2023-2024 FCS Frede's Computer Service.
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

using System.Net;

namespace FCS.Lib.Azure
{
    public class ResponseView
    {
        public HttpStatusCode Code { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public string Message { get; set; } = "";
    }
}