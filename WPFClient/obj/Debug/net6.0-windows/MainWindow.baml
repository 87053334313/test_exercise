   M S B A M L   `   `   `  ����D  @WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPFClient	WPFClient  5   	       WPFClient.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPFClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5
         CanUserAddRows$ False��5         CanUserSortColumns$ False��6*      AutoGenerateColumns$ False��5      $��	0,0,0,259q�5      ��5
   %   �� *
Weathers+ �� SelectedItem 5      �� *SelectedItem+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5* 6H   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+6H     5      $ Дата��6%   $ 5* 6L   	 63   �� *Date+6L     5      $ Температура C��6%   $ 2* 6]   	 6<   �� *TemperatureC+6]     5      $ Температура F��6%   $ 2* 6j   	 6<   �� *TemperatureF+
 �� Mode$
 OneWay=�6j     5      $ Саммари��6%   $ 5* 6R   	 66   �� *	Summary+6R   5      �� 5   
   $��Добавить��61   $
��Left=�6D   $��144,290,0,0q�6_   $	��Top=�6t   ��6   �� *
AddCommand+6t   �� 5   
   $��Удалить��60   $
��Left=�6B   $��364,290,0,0q�6]   $	��Top=�6r   ��6   �� *
DelCommand+6r   �� 5   
   $1��+Сохранить в базу данных��61   $
��Left=�6S   $��575,290,0,0q�6n   $	��Top=�6�   ��6   �� *EditCommand+6�   5      5      