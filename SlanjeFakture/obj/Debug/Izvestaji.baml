   M S B A M L   `   `   `  ����H  DSlanjeFakture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SlanjeFakture.LinqToSqlSlanjeFakture.LinqToSql  5   	   '    !SlanjeFakture.LinqToSql.Izvestaji   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:SlanjeFakture.LinqToSql  5   	     � Title$  FAKTURE IZVEŠTAJ��5	   	   $	��720��6"   $
��1280��6/    � WindowStartupLocation$ CenterScreen=�6<    � SizeToContent$ WidthAndHeight=�6a    � 
ResizeMode$ CanMinimize=�6�   .��5
      � .+�5   
   � $��10,10,246,68q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 1Q�61   � 5      $ white��6#   5       � RowDefinitions 5      �� 5      $��40 �6    �� 5      	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   
BlurRadius$
 10Q�6#      Color$ 	#FFDEDEDE��63      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]   .+�5      � ���#494949 � ColumnDefinitions 5      �� 5      $
��780* �6'   �� 5      $
��473* �6'   .+�5      �� $��WS Simple Gallifreyan)�6   
�������$��16(�6S   $��14,10,531,10q�6a   �� 6x   $�	IZVEŠTAJ��6|   �� 6�   �� 6�   6�   5      �� 5       -   5         ��Name$ 
lbPretraga��5       $'��!Nema proizvoda za unete parametre��6(   $
��Left=�6T   $	��Top=�6o   $��
446,76,0,0q�6�   $	��286��6�   $y�Hidden=�6�   &   System.Windows.Controls.DataGrid  5"      -   5          Name$ gridProizvoda��5"   3      AutoGenerateColumns .  $
��Left=�6J   $	��493��6e   $��
10,69,0,11q�6r   $��Center=�6�   $	��998��6�   $��1��6�   $��Center=�6�   "   VerticalScrollBarVisibility$ Visible=�6�      
IsReadOnly .    Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Račun broj��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 170 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$ 	RacunBroj�6`     5%      $ Kupac��6)   $	 180 6\    68   �� $ 
NazivKupca�6\     5&      $ Datum prometa��6)   $	 200 6l    6@   �� $ DatumPrometaDobara�6l     5'      $ Ukupno��6)   $	 200 6Y    69   �� $ Ukupno�6Y   4  .System.Windows.Controls.DataGridTemplateColumn  5)      $ Artikli��6-      CellTemplate 5*      �� 5+      .R�5,   "   ��  ��Name$ 
btnDetalji��6)   -   5        ���#494949���#494949.��5-   &   � $��15��6+   $��15��66   .+�5.   *   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Details=�6B   $��Center=�6R   $��0,0,0,0q�6m   $��17��6~   5/   '   50   #   51      53        55      $ 	Storniraj��6-    56      �� 57      .R�58   "   �� $ btnStorniraj��6)   -   5        ���#494949���#494949.��59   &   � $��15��6+   $��15��66   .+�5:   *     $ Delete=�6B   $��Center=�6Q   $��0,0,0,0q�6l   $��17��6}   5;   '   5<   #   5=      5?      5C      (	  "System.Windows.Controls.DatePicker	  5D      -   5        $
��dpOd��5D      $
��Left=�6%   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$	 OD:��6@   $��	10,11,0,0q�6e   $��1��6x   $	��Top=�6�   $	��143��6�   	  5E      -   5        $
��dpDo��5E      $
��Left=�6%   $	 DO:��6@   $��
194,10,0,0q�6e   $��1��6y   $	��Top=�6�   $	��144��6�   �� 5F      -   5        $��	btnIzvrsi��5F      $��IZVRŠI��6&   $
��Left=�67   ���#494949$��
376,10,0,0q�6g   $��1��6{   $	��Top=�6�   $	��113��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   5G      5I      �� 5J   
   -   5        $��
btnStampaj��5J   <   ���#494949���#494949$��ŠTAMPAJ��6N   $
��Left=�6`   $	��Top=�6{   $	��167��6�   $��
10,641,0,0q�6�   6�   �� 5K   
   -	   5        $ btnNazad��5K   =   ���#494949���#494949$��NAZAD��6O   $
��Left=�6_   $	��Top=�6z   $	��206��6�   $��1049,641,0,0q�6�   6�   � 5L   
   $��1049,10,19,68q�6   ��5M      �� 5N      $ 0.5,1&�6&   $ 0.5,0&�67   .��5O      � $ White��6#   $ 1Q�61   � 5P      $ white��6#   5Q       5S      �� 5T      $��40 �6    �� 5U      	 5W        5X      $
 10Q�6#   $ 	#FFDEDEDE��63   $ Quality=�6E   $ 1Q�6]   .+�5Z      � ���#494949.+�5[      �� $��WS Simple Gallifreyan)�6   
�������$��16(�6S   $��14,10,104,10q�6a   $��PODACI��6w   5\      �� 5]      $��Izdato faktura:��6   $��Center=�6.   $��
10,18,10,0q�6K   $��1��6_   $	��Top=�6l   $	��186��6�   $��16(�6�   $��SemiBold"�6�   $��Center=�6�   �� 5^      -
   5        $��tbIzdatoFaktura��5^      $
��Left=�6-   $��32��6H   $��	50,52,0,0q�6T   $��1��6g    �� TextWrapping$
 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��108��6�   $��Center=�6�    �� 
CaretBrush �	#FF5B5B5B  �� 
IsReadOnly  . $��16(�6  �� 5_      $��Prodato proizvoda:��6   $��Center=�61   $��10,110,10,0q�6N   $��1��6c   $	��Top=�6p   $	��186��6�   $��16(�6�   $��SemiBold"�6�   $��Center=�6�   �� 5`      -   5        $��tbProdatoProizvoda��5`      $
��Left=�61   $��32��6L   $��
50,144,0,0q�6X   $��1��6l   $
 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��108��6�   $��16(�6�     . $��Center=�6�   �� 5a      $��Ukupna cena:��6   $��Center=�6+   $��10,212,10,0q�6H   $��1��6]   $	��Top=�6j   $	��186��6�   $��16(�6�   $��SemiBold"�6�   $��Center=�6�   �� 5b      -   5        $��tbUkunaCena��5b      $
��Left=�6*   $��32��6E   $��
50,246,0,0q�6Q   $��1��6e   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��108��6�   $��Center=�6�     . $��16(�6�   �� 5c      $��Iznos PDV-a:��6   $��Center=�6+   $��10,312,10,0q�6H   $��1��6]   $	��Top=�6j   $	��186��6�   $��16(�6�   $��SemiBold"�6�   $��Center=�6�   �� 5d      -   5        $��tbIznosPDVa��5d      $
��Left=�6*   $��32��6E   $��
50,346,0,0q�6Q   $��1��6e   $
 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��108��6�   $��16(�6�     . $��Center=�6�   5e      5f      5g      