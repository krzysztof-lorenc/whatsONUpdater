﻿namespace Soloplan.WhatsON.GUI.Config
{
  using System;
  using System.Reflection;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Input;

  /// <summary>
  /// Interaction logic for AboutPage.xaml
  /// </summary>
  public partial class AboutPage : Page
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AboutPage"/> class.
    /// </summary>
    public AboutPage()
    {
      this.InitializeComponent();
      try
      {
        this.VersionLabel.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
      catch (Exception)
      {
        this.VersionLabel.Text = Properties.Resources.NotInstalled;
      }

      var materialDesignAssembly = Assembly.GetAssembly(typeof(MaterialDesignThemes.Wpf.DialogHost));
      this.MDIXVersionLabel.Text = materialDesignAssembly.GetName().Version.ToString();
    }

    /// <summary>
    /// Texts block link mouse up.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
    private void TextBlockLinkMouseUp(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Released && sender is TextBlock textBlock)
      {
        System.Diagnostics.Process.Start(textBlock.Text);
      }
    }

      /// <summary>
      /// Made by Soloplan link mouse up.
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
    private void MadeBySoloplanLinkMouseUp(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Released)
      {
        System.Diagnostics.Process.Start("http://www.soloplan.de");
      }
    }

      /// <summary>
      /// Report an issue link mouse up.
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
    private void ReportABugMouseUp(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Released)
      {
        System.Diagnostics.Process.Start("https://github.com/Soloplan/whatson/issues");
      }
    }

    /// <summary>
    /// Handles the MouseEnter event of the TextBlock control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    private void TextBlockMouseEnter(object sender, MouseEventArgs e)
    {
      if (sender is TextBlock textBlock)
      {
        textBlock.TextDecorations = TextDecorations.Underline;
      }
    }

    /// <summary>
    /// Handles the MouseLeave event of the TextBlock control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    private void TextBlockMouseLeave(object sender, MouseEventArgs e)
    {
      if (sender is TextBlock textBlock)
      {
        textBlock.TextDecorations = null;
      }
    }
  }
}
