   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.PagesWpfApp1.Pages  5      #    WpfApp1.Pages.TypeOfFurniture   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Pages     5      -   5          N� Title$  TypeOfFurniture��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      -   5         ��Name$ SplitterColumn��5   )   $��0 �6   6)   �� 5      -   5        $ ChangeColumn��5   )   $��0 �6   $	��250��6?    � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   �� 
����·�$��0��6(   $��0��65   $��3��6E   �� 5   
   $��Типы мебели��6   $��3��6'   $��26(�69   $��	ExtraBold"�6G   $
��Left=�6^   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   
����·�.+�5      �� -   5         ��Name$ Addtype��5      $��Добавить��6&   $��75��69   $	��5,5q�6D   6Q   �� 5      -   5        $ Copytype��5      $��Копировать��6'   $��75��6<   $	��5,5q�6G   6T   �� 5      -   5        $ Edittype��5      $��Изменить��6'   $��75��6:   $	��5,5q�6E   6R   �� 5      -   5        $ 
Deletetype��5      $��Удалить��6)   $��75��6;   $	��5,5q�6F   6S   �� 5      -   5        $��TypeObjectsFilterComboBox��5      $	��150��68   $	��5,5q�6D   6Q   �� 5      -	   5         ��Name$ TypeObjectsFilterTextBox��5      $	��200��68   $	��5,5q�6D   6Q   5      &   System.Windows.Controls.DataGrid  5    
   -
   5          Name$ DataGridType��5       $��2��6)   $��0��66      AutoGenerateColumns .  	   CanUserAddRows	 .  
   Columns
 5!      4  .System.Windows.Controls.DataGridTemplateColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ Тип мебели��5%   5      CellTemplate 5&      �� 5'      .R�5(      �� ��6$   �� *name+5)      5+      5.      �� 5/   
   $��1��6   $��1��6'   $��2��64   $��Center=�6E   $��5��6b   �� 50   
   $��Тип мебели��6   $��2��6%   $��1��65   $
��Left=�6B   $��16(�6]   $��Italic$�6k   $��0 -8 0 0q�6~   �� 51   
   -   5        $��X��51      $��2��6   $��1��6-   $��Right=�6:   $	��Top=�6V   $��20��6�   $��20��6�   �� 52   
   $ Vertical=�6   $��2��6,   $��2��6<   .+�54      �� $��Тип мебели��6   
���   �6+   �� 55      -   5        $ nameTextBox��55   X   ��6   ��  �� ElementName$ DataGridType�� �� Path$ SelectedItem.name�6X   �� 56      -   5        $��Принять��56      $��	0 10 0 10q�6@   57      58      59      