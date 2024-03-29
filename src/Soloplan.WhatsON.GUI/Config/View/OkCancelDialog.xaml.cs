﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OkCancelDialog.xaml.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Soloplan.WhatsON.GUI.Config.View
{
  using System.Windows.Controls;

  /// <summary>
  ///   Interaction logic for UserControl1.xaml
  /// </summary>
  public partial class OkCancelDialog : UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OkCancelDialog"/> class.
    /// </summary>
    /// <param name="question">The question.</param>
    public OkCancelDialog(string question)
    {
      this.InitializeComponent();
      this.uxQuestionTextBox.Text = question;
    }
  }
}