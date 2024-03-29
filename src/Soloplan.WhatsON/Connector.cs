﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Connector.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
//   Licensed under the MIT License. See License-file in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Soloplan.WhatsON
{
  using System.Collections.Generic;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;
  using NLog;

  /// <summary>
  /// The connector - represent an executable job defined by the plugin.
  /// </summary>
  [ConfigurationItem(Category, typeof(string), Priority = 1000000000)]
  public abstract class Connector
  {
    /// <summary>
    /// The redirect plugin tag.
    /// </summary>
    public const string NotificationsVisbility = "NotificationsVisbility";

    /// <summary>
    /// The category tag.
    /// </summary>
    public const string Category = "Category";

    /// <summary>
    /// Default value for max nubmer of snapshots.
    /// </summary>
    private const int MaxSnapshotsDefault = 5;

    /// <summary>
    /// Logger instance used by this class.
    /// </summary>
    private static readonly Logger log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType?.ToString());

    /// <summary>
    /// Initializes a new instance of the <see cref="Connector"/> class.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    protected Connector(ConnectorConfiguration configuration)
    {
      this.Snapshots = new List<Snapshot>();
      this.MaxSnapshots = MaxSnapshotsDefault;
      if (configuration == null)
      {
        var plugin = PluginsManager.Instance.GetPlugin(this);
        configuration = new ConnectorConfiguration(plugin.GetType().FullName);
      }

      this.ConnectorConfiguration = configuration;
    }

    /// <summary>
    /// Gets or sets the description of the connector.
    /// </summary>
    public string Description { get; set; }

    public Status CurrentStatus { get; set; }

    public int MaxSnapshots { get; set; }

    public IList<Snapshot> Snapshots { get; set; }

    /// <summary>
    /// Gets a value indicating whether this connector supports wizard.
    /// </summary>
    public bool SupportsWizard
    {
      get
      {
        var plugin = PluginsManager.Instance.GetPlugin(this);
        return plugin != null && plugin.SupportsWizard;
      }
    }

    /// <summary>
    /// Gets or sets the configuration of a connector.
    /// </summary>
    public ConnectorConfiguration ConnectorConfiguration { get; set; }

    public async Task QueryStatus(CancellationToken cancellationToken, params string[] args)
    {
      log.Trace("Querying status for connector {connector}.", new { Name = this.ConnectorConfiguration.Name, CurrentStatus = this.CurrentStatus });
      await this.ExecuteQuery(cancellationToken, args);
      log.Trace("Status for connector {connector} queried.", new { Name = this.ConnectorConfiguration.Name, CurrentStatus = this.CurrentStatus });

      if (this.CurrentStatus != null && this.ShouldTakeSnapshot(this.CurrentStatus))
      {
        log.Debug("Adding snapshot for connector {connector}", new { Name = this.ConnectorConfiguration.Name, CurrentStatus = this.CurrentStatus });
        this.AddSnapshot(this.CurrentStatus);
      }
    }

    public void AddSnapshot(Status status)
    {
      while (this.Snapshots.Count >= this.MaxSnapshots)
      {
        log.Debug("Max number of snapshots exceeded. Dequeuing snapshot.", new { Name = this.ConnectorConfiguration.Name, CurrentStatus = this.CurrentStatus });
        this.Snapshots.RemoveAt(0);
      }

      this.Snapshots.Add(new Snapshot(status));
    }

    public override string ToString()
    {
      var sb = new StringBuilder(this.ConnectorConfiguration.Name);
      if (!string.IsNullOrWhiteSpace(this.Description))
      {
        sb.Append(" - ");
        sb.Append(this.Description);
      }

      if (this.CurrentStatus != null)
      {
        sb.Append(": ");
        sb.Append(this.CurrentStatus);
      }

      return sb.ToString();
    }

    protected abstract Task ExecuteQuery(CancellationToken cancellationToken, params string[] args);

    protected virtual bool ShouldTakeSnapshot(Status status)
    {
      return false;
    }
  }
}