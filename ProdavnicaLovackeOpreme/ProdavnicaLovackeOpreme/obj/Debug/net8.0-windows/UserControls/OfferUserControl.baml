   M S B A M L   `   `   `  ����R  NProdavnicaLovackeOpreme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ProdavnicaLovackeOpreme.UserControls$ProdavnicaLovackeOpreme.UserControls  5      ;    5ProdavnicaLovackeOpreme.UserControls.OfferUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >local2clr-namespace:ProdavnicaLovackeOpreme.UserControls  5         AppFont#���   5	      .��5      #  MaterialDesignThemes.Wpf.Card    MaterialDesignPaper#���  6   .  (MaterialDesignThemes.Wpf.ElevationAssist    	Elevation$	  Dp4=�6M      UniformCornerRadius$ 15Q�6|   .��5   
   �  � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $��20q�6)   .+�5      �� $��0 0 0 10q�6   $��16(�6/     Supplier#���  6=   $
��Left=�6_   �� 5      $	��200��6   $��53��6%    �� CornerRadius$ 10��61     MaterialDesignDivider#���  6C   $��2q�6y   ._�5      �� $��20(�6    $��Center=�6.   $��Center=�6I   ��6f   �� *SupplierName+5      �� 5      $��	0 20 0 10q�6   $��16(�60     SupplierJIB#���  6>   $
��Left=�6c   �� 5      $	��200��6   $��53��6&   $ 10��62   #���  6D   $��2q�6z   ._�5      �� $��20(�6    $��Center=�6.   $��Center=�6I   ��6f   �� *SupplierJIB+5      5      �� 5      $��1��6   $��	0 20 10 0q�6)   .+�5       �� $��0 0 0 10q�6   $��16(�6/     Products#���  6=   $
��Left=�6_   �� 5!      $��2��6   $
��Auto=�6,   .��5"        $��10q�6*   $��2q�67   #���  6K   .��5#      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6#      SelectionMode$ Single=�6?      CanUserAddRows$ False��6V      CanUserResizeRows$ False��6m     MaterialDesignDataGrid#��[ 6�      GridLinesVisibility$ 
Horizontal=�6�   	   AlternatingRowBackground#	 �  6�   ��6  �� *
OfferItems+
   Columns
 5$      0  *System.Windows.Controls.DataGridTextColumn  5%   "     productNameColumn,  &System.Windows.Controls.DataGridColumn   Header# �  65      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6{      
IsReadOnly$
 True��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6b   �� *Name+6�     5&   "     productPriceColumn# �  65   $
 auto 6}   $
 True��6�    6c   �� *Price+6�     5'   "    	 productQuantityColumn# � 	 65   $
 auto 6�   $
 True��6�    6f   �� *
Quantity+6�   5)      5*      5+      5,      �� 5.      $��2��6    �� Orientation$ 
Horizontal=�6)   $��Bottom=�6B   $��10q�6]   .+�5/      ��  !
 MaterialDesignFlatMidBgButton#��[
 6   $	  Dp4=�6P    
 Accept#���  6   ��6�   �� *AcceptOffer+�� 50        MaterialDesignFlatButton#��[ 6   $	  Dp4=�6K     Decline#���  6z   $��20 0 0 0q�6�   ��6�   �� *DeclineOffer+51      52      53      54      