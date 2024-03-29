﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CruiseControlTreViewPresentationPlugIn.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
//   Licensed under the MIT License. See License-file in the project root for license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Soloplan.WhatsON.CruiseControl.GUI
{
  using System;
  using System.IO;
  using System.Text;
  using System.Xml;
  using Soloplan.WhatsON.GUI.Common.ConnectorTreeView;

  public class CruiseControlTreViewPresentationPlugIn : ITreeViewPresentationPlugIn
  {
    public Type ConnectorType => typeof(CruiseControlProject);

    public ConnectorViewModel CreateViewModel()
    {
      return new CruiseControlProjectViewModel();
    }

    public XmlReader GetDataTempletXaml()
    {
      return XmlReader.Create(new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.CcProjectDataTemplate)));
    }
  }
}