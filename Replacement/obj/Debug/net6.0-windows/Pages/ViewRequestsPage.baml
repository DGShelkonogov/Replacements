   M S B A M L   `   `   `  ????F  BReplacement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Replacement.PagesReplacement.Pages  5      (    "Replacement.Pages.ViewRequestsPage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Replacement.Pages     5        N? 
Background
  ????? N? Title$ ViewRequestsPage??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      ?? 5      $??50 ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$	 dtg??5      $??1??5       ?? SelectedItem$ dtg_Selected??5         CanUserAddRows$ False??5         AutoGenerateColumns$ False??5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ наименование??5   !   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5   !   ?? 
 ?? Path$

 Text?  5      $ Дата??5   !   	 5   !   ?? $
 DateTime?  5      $ Пользователь??5    !   	 5!   !   ?? $
 	User.Name?5#      ?? 5$   
   -   5        $??1??5$      $.??(Отметить как принятую??6   6>   5%      5&      