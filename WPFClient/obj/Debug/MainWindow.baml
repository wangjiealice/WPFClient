   M S B A M L   `   `   `  ����D  @WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPFClient	WPFClient  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       WPFClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPFClient     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  Labscope Simulator��5	   	   $	��330��6$   $	��646��61    � 	Resources 5
        WPFClient.RLTLConverter   RLTLConverter �� 
TargetType �� Property �� Value��%K  &	        '��      '�� �       5   
   6   �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$/ )Helvetica Neue,Helvetica,Arial,sans-serif)�6+   �� 5       � �� �	#FF3333336+   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$/ )Helvetica Neue,Helvetica,Arial,sans-serif)�6+   �� 5       � �� �	#FF3333336+   �� 5       � ��$ Center=�62   �� 5       � ��$ 35��6'   �� 5       � ��$ Center=�69   5      5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *ViewModel.LoadedCommand+5        5    
   $ MouseRightButtonUp��6   . 5!         6$   �� * ViewModel.RightButtonUpCommand+5"      .��5%      � 	 � RowDefinitions	 5&   
   �� 5'      $��2 �6   �� 5(      �� 5)      $��2 �6   �� 5*      �� 5+      $��2 �6   �� 5,      $��10 �6   �� 5-      $
��Auto �6   �� 5.      $
��Auto �6   
 � ColumnDefinitions
 50   
   �� 51      $��2 �6   �� 52      �� 53      $��2 �6   �� 54      �� 55      $��2 �6   .+�58   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $��1��6;   ��6K   �� *ViewModel.ReflectorTextColor+.+�59      �� $��Right=�6   Reflector Position:6J   �� 5:      $��10,0,0,0q�5;      ��5:      �� *ViewModel.ReflectorPosition+ �� Mode$ TwoWay=�5;      5<      �� 5>   
   $ 
Horizontal=�6   $��1��6.   $��3��6;   ��6K   �� *ViewModel.Color1+.+�5?      �� Object Position:6*   �� 5@      $��10,0,0,0q�5A      ��5@      �� *ViewModel.ObjectPosition+$ TwoWay=�5A      5B      �� 5D   
   $ 
Horizontal=�6   $��3��6.   $��1��6;   ��6K   �� *ViewModel.Color2+.+�5E      �� $��4��6   $��Right=�6%   Light Brightness:6T   �� 5F      $��10,0,0,0q�5G      ��5F      �� *ViewModel.Brightness+$ TwoWay=�5G      5J      �� 5L   
   $
��1000��6   
�������$��5��6-   �� 5M   
   $��2��6   $
��1000��6"   
�������$��5��6<   �� 5N   
   $��4��6   $
��1000��6"   
�������$��5��6<   �� 5O   
   $��0��6   $
��1000��6%   
�������$��5��6?   �� 5P   
   $��2��6   $
��1000��6%   
�������$��5��6?   �� 5Q   
   $��4��6   $
��1000��6%   
�������$��5��6?   �� 5S   
   $ 
Horizontal=�6   $��3��6.   $��3��6;   ��6K   �� *ViewModel.Color3+.+�5T      �� RLTL Position:6(   �� 5U      $��10,0,0,0q�5V      ��5U      �� *ViewModel.RLTL+$ TwoWay=�5V      5W      �� 5Y   
   $��6��6   $��5��6    ��5Z      �� 5[      Change light brightness:66   .��5]      �� $ 
Horizontal=�6   $��20q�62   .+�5^      �� Brightness(0~1000):61   �� 5_      ��6   �� *ViewModel.Brightness+�� 5`       � Maximum$
 1000Q�6    � Minimum$ 0Q�6(   $	��200��6g   $��Center=�6s   $
��10,0q�6�    � Value 64   �� *ViewModel.Brightness+$ TwoWay=� 5b        5c      $ PreviewMouseUp��6)   . 5d         64   �� *!ViewModel.UpdatePosServoCommand+5e      5g      5o      5p      �� 5r   
   $��7��6   $��5��6    ��5s      �� 5t      Change RLTL:6*   .��5v      �� $ 
Horizontal=�6   $��20q�62   .+�5w      	�  	� 	GroupName$ 	RLTLGroup��6     radio has-success#���  64    d� 	IsChecked 5x      �� *ViewModel.RLTL+$ TwoWay=� �� 	Converter# [   �� ConverterParameter$ RL����5{      �� *ViewModel.RLCheckedCommand+��5|      �� 5}      RL6(   5      	� 5�      $ 	RLTLGroup��6   #���  64   $��20,0,0,0q�6`    5�      �� *ViewModel.RLTL+$ TwoWay=�# [  $ TL����5�      �� *ViewModel.TLCheckedCommand+��5�      �� 5�      TL6(   5�      �� 5�      $y�	Collapsed=�6I   ��6   �� *ViewModel.ConnectMTBCommand+.��6`   	Connect6i   5�      5�      5�      5:     