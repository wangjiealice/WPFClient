   M S B A M L   `   `   `  ����D  @WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WPFClient	WPFClient  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	       WPFClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WPFClient     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	     � Title$  MTB Demo .NET��5	   	   $	��450��6   $	��380��6,    � 	Resources 5
        WPFClient.RLTLConverter   RLTLConverter �� 
TargetType �� Property �� Value��%�  &	        '��      '�� �     '�� -      5   
   6   �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$/ )Helvetica Neue,Helvetica,Arial,sans-serif)�6+   �� 5       � �� �	#FF3333336+   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$/ )Helvetica Neue,Helvetica,Arial,sans-serif)�6+   �� 5       � �� �	#FF3333336+   �� 5       � ��$ Center=�62   �� 5       � ��$ 35��6'   �� 5       � ��$ Center=�69   5      �� 5   
   " ��6   .�5      ��  � ��$ 16(�6)   �� 5       � ��$/ )Helvetica Neue,Helvetica,Arial,sans-serif)�6+   �� 5       � �� �	#FF3333336+   �� 5       � ��$ Center=�62   �� 5        � ��$ 35��6'   �� 5!       � ��$ Center=�69   5"      5#      .  (System.Windows.Interactivity.Interaction   Triggers 5$      /  )System.Windows.Interactivity.EventTrigger  5%   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5&      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *ViewModel.LoadedCommand+5'        5(   
   $ MouseRightButtonUp��6   . 5)         6$   �� * ViewModel.RightButtonUpCommand+5*      .��5-      � 	 � RowDefinitions	 5.   
   �� 5/      $��30 �6   �� 50      $��30 �6   �� 51      $��30 �6   �� 52      $��30 �6   �� 53      $��10 �6   �� 54      $��30 �6   �� 55      $��30 �6   �� 56      $
��Auto �6   .+�58   
   �� $
��left=�6   	Device:68   �� 59   
   $��1��6   ��6    �� *ViewModel.Devices+
 �� SelectedIndex
 5:      �� *ViewModel.SelectedDeviceIndex+ 5;        5<      $ SelectionChanged��6!   . 5=         6,   �� *(&ViewModel.SelectedDeviceChangedCommand+5>      5@      �� 5B   
   $��2��6   $
��Left=�6!   Components:6I   �� 5C   
   $��3��6   ��6    �� *ViewModel.Components+
 5D      �� *" ViewModel.SelectedComponentIndex+�� 5E   
   $��5��6   $	��150��5F      $��30��6   $
��Left=�6)   ��5E      �� *ViewModel.ConnectMTBCommand+.��5F   D   Connect to MTB6T   �� 5G   
   $��6��6   $
��Left=�6!   
Message:6F   �� 5H   
   $��7��5I      $	��200��6   $	��Top=�6,    �� TextWrapping$
 Wrap=�6K   ��5H      �� *ViewModel.DisplayMessages+ �� Mode$ TwoWay=�5I   K   5N      5O      