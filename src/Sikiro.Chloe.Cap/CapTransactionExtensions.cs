﻿using System.Data;
using DotNetCore.CAP;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Cap的事务开启扩展
/// </summary>
internal static class CapTransactionExtensions
{
    /// <summary>
    /// Start the CAP transaction
    /// </summary>
    /// <param name="dbConnection">The <see cref="IDbConnection" />.</param>
    /// <param name="dbTransaction"></param>
    /// <param name="publisher">The <see cref="ICapPublisher" />.</param>
    /// <param name="autoCommit">Whether the transaction is automatically committed when the message is published</param>
    /// <returns>The <see cref="ICapTransaction" /> object.</returns>
    public static ICapTransaction BeginCapTransaction(this IDbConnection dbConnection, IDbTransaction dbTransaction,
        ICapPublisher publisher, bool autoCommit = false)
    {
        publisher.Transaction.Value = publisher.ServiceProvider.GetService<CapTransactionBase>();
        return publisher.Transaction.Value.Begin(dbTransaction, autoCommit);
    }
}