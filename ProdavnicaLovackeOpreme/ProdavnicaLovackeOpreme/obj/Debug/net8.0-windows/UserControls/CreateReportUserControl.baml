   M S B A M L   `   `   `  ����R  NProdavnicaLovackeOpreme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ProdavnicaLovackeOpreme.UserControls$ProdavnicaLovackeOpreme.UserControls  5      B    <ProdavnicaLovackeOpreme.UserControls.CreateReportUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:ProdavnicaLovackeOpreme.UserControls     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         AppFont#���   5	      .��5      #  MaterialDesignThemes.Wpf.Card  .��5   
   �   � RowDefinitions  5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��
10 10 0 0 q�6&   .+�5      �� $��30(�6     CreateReport#���  6*   $��Black"�6P   5      �� 5      $��1��6   $
��Left=�6&   $��	10 10 0 0q�6A   .+�5      �� $��18(�6     Filters#���  6*   $��SemiBold"�6K   5      �� 5      $��1��6   $��Right=�6&   $��0 0 10 0q�6B    �� Orientation$ 
Horizontal=�6T   .+�5      �� $	��150��6   $��55��6'   $��16(�63    " MaterialDesignOutlinedComboBox#��[ 6A    
 Report)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6�      
IsFloating$
 True��6�   ��6y   �� *ReportsType+ �� SelectedItem 6�   �� *Type+6�   5      �� 5      $��2��6   $
��Auto=�6(   .��5         $��16q�6&   $��0 16 0 0q�63   .��5!      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6      SelectionMode$ Single=�6;      CanUserAddRows$ False��6R      CanUserResizeRows$ False��6i     MaterialDesignDataGrid#��[ 6�   	   GridLinesVisibility$	 
Horizontal=�6�     MaterialDesignPaper
   AlternatingRowBackground#
 �  6�   ��6  �� *ReportItems+   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#        productNameColumn,  &System.Windows.Controls.DataGridColumn   Header# �  61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6w      
IsReadOnly$
 True��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6^   �� *Name+6�     5$        productPriceColumn# �  61   $
 auto 6y   $
 True��6�    6_   �� *Price+6�     5%       	 productQuantityColumn# � 	 61   $
 auto 6   $
 True��6�    6b   �� *
Quantity+6�     5&       
 productDateColumn# � 
 61   $	 100 6w   $
 True��6�    6^   �� *Date+6�   5(      5)      5*      �� 5,      $��	0 0 10 10q�6   $��3��6,   $ 
Horizontal=�69   $��Right=�6R   .+�5-      ��   InTotal#���  6   $��Center=�6=   $��16(�6X   �� 5.      $��5 0 10 0q�6   $��Center=�6F   $��16(�6a   ��6/   �� *Price+6a   �� 5/      $	��120��6    ! MaterialDesignFlatMidBgButton#��[ 6%    
 Create#���  6\   ��6   �� *CreateReportCommand+50      52      53      54      