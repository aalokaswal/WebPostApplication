   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity   WebPosts#   WebPosts.View.DisplayWebPosts   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � Title$  	Web Posts�� � WindowState$ 	Maximized=�.���  � ColumnDefinitions �� $��1* ��� $��2* �.+�&   System.Windows.Controls.DataGrid  -   $��
dgWebPosts��   SelectionMode$ Single=�$��0��   AutoGenerateColumns .  
����������� *WebPostList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Web Post Id��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *id+4  .System.Windows.Controls.DataGridTemplateColumn  $ Web Post Title��$	 330  . 
   CellTemplate
 �� .R��� $��Center=�$
��Wrap=����� *title+.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ SelectionChanged��.	   (System.Windows.Interactivity.TriggerBase 	  Actions. 6
   0System.Windows.Interactivity.InvokeCommandAction
   
  Command �� *SelectedPostCommand+ 
  CommandParameter ��  �� ElementName$ 
dgWebPosts�� �� Path$ SelectedItem�� $��1�� � RowDefinitions �� $��50 ��� $	��120 ��� $��* �.+��  � Orientation$ 
Horizontal=�$��0��
�������.+��� $��Web Post Title��$��25��$	��100��$��5,10,0,0q��� $	��.25q�
���   �$	��500��$��5,10,0,0q�._��� -   $��txtPostTitle��$��5,0,0,0q�$��Center=�
����������� *WebPostTitle+ �� UpdateSourceTrigger$ PropertyChanged=�� $��1��
������� �� $	��100 ���  �� �� �� �� �� �� .+��� $��WebPost Posted By User��$��5,0,0,0q�$��0��$��2��$��25��$	��150��
�������$
��Left=��� $	��800��$��2��$��1��$��2��
���   �$
��Left=�$��0,0,0,0q��� $
��User��$��5,0,0,0q�$��2��$��0���� $��2��$��2��$��10,2,0,2q�$	��200��$
��Left=�
����������� *	WebUser+�� $��User Id��$��5,0,0,0q�$��3��$��0���� $��3��$��2��$��10,2,0,2q�$	��200��$
��Left=�
����������� *UserId+�� $��	User Name��$��5,0,0,0q�$��4��$��0���� $��4��$��1��$��10,2,0,2q�$	��200��$
��Left=�
����������� *
UserName+�� $��User EmailId��$��5,0,0,0q�$��5��$��0���� $��5��$��1��$��10,2,0,2q�$	��200��$
��Left=�
����������� *	UserEmail+��  �� Orientation$ Vertical=�$��2��
�������.+��� $��Web Post Content��$��5,5,0,0q�$
��Left=��� $	��800��$��2��
���   �$
��Left=�$��0,0,0,0q��� $��Visible=�$��0,5,0,0q�$	��460��$	��800��$
��Left=�
�������
�������$��5q�.���� -   $��txtWebPostContent��$
��Wrap=�$
��Left=�$��15,5,0,0q����� *WebPostContent+$ PropertyChanged=�� .+��� $��Save Content As��$	��120��$��25��$
��Left=����� *SaveContent+���� $ 
cmbFileExt��$ SelectedItem��� -   $��
cmbFileExt��$	��100��$��25��.@���  �� 
IsSelected . .��txt�� .��html�� .��json