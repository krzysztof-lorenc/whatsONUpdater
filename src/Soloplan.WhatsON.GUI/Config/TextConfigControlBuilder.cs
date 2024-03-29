﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextConfigControlBuilder.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Soloplan.WhatsON.GUI.Config
{
  using System.Windows;
  using System.Windows.Controls;
  using MaterialDesignThemes.Wpf;

  /// <summary>
  /// The control builder for a text edit control.
  /// </summary>
  /// <seealso cref="Soloplan.WhatsON.GUI.Config.IConfigControlBuilder" />
  public class TextConfigControlBuilder : ConfigControlBuilder
  {
    /// <summary>
    /// Gets the supported configuration items key.
    /// </summary>
    public override string SupportedConfigurationItemsKey => null;

    public override DependencyProperty ValueBindingDependencyProperty => TextBox.TextProperty;

    /// <summary>
    /// Creates a new control and returns it.
    /// </summary>
    /// <param name="configItem">The configuration item of the connector.</param>
    /// <param name="configItemAttribute">The configuration item attribute.</param>
    /// <returns>
    /// Returns the <see cref="FrameworkElement" /> for the <see cref="configItem" />.
    /// </returns>
    public override FrameworkElement GetControlInternal(IConfigurationItem configItem, ConfigurationItemAttribute configItemAttribute)
    {
      var textBox = new TextBox();
      textBox.DataContext = configItem;
      var style = Application.Current.FindResource("MaterialDesignFloatingHintTextBox") as Style;
      textBox.Style = style;
      HintAssist.SetIsFloating(textBox, true);
      HintAssist.SetHint(textBox, configItemAttribute.Caption);
      return textBox;
    }
  }
}