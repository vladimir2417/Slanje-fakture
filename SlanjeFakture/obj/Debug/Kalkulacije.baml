   M S B A M L   `   `   `  ����H  DSlanjeFakture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SlanjeFaktureSlanjeFakture  5   	       SlanjeFakture.Kalkulacije   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:SlanjeFakture  5   	     � Title$  KALKULACIJE��5	   	   $	��720��6   $
��1280��6*    � WindowStartupLocation$ CenterScreen=�67    � SizeToContent$ WidthAndHeight=�6\    � 
ResizeMode$ CanMinimize=�6{    � 	Resources 5
         semaZaDobavljace �� Orientation �� Path��%�   &	        �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6   �� $ NazivDobavljaca�5      5      5      .��5      � $��0,0,0,0q�6   .+�5   
   � $��10,10,919,512q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      � 	 � Color$	 White��6#   
 � Offset$
 1Q�61   � 5      $	 white��6#   5       � RowDefinitions 5      �� 5      $��40 �6    �� 5       J� Effect 5!      3  -System.Windows.Media.Effects.DropShadowEffect  5"         
BlurRadius$ 10Q�6#      Color$ 	#FFDEDEDE��63      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]   .+�5$      � ���#494949.+�5%      �� $��WS Simple Gallifreyan)�6   
�������$��16(�6S   $��14,10,147,10q�6a   $��PODACI O DOKUMENTU��6w   5&      �� 5'      -   5         ��Name$ tbBrojDokumenta��5'      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Broj dokumenta:��6/   $
��Left=�6`   $��34��6{   $��
206,44,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��100��6�   $��1��6�   �� 5(      -   5         ��Name$ cbDobavljaci��5(      $ Izaberite dobavljača:��6-   $
��Left=�6d   $��	22,10,0,0q�6   $��1��6�   #��[  6�   $	��Top=�6�   $	��154��6�   $��29��6�   (  "System.Windows.Controls.DatePicker  5)      -   5          Name$ dpDatumPrijemaRobe��5)      $ Datum:��65   $
��Left=�6]   $��	22,44,0,0q�6x   $��1��6�   $	��Top=�6�   $	��154��6�      FirstDayOfWeek$ Monday=�6�   |�.  $��34��6�   �� 5*      -   5        $ tbBrojKalkulacije��5*       �� 
IsReadOnly . $ Broj kalkulacije:��6C   $
��Left=�6v   $��34��6�   $��
206,10,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��100��6�   $��1��6�   5+      � 5-   
   $��381,10,664,512q�6   ��5.      �� 5/      $ 0.5,1&�6&   $ 0.5,0&�67   .��50      � $	 White��6#   $
 1Q�61   � 51      $	 white��6#   52       54      �� 55      $��40 �6    �� 56       58        59      $ 10Q�6#   $ 	#FFDEDEDE��63   $ Quality=�6E   $ 1Q�6]   .+�5;      � ���#494949.+�5<      �� $��WS Simple Gallifreyan)�6   
�������$��16(�6S   $��14,10,65,10q�6a   $��PODACI O KURSU��6v   5=      �� 5?      -   5        $ tbKursSrednji��5?      $ Kurs srednji:��6-   $
��Left=�6\   $��34��6w   $��
112,35,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $��87��6�   $��1��6�   �� 5@      $��Kurs za artikal:
��6   $
��Left=�69   $��	10,42,0,0q�6T   $��1��6g   $	��Top=�6t   $��27��6�   5A      � 5C   
   $��10,191,10,14q�6   ��5D      �� 5E      $ 0.5,1&�6&   $ 0.5,0&�67   .��5F      � $	 White��6#   $
 1Q�61   � 5G      $	 white��6#   5H       5J      �� 5K      $��40 �6    �� 5L       5N        5O      $ 10Q�6#   $ 	#FFDEDEDE��63   $ Quality=�6E   $ 1Q�6]   .+�5Q      � ���#494949.+�5R      �� $��WS Simple Gallifreyan)�6   
�������$��16(�6S   $��14,10,270,10q�6a   �� 6x   $�ARTIKLI��6|   �� 6�   �� 6�   6�   5S      &   System.Windows.Controls.DataGrid  5T      -   5          Name$ gridProizvoda��5T      $
��Left=�6.   $	��389��6I   $��	10,47,0,0q�6V   $	��Top=�6i   $
��1234��6�   $��1��6�   �� 5U      -   5         ��Name$ btnUnesiArtikal��5U   *   ���#494949$��UNESI ARTIKAL��6C   $
��Left=�6[   $��1092,-126,20,0q�6v   $	��Top=�6�   $	��142��6�   6�   �� 5V      -   5        $ 
btnSacuvaj��5V   *   ���#494949$��SAČUVAJ��6>   $
��Left=�6P   $��1092,-66,0,0q�6k   $	��Top=�6�   $	��142��6�   6�   �� 5W      -	   5        $ 	btnOtkazi��5W   *   ���#494949$��OTKAŽI��6=   $
��Left=�6N   $��1092,-182,0,0q�6i   $	��Top=�6�   $	��142��6�   6�   �� 5X      -
   5        $ btnObrisiRed��5X   *   ���#494949$��OBRIŠI RED��6@   $
��Left=�6U   $��	10,10,0,0q�6p   $	��Top=�6�   $	��142��6�   $��1��6�   5Z      � 5[   
   $��632,10,217,512q�6   ��5\      �� 5]      $ 0.5,1&�6&   $ 0.5,0&�67   .��5^      � $	 White��6#   $
 1Q�61   � 5_      $	 white��6#   5`       5b      �� 5c      $��40 �6    �� 5d       5f        5g      $ 10Q�6#   $ 	#FFDEDEDE��63   $ Quality=�6E   $ 1Q�6]   .+�5i      � ���#494949.+�5j      �� $��WS Simple Gallifreyan)�6   
�������$��16(�6S   $��14,10,65,10q�6a   �� 6w   $	�TRO��6{   �� 6�   $�ŠKOVI��6�   6�   5k      �� 5l      -   5        $ tbOdGranice��5l      $ Troškovi u dinarima:��6+   $
��Left=�6a   $��34��6|   $��
156,10,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��110��6�   $��1��6�   6�   �� 5m      $ ��Ukupni troškovi (dinari):��6   $
��Left=�68   $��	10,18,0,0q�6S   $��1��6f   $	��Top=�6s   �� 5n      -   5        $ tbKolicinaArtikalaUKal��5n      $ Količina artikala:��66   $
��Left=�6j   $��34��6�   $��
172,49,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $��94��6�   $��1��6�   6�   �� 5o      $'��!Količina artikala u kalkulaciji:��6   $
��Left=�6?   $��	10,59,0,0q�6Z   $��1��6m   $	��Top=�6z   �� 5p      -   5        $ tbTrosakPoArtiklu��5p      $
��Left=�62   $��34��6M   $��
309,49,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $��70��6�   $��1��6�   �� 5q      $��Trošak po artiklu:��6   $
��Left=�61   $��
294,25,0,0q�6L   $��1��6`   $	��Top=�6m   $	��115��6�   5r      5s      5t      