﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiHelper.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Soloplan.WhatsON.Jenkins.Tests
{
  using Soloplan.WhatsON.Jenkins.Model;

  public static class ApiHelper
  {
    public static JenkinsBuild GetBuild(ObservationState state, int number)
    {
      return new JenkinsBuild
      {
        Number = number,
        Result = state.ToString(),
        Building = state == ObservationState.Running,
      };
    }

    public static JenkinsJob GetProject(ObservationState state, int lastBuildNumber, int firstBuildNumber)
    {
      return new JenkinsJob
      {
        LastBuild = GetBuild(state, lastBuildNumber),
        FirstBuild = GetBuild(state, firstBuildNumber),
      };
    }
  }
}