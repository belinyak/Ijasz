   M S B A M L   `   `   `  ����A  =Ijasz2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Ijasz2.Megjelenites.InduloIjasz2.Megjelenites.Indulo  5   	   0    *Ijasz2.Megjelenites.Indulo.Indulo_Csapatok   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Ijasz2.Megjelenites.Indulo     5   	     � Title$  Csapatok��5   	   $	��500��6   $	��650��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Csapatok��5      $��Stretch=�6%   $��0��6C   $��0,0,5,0q�6S      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   CanUserSort .     CanUserReorder .     CanUserResize .  	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6y   
   Header$
 Csapat��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   Z� 6�     5       .   .   .  $		 100 6y   $
 Indulók száma��6�    6%   Z� 6�   5        5   
   -   5        $ Indulok��5      $��Stretch=�6$   $��1��6B   $��5,0,0,0q�6R    5        5       .   .   .  $		 100 6y   $
 Csapat��6�    6%   Z� 6�     5       .   .   .  $		 100 6y   $

 Név��6�    6%   Z� 6�     5       .   .   .  $		 100 6y   $
 	Íjtípus��6�    6%   Z� 6�     5       .   .   .  $	 40 6y   $	
 Kor��6�    6%   Z� 6�     5       .   .   .  $		 100 6y   $
 
Egyesület��6�    6%   Z� 6�   5      5      5      