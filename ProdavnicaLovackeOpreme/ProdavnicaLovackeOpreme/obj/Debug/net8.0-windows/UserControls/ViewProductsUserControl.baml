   M S B A M L   `   `   `  ����R  NProdavnicaLovackeOpreme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ProdavnicaLovackeOpreme.UserControls$ProdavnicaLovackeOpreme.UserControls  5      B    <ProdavnicaLovackeOpreme.UserControls.ViewProductsUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:ProdavnicaLovackeOpreme.UserControls     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         AppFont#���   5	      .��5      #  MaterialDesignThemes.Wpf.Card    MaterialDesignPaper#���  6   $��10q�6M   .��5   
   �   � RowDefinitions  5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��
10 10 0 0 q�6&   .+�5      �� $��30(�6     Products#���  6*   $��Black"�6L   5      �� 5      $��1��6   $
��Left=�6&   $��	10 10 0 0q�6A   .+�5      �� $��18(�6     Filters#���  6*   $��SemiBold"�6K   5      �� 5      $��1��6   $��Right=�6&   $��0 0 10 0q�6B    �� Orientation$ 
Horizontal=�6T   .+�5      �� $	��150��6   $��55��6'   $��16(�63    " MaterialDesignOutlinedComboBox#��[ 6A     Storage)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  6�      
IsFloating$
 True��6�   ��6y   �� *
Storages+ �� SelectedItem 6�   �� *	Storage+6�   �� 5      $	��150��6   $��55��6'   $��10 0 0 0q�63   $��16(�6E   #��[ 6S     Category# �  6�   $
 True��6  ��6�   �� *
Categories+ 6�   �� *
Category+6  �� 5        MaterialDesignFlatButton#��[ 6   $��40��6m   $	��100��6y   $��5 0 0 0q�6�   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�6�   ��6K   �� *SearchCommand+.��5      �� $ 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�62   $��15��6A   $��15��6L   $��0 0 5 0q�6X   �� 5         Refresh#���  6$   $��Center=�6E   5!      5"      5#      �� 5%      $��2��6   $��10q�6(   $
��Auto=�64   .��5&      �� ��6   �� *
Products+��5'      �� 5(      .R�5)      =   7ProdavnicaLovackeOpreme.UserControls.ProductUserControl  $��10q�6O    � DataContext 67   �� 6O   5*      5,      5-      �� 5/      $��3��6   $��Right=�6&   $��10q�6B   .+�50      �� $��16(�6   $	��150��6'    !	 MaterialDesignFlatMidBgButton#��[	 63   $	 Dp4=�6j    
 addToBillCommand#��� 
 6�   ��6�   �� *CreateBillCommand+y�6�   �� *
IsSalesman+   BooleanToVisibilityConverter �� 	Converter# [ 51      52      53      54      