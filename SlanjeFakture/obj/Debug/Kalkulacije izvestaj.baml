   M S B A M L   `   `   `  ����H  DSlanjeFakture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SlanjeFaktureSlanjeFakture  5   	   (    "SlanjeFakture.Kalkulacije_izvestaj   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   'localclr-namespace:SlanjeFakture  5   	     � Title$  KALKULACIJA DETALJI��5	   	   $	��720��6%   $
��1280��62    � WindowStartupLocation$ CenterScreen=�6?    � SizeToContent$ WidthAndHeight=�6d    � 
ResizeMode$ CanMinimize=�6�   .��5
      � .+�5   
   � $��10,10,10,68q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 1Q�61   � 5      $ white��6#   5       � RowDefinitions 5      �� 5      $��40 �6    �� 5      	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   
BlurRadius$
 10Q�6#      Color$ 	#FFDEDEDE��63      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]   .+�5      � ���#494949 � ColumnDefinitions 5      �� 5      5      �� 5      -   5         ��Name$ 
lbPretraga��5      $'��!Nema proizvoda za unete parametre��6(   $
��Left=�6T   $	��Top=�6o   $��
446,76,0,0q�6�   $	��286��6�   $y�Hidden=�6�   &   System.Windows.Controls.DataGrid  5       -   5          Name$ gridKalkulacija��5       $
��Left=�60   $	��493��6K   $��
10,69,0,11q�6X   $��Center=�6l   $
��1220��6�   $��1��6�   $��Center=�6�   "   VerticalScrollBarVisibility$ Visible=�6�      
IsReadOnly . 5"      �� 5#      $��Datum kalkulacije:��6   $
��Left=�61   $��	15,19,0,0q�6L   $��1��6_   $	��Top=�6l   $	��108��6�   �� 5$      -   5        $��tbDatumKalkulacije��5$       �� 
IsReadOnly . $
��Left=�6B   $��23��6]   $��
128,19,0,0q�6i   $��1��6}    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5%      $��Broj kalkulacije:��6   $
��Left=�60   $��
279,19,0,0q�6K   $��1��6_   $	��Top=�6l   $	��108��6�   �� 5&      -   5         ��Name$ tbBrojKalkulacije��5&       . $
��Left=�6C   $��23��6^   $��
392,19,0,0q�6j   $��1��6~   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5'      $��Po računu broj:��6   $
��Left=�6.   $��
553,19,0,0q�6I   $��1��6]   $	��Top=�6j   $	��108��6�   �� 5(      -   5        $ tbPoRacunuBroj��5(       . $
��Left=�6@   $��23��6[   $��
666,19,0,0q�6g   $��1��6{   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�   5*      �� 5+   
   -   5        $��
btnStampaj��5+   <   ���#494949���#494949$��ŠTAMPAJ��6N   $
��Left=�6`   $	��Top=�6{   $	��191��6�   $��
10,641,0,0q�6�   6�   �� 5,   
   -   5         ��Name$ btnNazad��5,   =   ���#494949���#494949$��NAZAD��6O   $
��Left=�6_   $	��Top=�6z   $	��186��6�   $��1053,641,0,0q�6�   6�   5-      5.      