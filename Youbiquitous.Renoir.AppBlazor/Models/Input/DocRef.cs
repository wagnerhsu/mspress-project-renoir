﻿///////////////////////////////////////////////////////////////////
//
// Project RENOIR
// Release Notes Instant Reporter
//
// Reference application presented in
// Clean Architecture with .NET (MS Press) 2024
// Author: Dino Esposito
// 


using Youbiquitous.Martlet.Core.Extensions;
using Youbiquitous.Martlet.Core.Types;
using Youbiquitous.Renoir.Resources;

namespace Youbiquitous.Renoir.AppBlazor.Models.Input;


/// <summary>
/// DTO to bring data to and from the DocumentEditor form
/// </summary>
public class DocRef : DtoBase
{
    public string Version { get; set; }

    /// <summary>
    /// Whether data is acceptable for a User reference
    /// </summary>
    /// <returns></returns>
    public override bool IsValid()
    {
        return !Version.IsNullOrWhitespace();
    }

    /// <summary>
    /// Whether data is acceptable for a User reference
    /// </summary>
    /// <returns></returns>
    public override CommandResponse Validate()
    {
        if (Version.IsNullOrWhitespace())
            return CommandResponse.Fail().AddMessage(AppMessages.Err_MissingVersion);

        return CommandResponse.Ok();
    }
}