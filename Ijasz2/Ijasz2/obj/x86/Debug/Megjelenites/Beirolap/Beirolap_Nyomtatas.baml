   M S B A M L   `   `   `  ����A  =Ijasz2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Ijasz2.Megjelenites.BeirolapIjasz2.Megjelenites.Beirolap  5   	   5    /Ijasz2.Megjelenites.Beirolap.Beirolap_Nyomtatas   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Ijasz2.Megjelenites.Beirolap     5   	     � Title$  Beírólap nyomtatás��5   	   $	��130��6$   $	��300��61    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��Biztosan nyomtatni akar?��6   $��0��63   $��0��6@   $��3��6P   $��Center=�5   
   $��Center=�6'   �� 5   
   -   5         ��Name$ 
IgenButton��5      $
��Igen��6%   $��1��64   $��0��6A   $��Center=�6Q   $	��Top=�5      $��86��6#   $��28��6.   6:   �� 5   
   -   5        $ 	NemButton��5      $	��Nem��6$   $��1��62   $��1��6?   $��Center=�6O   $	��Top=�5      $��86��6#   $��28��6.   6:   �� 5   
   -   5        $ MegnyitasButton��5      $��
Megnyitás��6+   $��1��6?   $��2��6L   $��Center=�6\   $	��Top=�5      $��86��6#   $��28��6.   6:   5      5      