   M S B A M L   `   `   `  ����V  RChatLikeQQOnActiveMQ.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ChatLikeQQOnActiveMQ.ClientChatLikeQQOnActiveMQ.Client  5   	   ,    &ChatLikeQQOnActiveMQ.Client.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;local)clr-namespace:ChatLikeQQOnActiveMQ.Client     5   	   /   )ChatLikeQQOnActiveMQ.Client.WindowResizer    Loaded$  WindowResizer_Loaded��5   5      MouseLeftButtonDown$' !WindowResizer_MouseLeftButtonDown��6}    � Title$ 
MainWindow��6	   $	��800��6   $	��400��6)    � WindowStyle$
 None=�6T    � 
ResizeMode$ NoResize=�6g    � 	Resources 5      /   )ChatLikeQQOnActiveMQ.Client.DataGenerator   data��%   &	          50   
   6-   51      .��52      �  � RowDefinitions 53   
   �� 54      $	��100 �6   6+   �� 55      6   �� 56      $��30 �6   6*   .+�58   
   �  � ColumnDefinitions 59      �� 5:      $	��100 �6#   61   �� 5;      6%   .+�5=      A� 6   � 5>      $��1��6    5?      �� 5@      6&   �� 5A      6&   .+�5C      �� $
��Left=�6   $��Center=�6:   $��20(�6\   $
��Bold"�6j   .��6|   Change~生活6�   �� 5D      $
��Wrap=�6   $��1��60    坚持吃早餐，暴饮暴食5F      5G      5I      � 5J   
   $��1��6   .+�5K      �� #��[  6   ��5L      �� 5M      .R�5N      � $��2q�6    5O      �� 5P   "   $��50 �63   6@   �� 5Q   "   65   .+�5S      ��  �� CornerRadius$ 30��6%   $��30��67   $��30��6C   
����ح�._�5T   "   �� 6+   5U      � 5V      $��1��6#    5W   "   �� 5X   &   66   �� 5Y   &   66   .+�5[   "   �� ��6,   �� *
UserName+6H   �� 5\   "   $��1��6,   ��69   �� *PersonalizedSignature+6b   5]      5^      5_      ��5b      �� 5c      	 �� 
TargetType"	 ��6   .�5d      �� 
 �� Property
 � �� �� Value
 ���� 6M   �� 5e      
 � ��$ 1,1,1,1q�63   6E    �� Triggers 5f      P� 5g       P� Property �@��
IsSelected P� Value . . �5h   "   �� 
 � ��
 �����6S   5i      P� 5j       �@��
IsSelected .  . �5k   "   �� 
 � ��
 ���� 6U   5l      P� 5m       �@J�IsMouseOver . . �5n   "   �� 
 � ��
 �����6S   5o      5q      5s      5t      5u      5v      