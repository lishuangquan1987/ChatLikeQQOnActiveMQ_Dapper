   M S B A M L   `   `   `  ����V  RChatLikeQQOnActiveMQ.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ChatLikeQQOnActiveMQ.ClientChatLikeQQOnActiveMQ.Client  5   	   ]3clr-namespace:ChatLikeQQOnActiveMQ.Client.Converter%ChatLikeQQOnActiveMQ.Client.Converter  5   	   F BWetChatWait, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:WetChatWait;assembly=WetChatWaitWetChatWait 5
   	   +    %ChatLikeQQOnActiveMQ.Client.LoginForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:ChatLikeQQOnActiveMQ.Client     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Aconvert3clr-namespace:ChatLikeQQOnActiveMQ.Client.Converter  5   	   <wetChat.clr-namespace:WetChatWait;assembly=WetChatWait  5
   	   -   5          � Title$  	LoginForm��5   	   $	��350��6   $	��400��6(    � WindowStyle$
 None=�6|    � 
ResizeMode$ NoResize=�6�    � 	Resources 5       �� MergedDictionaries �� Source �� 
TargetType   MaterialDesignTextBox �� BasedOn �� Property	 �� Value  MaterialDesignPasswordBox  MaterialDesignComboBox  MaterialDesignSlider:   4ChatLikeQQOnActiveMQ.Client.Converter.ValueConverter  valueConverter  closeButton
 �� 
TargetType	 �� X1 �� ElementName �� Path �� 	Converter �� ConverterParameter	 �� Y1	 �� X2	 �� Y2 �� Triggers P� Property P� Value �� 
TargetName�� 5   
    5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Slider.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   %�  '��       7   'G� R     7  '�� �     7  '(�     '�� �    7  &	 .    &	 A    7  7  7  7  7  7  7  7  �� 5      " ��6   8   .�5      ��  � ��$	 0 8 0 8q�6+   5      �� 5      " G�6   8   .�5      ��  � ��$	 0 8 0 8q�6+   5      �� 5      " ��6   8   .�5      ��  � ��$	 Stretch=�68   �� 5       � ��$	 0 8 0 8q�6+   5      �� 5      " (�6   .�5      ��  � ��$	 18��6*   �� 5        � ��$	 18��6+   �� 5!       � ��$	 0 0 8 0q�6+   �� 5"       � ��$	 Center=�66   5#      �� 5$      " ��6   8   .�5%      ��  � ��$	 0 8 0 8q�6+   5&        5'      6>   �� 5(      " ��6   .�5)      ��  �@�ToolTip$	 关闭��6,   �� 5*       � ��	 5+      �� 5,      "
 ��6*   .R�5-      � .+�5.   "   �� $��ep��6,   #��z��66   6\   �� 5/   "   .+�50   &   �� 
�������$��2��54   6    50   +   �� $ ep��$ ActualHeight�8   $
 0.25�� 51   '   �� $ ep��$ ActualWidth�8  $
 0.25�� 52   '   �� $ ep��$ ActualHeight�8  $
 0.75�� 53   '   �� $ ep��$ ActualWidth�8  $
 0.75��55   '   �� 56   &   
�������$��2��5:   6    56   +   �� $ ep��$ ActualHeight�8  $
 0.25�� 57   '   �� $ ep��$ ActualWidth�8  $
 0.75�� 58   '   �� $ ep��$ ActualHeight�8  $
 0.75�� 59   '   �� $ ep��$ ActualWidth�8  $
 0.25��5;   '   5<   #   5=       5>      P� 5?   "    �@J�IsMouseOver . . �5@   &   �� $ ep��6-    � ��
	 �  ��6[   5A   #   5C      5E      5F      5H      .��5K      � ���	#FFF0F0F0 � RowDefinitions 5L   
   �� 5M      $	��180 �6   6+   �� 5N      6   .+�5P   
   � -   5        $��layout��5P      ���	#19000000 J� Clip 5Q      �� 5R       �� Rect$ 0,0,400,180�6$   5T      �� 5U   
   $��1��6    �� Orientation$ Vertical=�6"   $��Center=�69   .+�5V      �� -   5        $��spLogin��5V      $ Vertical=�6(    J� Opacity$ 1Q�6?   $	��110��6K   $��-0,0,0,0q�6X   .+�5W      �� $ 
Horizontal=�6   .+�5X      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6.   $��Center=�6=   6Z   �� 5Y      -   5        $��
cbUserName��5Y       �� 
IsEditable . $	��200��6D   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	用户名��6Q   6x   5Z      �� 5[      $ 
Horizontal=�6   .+�5\        $
 Lock=�6.   $��Center=�6<   6Y   G� 5]      -   5        $��
tbPassword��5]   "   $	��200��64   $ 密码��6A   6g   5^      �� 5_      $ 
Horizontal=�6   .+�5`      �� -   5        $��cbAutoLogin��5`       d� 	IsChecked$
 TrueY�6.   .��6@   自动登录6F   �� 5a      -   5        $��
cbRemember��5a      $��10,0,0,0q�6-   $
 TrueY�6?   .��6Q   记住密码6W   �� 5b      $��20,1,0,0q�6   �� 5c      .�6    .�5d      �� $�找回密码��6   
���   �6?   5e      5f      5g      5h      �� 5i      -   5        $��	spLoading��5i      $ Vertical=�6+   $ 0Q�6B   $��Center=�6N   .+�5j      $  WetChatWait.WetChatWaitControl  $��	0,-70,0,0q�6-       Color  �	#FF512DA8!   IsActive! . "   CircleCount$" 6��6b   #   AnimationDistance$# 70Q�6r   $   AnimationDelayTime$	$ 200��6�   5k      �� 5l      .+�5m      �� -	   5        $��btnLogin��5m       " MaterialDesignRaisedDarkButton#��[ 6@   $��6 12 8 0q�6x   $	��220��6�   % � ToolTip$% 点击登录��5n      .��6$   	_登录5p      5q      5r      �� 5s   
   -
   5        $��btnClose��5s      $��30��68   $��30��6D   $��Right=�6O   $	��Top=�6k   
������ #��[ 6�   6�   5t      5v      