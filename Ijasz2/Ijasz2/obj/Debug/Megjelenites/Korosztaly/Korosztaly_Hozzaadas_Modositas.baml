   M S B A M L   `   `   `  ����A  =Ijasz2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Ijasz2.Megjelenites.KorosztalyIjasz2.Megjelenites.Korosztaly  5   	   C    =Ijasz2.Megjelenites.Korosztaly.Korosztaly_Hozzaadas_Modositas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Ijasz2.Megjelenites.Korosztaly     5   	     � Title$  Korosztály��5      $	��298��6   $	��220��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U   .��5	      �  � RowDefinitions 5
   
   �� 5      $��32 �6   6*   �� 5      $��32 �6   6*   �� 5      $��32 �6   6*   �� 5      $��32 �6   6*   �� 5      $��32 �6   6*   �� 5      $��32 �6   6*   �� 5      $��32 �6   6*   �� 5      $��32 �6   6*    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   .+�5   
   �� -   5         ��Name$ lblAzonosito��5      $��Azonosító:��6&   $��0��6;   $��0��6H   $��Stretch=�6X   $��Center=�6v   �� 5   
   -   5        $ lblMegnevezes��5      $��Megnevezés:��6'   $��1��6=   $��0��6J   $��Stretch=�6Z   $��Center=�6x   �� 5   
   -   5        $ lblAlso��5      $��Alsó:��6!   $��2��61   $��0��6>   $��Stretch=�6N   $��Center=�6l   �� 5   
   -   5        $ lblFelso��5      $��Felső:��6"   $��3��63   $��0��6@   $��Stretch=�6P   $��Center=�6n   �� 5   
   -   5        $ lblNok��5      $��Nők:��6    $��4��6/   $��0��6<   $��Stretch=�6L   $��Center=�6j   �� 5   
   -   5        $ 
lblFerfiak��5      $��	Férfiak:��6$   $��5��67   $��0��6D   $��Stretch=�6T   $��Center=�6r   �� 5   
   -   5        $ 	lblEgyben��5      $��Egyben:��6#   $��6��65   $��0��6B   $��Stretch=�6R   $��Center=�6p   �� 5   
   -   5         ��Name$ txtAzonosito��5      $��0��6(   $��1��65   $
��Left=�6E   $��Center=�6`   $	��120��6{   $��23��6�    �� TextWrapping$
 Wrap=�6�   �� 5    
   -	   5        $ txtMegnevezes��5       $��1��6)   $��1��66   $
��Left=�6F   $��Center=�6a   $	��120��6|   $��23��6�   $
 Wrap=�6�   �� 5!   
   -
   5        $ txtAlso��5!      $��2��6#   $��1��60   $
��Left=�6@   $��Center=�6[   $	��120��6v   $��23��6�   $
 Wrap=�6�   �� 5"   
   -   5        $ txtFelso��5"      $��3��6$   $��1��61   $
��Left=�6A   $��Center=�6\   $	��120��6w   $��23��6�   $
 Wrap=�6�   �� 5#   
   -   5         ��Name$ chNok��5#      $��4��6"   $��1��6/   $
��Left=�6?   $��Center=�6Z   �� 5$   
   -   5        $ 	chFerfiak��5$      $��5��6&   $��1��63   $
��Left=�6C   $��Center=�6^   �� 5%   
   -   5        $ chEgyben��5%      $��6��6%   $��1��62   $
��Left=�6B   $��Center=�6]   �� 5&   
   -   5        	 ��Name$	 
btnRendben��5&      $��Rendben��6%   $��7��67   $��1��6D   $��Right=�6T   $��Bottom=�6p   $��86��6�   $��28��6�   6�   5'      5(      