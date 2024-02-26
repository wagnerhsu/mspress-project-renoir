///////////////////////////////////////////////////////////////////
//
// Project RENOIR
// Release Notes Instant Reporter
//
// Reference application presented in
// Clean Architecture with .NET (MS Press) 2024
// Author: Dino Esposito
// 
//

using System.ComponentModel.DataAnnotations;
using Youbiquitous.Renoir.DomainModel.Utils;

namespace Youbiquitous.Renoir.DomainModel.Documents.Core;

/// <summary>
/// CORE-DOCUMENT-ITEM item entity (properties)
/// </summary>
public partial class CoreDocumentItem : BaseEntity
{
    /// <summary>
    /// Ctor, mostly needed for EF and to save us an entire layer of DTOs
    /// </summary>
    public CoreDocumentItem(DocumentItemType itemType = DocumentItemType.Default)
    {
        ItemType = itemType;
        Category = DocumentItemCategory.None;
        Description = itemType == DocumentItemType.Divider 
            ? InternalStrings.Text_ReleaseNote_NewSection 
            : null;
        Order = 1000;       // Ensure it goes to the bottom
    }

    /// <summary>
    /// Unique ID (autogenerated)
    /// </summary>
    public long RefId { get; set; }

    /// <summary>
    /// Reference to the parent ReleaseNote document (ID)
    /// </summary>
    public long DocumentId { get; set; }

    /// <summary>
    /// (Redundant) Reference to the product
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// Position of the item in the presentation of the parent document
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Type of line in the release note
    /// </summary>
    public DocumentItemCategory Category { get; set; }

    /// <summary>
    /// Notes
    /// </summary>
    [MaxLength(140)]
    public string Description { get; set; }

    /// <summary>
    /// Type of the item (text or divider)
    /// </summary>
    public DocumentItemType ItemType { get; set; }
}
