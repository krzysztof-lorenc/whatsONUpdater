﻿namespace Soloplan.WhatsON.GUI.Config.View
{
  using System.Windows.Controls;
  using System.Windows.Data;
  using Soloplan.WhatsON.GUI.Config.ViewModel;

  /// <summary>
  /// Interaction logic for EditGroupNameDialog.xaml
  /// </summary>
  public partial class EditGroupNameDialog : UserControl
  {
    public EditGroupNameDialog()
    {
      this.InitializeComponent();
      this.DataContext = new GroupViewModel();
    }

    public EditGroupNameDialog(GroupViewModel model)
    : this()
    {
      this.DataContext = model;
    }

    private void OkButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
      foreach (var be in BindingOperations.GetSourceUpdatingBindings(this))
      {
        be.UpdateSource();
      }

      if (string.IsNullOrEmpty(((GroupViewModel)this.DataContext).Error))
      {
        MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(true, this);
      }
    }

    private void CancelButtonClick(object sender, System.Windows.RoutedEventArgs e)
    {
      foreach (var be in BindingOperations.GetSourceUpdatingBindings(this))
      {
        be.UpdateTarget();
      }
    }
  }
}
