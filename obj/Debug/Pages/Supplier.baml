   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.PagesWpfApp1.Pages  5          WpfApp1.Pages.Supplier   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Pages     5      -   5          N� Title$  Supplier��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      -   5         ��Name$ SplitterColumn��5   )   $��0 �6   6)   �� 5      -   5        $ ChangeColumn��5   )   $��0 �6   $	��250��6?    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   �� 
����·�$��0��6(   $��0��65   $��3��6E   �� 5   
   $��Поставщики��6   $��3��6&   $��26(�68   $��	ExtraBold"�6F   $
��Left=�6]   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   
����·�.+�5      �� -   5         ��Name$ AddSupp��5      $��Добавить��6&   $��75��69   $	��5,5q�6D   6Q   �� 5      -   5        $ CopySupp��5      $��Копировать��6'   $��75��6<   $	��5,5q�6G   6T   �� 5      -   5        $ EditSupp��5      $��Изменить��6'   $��75��6:   $	��5,5q�6E   6R   �� 5      -   5        $ 
DeleteSupp��5      $��Удалить��6)   $��75��6;   $	��5,5q�6F   6S   �� 5      -   5        $��TypeObjectsFilterComboBox��5      $	��150��68   $	��5,5q�6D   6Q   �� 5      -	   5         ��Name$ TypeObjectsFilterTextBox��5      $	��200��68   $	��5,5q�6D   6Q   5      &   System.Windows.Controls.DataGrid  5    
   -
   5          Name$ DataGridSupp��5       $��2��6)   $��0��66      AutoGenerateColumns .  	   CanUserAddRows	 .  
   Columns
 5!      4  .System.Windows.Controls.DataGridTemplateColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��5%   5      CellTemplate 5&      �� 5'      .R�5(      �� ��6$   �� *	surname+5)      5+        5,      $ Отчество��5/   5    50      �� 51      .R�52      �� ��6$   �� *
patronymic+53      55        56      $ Имя��59   5    5:      �� 5;      .R�5<      �� ��6$   �� *name+5=      5?        5@      $! Номер телефона��5C   5    5D      �� 5E      .R�5F      �� ��6$   �� *	telephone+5G      5I        5J         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)   $ 
Адрес��5M   5    5N      �� 5O      .R�5P      �� ��6$   �� *	address+5Q      5S      5U      �� 5V   
   $��1��6   $��1��6'   $��2��64   $��Center=�6E   $��5��6b   �� 5X   
   -   5        $��X��5X      $��2��6   $��1��6-   $��Right=�6:   $	��Top=�6V   $��20��6�   $��20��6�   �� 5Y   
   $��Поставщики��6   $��2��6%   $��1��65   $
��Left=�6B   $��16(�6]   $��Italic$�6k   $��0 -8 0 0q�6   �� 5Z   
   $��2��6   $��2��6'   .��5[      �� $ Vertical=�6   .+�5]      �� $��Фамилия��6   
���   �6,   �� 5^      -   5        $ SurnameTextBox��5^   _   ��6   ��  �� ElementName$ DataGridSupp�� �� Path$ SelectedItem.surname�6_   �� 5_      $��Имя��6   
���   �6(   �� 5`      -   5        $ nameTextBox��5`   \   ��6   �� $ DataGridSupp��$ SelectedItem.name�6\   �� 5a      $��Отчество��6   
���   �6+   �� 5b      -   5        $ PatronymicTextBox��5b   b   ��6   �� $ DataGridSupp��$ SelectedItem.patronymic�6b   �� 5c      $��
Адрес��6   
���   �6(   �� 5d      -   5        $ AdressTextBox��5d   _   ��6   �� $ DataGridSupp��$ SelectedItem.address�6_   �� 5e      $!��Номер телефона��6   
���   �63   �� 5f      -   5        $ TelephoneTextBox��5f   a   ��6   �� $ DataGridSupp��$ SelectedItem.telephone�6a   �� 5g      -   5        $��Принять��5g      $��	0 10 0 10q�6D   5h      5i      5j      5k      