   M S B A M L   `   `   `  ����K  GMaterialEWpfDemo, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null3clr-namespace:MaterialEWpfDemoMaterialEWpfDemo  5      (    "MaterialEWpfDemo.FuzzyQueryControl   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      *localclr-namespace:MaterialEWpfDemo  5      X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	      -   5          >�Name$  
fuzzyquery��5
      .��5      �� ��6   �� *	TextWidth+ �� ElementName$ 
fuzzyquery�� �� Mode$ TwoWay=���5      �� *
TextHeight+$ 
fuzzyquery��$ TwoWay=�.+�5   
   (  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   5          Name$ querykey��5       
������ $��Center=�5       ��5       �� $ 
fuzzyquery�� �� Path$ CondtionKey�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   	Watermark 5       �� *WatermarkKey+$ 
fuzzyquery��$ TwoWay=���5       �� *
TextHeight+$ 
fuzzyquery��$ TwoWay=���5       �� *	TextWidth+$ 
fuzzyquery��$ TwoWay=�.��5   2   .��5   4   5      � 5   
    � AllowsTransparency . $��Bottom=�5       � 	StaysOpen .  $��Slide=�5      	 � PlacementTarget	 5      �� $ querykey����5      �� *	PopupOpen+$ 
fuzzyquery��.��5      �� -   5        
 ��Name$
 itemscontrol��5      ��5      �� *ItemsControlSource+$ TwoWay=�$ 
fuzzyquery����5      �� *ItemsControlItemStyle+$ 
fuzzyquery��$ TwoWay=���5       �� *ItemTemplte+$ 
fuzzyquery��$ TwoWay=�5)      5*      5+      5,      