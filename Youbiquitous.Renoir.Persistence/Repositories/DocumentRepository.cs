﻿///////////////////////////////////////////////////////////////////
//
// Project RENOIR
// Release Notes Instant Reporter
//
// Reference application presented in
// Clean Architecture with .NET (MS Press) 2024
// Author: Dino Esposito
// 
//


using Microsoft.EntityFrameworkCore;
using Youbiquitous.Martlet.Core.Types;
using Youbiquitous.Renoir.DomainModel.Documents;
using Youbiquitous.Renoir.Resources;

namespace Youbiquitous.Renoir.Persistence.Repositories;

/// <summary>
/// Repository for document entities
/// </summary>
public partial class DocumentRepository
{
    /// <summary>
    /// Retrieves given document
    /// </summary>
    /// <param name="refId"></param>
    /// <returns></returns>
    public static ReleaseNote FindById(long refId)
    {
        try
        {
            using var db = new RenoirDatabase();
            var doc = db.ReleaseNotes
                .Include(r => r.Items)
                .Include(r => r.RelatedProduct)
                .SingleOrDefault(r => r.RefId == refId && !r.Deleted);
            return doc;
        }
        catch (Exception ex)
        {
            var x = ex.Message;
            return null;
        }
    }

    /// <summary>
    /// Retrieves list of documents the user can access for the given product
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="productId"></param>
    /// <returns></returns>
    public static IEnumerable<ReleaseNote> FindAll(long userId, long productId)
    {
        try
        {
            using var db = new RenoirDatabase();
            var product = db.Products
                .Include(p => p.Users)
                .SingleOrDefault(p => p.ProductId == productId);
            if (product == null || !product.AccessibleBy(userId))
                return new List<ReleaseNote>();

            var docs = db.ReleaseNotes
                .Include(r => r.Items)
                .Where(r => r.ProductId == productId && 
                            !r.Deleted)
                .ToList();
            return docs;
        }
        catch (Exception ex)
        {
            var x = ex.Message;
            return null;
        }
    }

    /// <summary>
    /// Retrieves the list of all documents for the product
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public static IEnumerable<ReleaseNote> FindAll(long productId)
    {
        try
        {
            using var db = new RenoirDatabase();
            var docs = db.ReleaseNotes
                .Include(r => r.Items)
                .Where(r => r.ProductId == productId && 
                            !r.Deleted)
                .ToList();
            return docs;
        }
        catch (Exception ex)
        {
            var x = ex.Message;
            return null;
        }
    }
}