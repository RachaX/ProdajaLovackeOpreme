   M S B A M L   `   `   `  ����R  NProdavnicaLovackeOpreme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ProdavnicaLovackeOpreme.UserControls$ProdavnicaLovackeOpreme.UserControls  5      A    ;ProdavnicaLovackeOpreme.UserControls.CreateOfferUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >local2clr-namespace:ProdavnicaLovackeOpreme.UserControls  5         AppFont#���   5	      .��5      #  MaterialDesignThemes.Wpf.Card    MaterialDesignPaper#���  6   $��10q�6M   .��5   
   �   � RowDefinitions  5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� .+�5      ��   CreateNewOffer#���  6   $��30(�6D   $
��Bold"�6R   5      �� 5      $��1��6   $
��Auto=�6(   .��5        $��16q�6&   $��0,16,0,0q�63   .��5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6      SelectionMode$ Single=�6;      CanUserAddRows$ False��6R      CanUserResizeRows$ False��6i     MaterialDesignDataGrid#��[ 6�      GridLinesVisibility$ 
Horizontal=�6�      AlternatingRowBackground# �  6�   ��6  �� *
Products+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5        productNameColumn,  &System.Windows.Controls.DataGridColumn   Header# �  61   	   
IsReadOnly$
	 True��6^   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6p   �� *Name+6�     5        productCategoryColumn# �  61   $
	 True��6b   $

 auto 6�    6t   �� *
Category+6�     5        productPriceColumn# �  61   $
	 True��6_   $

 auto 6�    6q   �� *Price+6�     5        productQuantityColumn# �  61   $	
 100 6    6b   �� *
Quantity+6   4  .System.Windows.Controls.DataGridCheckBoxColumn  5        isSelectedProduct# �  65   $	
 100 6�    6b   �� *
IsSelected+6�   5!      5"      5#      �� 5&      $��2��6   .+�5'      �� $��0 0 0 5q�6    !	 MaterialDesignFlatMidBgButton#��[	 6*   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp0=�6a   $	��200��6�   +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$ 10��6�   $��16(�6�    
 createOffer#��� 
 6�   ��6   �� *CreateOfferCommand+5(      5)      5*      5+      