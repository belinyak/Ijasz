   M S B A M L   `   `   `  ���� A  =Ijasz2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Ijasz2.Megjelenites.InduloIjasz2.Megjelenites.Indulo  ;    5Ijasz2.Megjelenites.Indulo.Indulo_Hozzaadas_Modositas   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:Ijasz2.Megjelenites.Indulo       � Title$  Induló��$	��280��$	��245�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $��32 ��� $��32 ��� $��32 ��� $��32 ��� $��32 ��� $��32 ��� $��32 � � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+��� -    ��Name$ lblNev��$��Név:��$��0��$��0��$��Stretch=�$��Center=��� -   $ lblNem��$
��Nem:��$��1��$��0��$��Stretch=�$��Center=��� -   $ lblSzuletes��$��Születési dátum:��$��2��$��0��$��Stretch=�$��Center=��� -   $ lblEngedely��$��
Engedély:��$��3��$��0��$��Stretch=�$��Center=��� -   $ lblEgyesulet��$��Egyesület:��$��4��$��0��$��Stretch=�$��Center=��� -   $ lblEredmenyek��$��Eredmények:��$��5��$��0��$��Stretch=�$��Center=��� -    ��Name$ txtNev��$��0��$��1��$
��Left=�$��Center=�$	��120��$��23�� �� TextWrapping$
 Wrap=��� -   $ txtNem��$��1��$��1��$
��Left=�$��Center=�$	��120��$��23��$
 Wrap=�(  "System.Windows.Controls.DatePicker  -	     Name$ 
dtSzuletes��$��2��$��1��$
��Left=�$��Center=��� -
   $ txtEngedely��$��3��$��1��$
��Left=�$��Center=�$	��120��$��23��$
 Wrap=��� -   	 ��Name$	 cbEgyesulet��
 �� DisplayMemberPath$
 	Azonosito��$��4��$��1��$
��Left=�$��Center=�$	��120���� -   $ txtEredmenyek��$��5��$��1��$
��Left=�$��Center=�$	��120��$��23��$
 Wrap=��� -    ��Name$ 
btnRendben��$��Rendben��$��6��$��1��$��Right=�$��Bottom=�$��86��$��28���� -   $ btnUjEgyesulet��$��Új Egyesület��$��7��$��0��$��Right=�$��Bottom=�$��86��$��28��