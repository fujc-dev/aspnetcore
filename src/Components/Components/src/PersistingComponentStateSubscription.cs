// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.Components.Infrastructure;

namespace Microsoft.AspNetCore.Components;

/// <summary>
/// Represents a subscription to the <c>OnPersisting</c> callback that <see cref="ComponentStatePersistenceManager"/> callback will trigger
/// when the application is being persisted.
/// </summary>
public readonly struct PersistingComponentStateSubscription : IDisposable
{
    private readonly List<PersistentComponentState.RegistrationContext>? _callbacks;
    private readonly PersistentComponentState.RegistrationContext? _callback;

    internal PersistingComponentStateSubscription(
        List<PersistentComponentState.RegistrationContext> callbacks,
        PersistentComponentState.RegistrationContext callback)
    {
        _callbacks = callbacks;
        _callback = callback;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_callback.HasValue)
        {
            _callbacks?.Remove(_callback.Value);
        }
    }
}
