   M S B A M L   `   `   `  ���� A  =Ijasz2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Ijasz2.Megjelenites.InduloIjasz2.Megjelenites.Indulo  0    *Ijasz2.Megjelenites.Indulo.Indulo_Csapatok   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:Ijasz2.Megjelenites.Indulo       � Title$  Csapatok��$	��500��$	��650�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -     Name$ Csapatok��$��Stretch=�$��0��$��0,0,5,0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   CanUserSort .     CanUserReorder .     CanUserResize .  	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 
   Header$
 Csapat��1  +System.Windows.Controls.DataGridBoundColumn   Binding Z�    .   .   .  $		 100 $
 Indulók száma�� Z�   -   $ Indulok��$��Stretch=�$��1��$��5,0,0,0q�    .   .   .  $		 100 $
 Csapat�� Z�    .   .   .  $		 100 $

 Név�� Z�    .   .   .  $		 100 $
 	Íjtípus�� Z�    .   .   .  $	 40 $	
 Kor�� Z�    .   .   .  $		 100 $
 
Egyesület�� Z� 