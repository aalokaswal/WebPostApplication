   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	    WebPosts#   WebPosts.View.DisplayWebPosts   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  	Web Posts��5   	    � WindowState$ 	Maximized=�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5	      $��2* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgWebPosts��5      $��0��6%      AutoGenerateColumns .  
���������65   �� *WebPostList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Web Post Id��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *id+6Q     5      $ Web Post Title��6%    .  6=   �� *title+6W   .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5      	   	EventName$	 SelectionChanged��6!   .   (System.Windows.Interactivity.TriggerBase
   Actions.
 5      6   0System.Windows.Interactivity.InvokeCommandAction     Command 5   !   �� *SelectedPostCommand+   CommandParameter 5   !   ��  �� ElementName$ 
dgWebPosts�� �� Path$ SelectedItem�5      5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      $��50 �6!   �� 5      $	��120 �6    �� 5      $��* �6    .+�5      �  � Orientation$ 
Horizontal=�6   $��0��61   
�������.+�5      �� $��Web Post Title��6   $��25��61   $	��100��6=   $��5,10,0,0q�6I   6]   �� 5       $	��.25q�6   
���   �$	��500��6C   $��5,10,0,0q�6O   ._�5!      �� -   5        $��txtPostTitle��5!       $��5,0,0,0q�5#       $��Center=�61   
���������5"      �� *WebPostTitle+ �� UpdateSourceTrigger$ PropertyChanged=�5$   6   5%      5&      � 5'      $��1��6   
������� 5(      �� 5)      $	��100 �6'   �� 5*       5,      �� 5-      �� 5.      �� 5/      �� 50      �� 51      �� 52      .+�54      �� $��WebPost Posted By User��6   $��5,0,0,0q�69   $��0��6J   $��2��6W   $��25��6k   $	��150��6w   
�������$
��Left=�6�   6�   �� 55      $	��800��6   $��2��6(   $��1��63   $��2��6@   
���   �$
��Left=�6b   $��0,0,0,0q�6}   6�   �� 57      $
��User��6   $��5,0,0,0q�6(   $��2��69   $��0��6F   6X   �� 58      $��2��65   $��2��6B   $��10,2,0,2q�6R   $	��200��6d   $
��Left=�6p   
���������6   �� *	WebUser+6�   �� 5:      $��User Id��6   $��5,0,0,0q�6+   $��3��6<   $��0��6I   6[   �� 5;      $��3��64   $��2��6A   $��10,2,0,2q�6Q   $	��200��6c   $
��Left=�6o   
���������6   �� *UserId+6�   �� 5=      $��	User Name��6   $��5,0,0,0q�6-   $��4��6>   $��0��6K   6^   �� 5>      $��4��66   $��1��6C   $��10,2,0,2q�6S   $	��200��6e   $
��Left=�6q   
���������6   �� *
UserName+6�   �� 5@      $��User EmailId��6   $��5,0,0,0q�60   $��5��6A   $��0��6N   6`   �� 5A      $��5��67   $��1��6D   $��10,2,0,2q�6T   $	��200��6f   $
��Left=�6r   
���������6   �� *	UserEmail+6�   5B      �� 5D       �� Orientation$ Vertical=�6   $��2��60   
�������.+�5E      �� $��Web Post Content��6   $��5,5,0,0q�63   $
��Left=�6D   6b   �� 5F      $	��800��6   $��2��6(   
���   �$
��Left=�6A   $��0,0,0,0q�6\   6p   �� 5G      $��Visible=�6   $��0,5,0,0q�6E   $	��460��5H      $	��800��6,   $
��Left=�68   
�������
�������$��5q�5I   J   .��5J      �� -   5        $��txtWebPostContent��5J       $
��Wrap=�69   $
��Left=�6M   $��15,5,0,0q�5L      ��5K      �� *WebPostContent+$ PropertyChanged=�5L   0   5M      � 5N      .+�5O      �� $��Save Content As��6   $	��120��5P      $��25��6)   $
��Left=�5S      ��5Q      �� *SaveContent+��5R      �� $ 
cmbFileExt��$ SelectedItem�5S   :   �� 5T      -   5        $��
cmbFileExt��5T      $	��100��61   $��25��6=   .@�5U      ��  �� 
IsSelected . .��69   txt6>   �� 5V      .��6'   html6-   �� 5W      .��6'   json6-   5X      5Y      5[      5\      5]      5^      