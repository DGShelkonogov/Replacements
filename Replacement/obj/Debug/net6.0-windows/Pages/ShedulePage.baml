   M S B A M L   `   `   `  ????F  BReplacement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Replacement.PagesReplacement.Pages  5      7 clr-namespace:Replacement.ModelsReplacement.Models  5	      #    Replacement.Pages.ShedulePage   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Replacement.Pages     5      3models clr-namespace:Replacement.Models     5	        N? 
Background
  ????? N? Title$ ShedulePage??5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      .+?5   
   ?? -   5         ??Name$ 	cmbGroups??5       ?? DisplayMemberPath$
 Name??5      $??1,1,1,1q?5      ?? 5   
   -   5        $??1??5      $??Сохранить??5      5      ? 5   
   $??2??6   .+?5      ?? -   5         ??Name$ listShedules??5      ??5       ?? 5!      .R?5"      ?? $??5q?6%   .+?5#      ?? $??16(?6(   $
??Left=?6V   $??10,0,0,0q?6q   ??66   ??  ?? Path$ 	DayOfWeek?6q   ?? 5$      ??6&   ?? $ Lessions???5%   "   ?? 5&   &   .R?5'   *   ?  ? ColumnDefinitions 5(   .   ?? 5)   2   $??30 ?6C   ?? 5*   2   ?? 5+   2   ?? 5,   2   .+?5.   .   ?? $??16(?5/   1   $??0??6?   $??	10,0,10,0q?51   1   $
??Left=?52   1   ??50   1   ?? $ LessionNumber?52   1   ?? 53   .   $??16(?54   1   $??1??6?   $
 Name??56   1   $	??200??57   1   $??	10,0,10,0q?58   1   $??Center=?5:   1   ??55   1   ?? #   Replacement.Models.DataSourse   Subjects	 ?? Source#	 Z 
 ?? SelectedItem
 59   1   ?? $ Subject?5:   1   ?? 5;   .   $??16(?5<   1   $??2??6?   $
 Name??5>   1   $	??200??5?   1   $??	10,0,10,0q?5@   1   $??Center=?5B   1   ??5=   1   ??    Users#	 Z 
 5A   1   ?? $
 User?5B   1   ?? 5C   .   -   5        $??16(?5D   1   $??3??5E   1   $??	10,0,10,0q?5F   1   $??Удалить??5G   1   $??Right=?5I   1   
 ? Tag 5D   ?   ?? 5I   1   5J   +   5K   '   5M      5N      5O      5Q      5R      5S      5T      