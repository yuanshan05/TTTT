   M S B A M L   `   `   `  ����K  GMaterialEWpfDemo, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null3clr-namespace:MaterialEWpfDemoMaterialEWpfDemo  5   	   p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5
   	   !    MaterialEWpfDemo.MainWindow   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MaterialEWpfDemo     5   	   P LPrism.Wpf, Version=6.3.0.0, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h	 dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions 	 5	   	   ccontrolsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit 	 5
   	     � WindowState$  	Maximized=�5       � Title$ 
MainWindow��5   	   $	��350��6   $	��525��6)   !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel . .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      > 	 8Microsoft.Expression.Interactivity.Core.CallMethodAction     
MethodName$ OnLoad��6;      TargetObject 6"   �� 6;   5       � 	Resources 5      	 �� 
TargetType   ComboxItemStyle
 �� Property �� Value �� Orientation  ItemsControlItemsStyle ��Name6  0System.Windows.Interactivity.InvokeCommandAction   Command �� RelativeSource �� AncestorType   CommandParameter��%  &	        &	     �� 5   
   "	 ��6   .�5      �� 
 � �� 5      �� 5      .R�5      �� $ 
Horizontal=�6%   .+�5      �� $	��100��6$   ��60   �� *Name+�� 5      $	��120��6>   ��6$   �� *Phone+6>   5      5      5      5      �� 5    
   "	 ��6   .�5!      �� 
 � ��
 �����6+   �� 5"      
 � �� 5#      �� 5$      .R�5%      �� $ 
stackpanel��6%   $ 
Horizontal=�69   
������  5'        5(   "   $ MouseLeftButtonDown��61   . 5)   &      6<   �� *DataContext.SelectionChanged+ �� $ ItemsControlL� 6�   �� 5*   #   .+�5,      �� $	��100��6$   ��60   �� *Name+�� 5-      $	��120��6>   ��6$   �� *Phone+6>   5.      5/      51      52      53      .��54      �� .+�55   
   *   $MaterialEWpfDemo.PaymmentTypeControl  -   5          Name$ paymentType��55   $      CheckBoxVisility$ Visible=�56   $      CheckBoxContent$ 	工本费��5:   $   $��20q�6:      CheckBoxIsChecked 57   $   �� *IsFree+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   PaymentType 58   $   �� *PayemntType+$ TwoWay=�$ PropertyChanged=�   HiddenChecked 59   $   �� *	IsChecked+$ TwoWay=�$ PropertyChanged=�5:   :   �� 5;   
   $��Center=�6   
���  ��$
��Bold"�6>   $��35��6P   ��6\   �� *PayemntType+$ TwoWay=�$ PropertyChanged=�6�   �� 5<   
   $��测试��6   $��20q�6   $��60��6*   ��65   �� *ConfirmCommand+�� 5[   
   -   5        $ 
stackpanel��5[   &   
���  ��$��Center=�6:   .+�5\      �� -   5         ��Name$ textBox��5\      $��Center=�5]      $	��200��64   $��30��6@   ��5\   '   �� *Key+$ TwoWay=�$ PropertyChanged=�.��5]   L    5^        5_      $ TextChanged��6%   . 5`        $ OnTextInput��6G    6.   �� 6G   5a      .��5b   *      	Behaviors 5c      $   MaterialEWpfDemo.FocusBehavior  5d      .��5e   +   5f      �� 5g      
�������.��6'   测试6+   5h      � 5i   
    � AllowsTransparency . $��Slide=�5l      $��Bottom=�5m       � 	StaysOpen .  ��5i      �� *IsDropDownOpen+$ TwoWay=�$ PropertyChanged=� � PlacementTarget 5j      ��  �� ElementName$ textBox��.��5o      �� 
�������._�5p      �� ��6   �� *StudentView+��5q      �� 5r      .R�5s      �� 
�������$��0 0 0 1q�6=     �� Padding$	  5 0q�6W   ._�5t   "   �� $ 
Horizontal=�6-   $	��0 3q�6F   
������ ! � Cursor$
! Hand��6l    5u   &     5v   *   $ MouseLeftButtonDown��69   . 5w   .      5x   1   �� *DataContext.SelectionChanged+ �� $ ItemsControlL� 5y   1   �� 5z   +   .+�5|   &   �� $��50��6F   ��60   �� *Name+6S   �� 5}   &   $	��100��6G   ��60   �� *Phone+6U   5~   #   5      5�      5�      5�      5�      �� 5�   
   $
��0 30q�6   .+�5�      -	  'System.Windows.Controls.AutoCompleteBox	  -   5        " 	 Name$" autocomplete��5�   9   # 	  IsDropDownOpen# . $	��200��5�   #   $��27��6/   $��Center=�6;   $ 	  IsTextCompletionEnabled$ . % 	  ValueMemberPath$
% Name��5�   #   & 	  
FilterMode$& Contains=�5�   #   ' 	  Text' 5�   '   �� *Key+$ TwoWay=�$ PropertyChanged=�( 	  
ItemFilter( 5�   #   �� *Filter+$ TwoWay=�) 	  ItemsSource) 5�   #   �� *StudentView+* 	  ItemTemplate* 5�      �� 5�      .R�5�      �� $ 
Horizontal=�6%   .+�5�      �� $	��100��6$   ��60   �� *Name+�� 5�      $	��120��6$   ��60   �� *Phone+5�      5�      5�      5�      5�      5�      