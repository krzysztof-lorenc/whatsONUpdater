﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JenkinsJob.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Soloplan.WhatsON.Jenkins.Model
{
  using Newtonsoft.Json;

  /// <summary>
  /// The Jenkins job.
  /// </summary>
  public class JenkinsJob
  {
    /// <summary>
    /// The request properties for the server query.
    /// </summary>
    public const string RequestProperties = "displayName,lastBuild[number],firstBuild[number],_class,name,url";

    /// <summary>
    /// Gets or sets the job display name.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the last build.
    /// </summary>
    public JenkinsBuild LastBuild { get; set; }

    /// <summary>
    /// Gets or sets the first build.
    /// </summary>
    public JenkinsBuild FirstBuild { get; set; }

    /// <summary>
    /// Gets or sets the job name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the job URL.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the job class name.
    /// </summary>
    [JsonProperty("_class")]
    public string ClassName { get; set; }
  }
}
