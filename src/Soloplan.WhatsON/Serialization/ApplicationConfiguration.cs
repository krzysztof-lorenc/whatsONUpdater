﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationConfiguration.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Soloplan.WhatsON.Serialization
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// Holds the serializable configuration.
  /// </summary>
  public class ApplicationConfiguration
  {
    /// <summary>
    /// Gets or sets a value indicating whether dark theme is enabled.
    /// </summary>
    public bool DarkThemeEnabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether icon on taskbar should be shown.
    /// </summary>
    public bool ShowInTaskbar { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether App is always on top.
    /// </summary>
    public bool AlwaysOnTop { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether App is starts up minimized.
    /// </summary>
    public bool OpenMinimized { get; set; }

    /// <summary>
    /// Gets or sets a view style, for now normal/compact are available and they only control the spacing of items.
    /// </summary>
    public ViewStyle ViewStyle { get; set; }

    /// <summary>
    /// Gets the connectors configuration.
    /// </summary>
    public IList<ConnectorConfiguration> ConnectorsConfiguration { get; } = new List<ConnectorConfiguration>();

    [Obsolete("SubjectsConfiguration was changed to ConnectorsConfiguration. This property will be deserialized to support old type configuration but will not be serialized.")]
    public IList<ConnectorConfiguration> SubjectsConfiguration
    {
      set
      {
        foreach (var item in value)
        {
          this.ConnectorsConfiguration.Add(item);
        }
      }
    }

    /// <summary>
    /// Gets the notification configuration.
    /// </summary>
    public NotificationConfiguration NotificationConfiguration { get; } = new NotificationConfiguration();
  }
}