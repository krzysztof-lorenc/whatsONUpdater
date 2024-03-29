﻿namespace Soloplan.WhatsON.GUI.Common.ConnectorTreeView
{
  using System;
  using System.Xml;

  /// <summary>
  /// PlugIn which provides presentation of <see cref="ConnectorType"/> connectors.
  /// </summary>
  public interface ITreeViewPresentationPlugIn : IPlugIn
  {
    /// <summary>
    /// Gets type of connector for which this PlugIn provides presentation.
    /// </summary>
    Type ConnectorType { get; }

    /// <summary>
    /// Creates <see cref="ConnectorViewModel"/> decedent.
    /// </summary>
    /// <returns><see cref="ConnectorViewModel"/> decedent.</returns>
    ConnectorViewModel CreateViewModel();

    /// <summary>
    /// Gets the XAML file defining DataTemplet for displaying view model created by <see cref="CreateViewModel"/>.
    /// </summary>
    /// <returns>Data template.</returns>
    XmlReader GetDataTempletXaml();
  }
}