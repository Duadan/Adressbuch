   M S B A M L   `   `   `  ����J  FAdressbuch test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Adressbuch_testAdressbuch_test  5   	        Adressbuch_test.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Adressbuch_test     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.6* �6   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      �� 5      .+�5   
   �� -   5         ��Name$
 Head��5      ���#6FA8DC$��0��68   $��0��6E   $��4��6U   �� 5   
   -   5         ��Name$ TitleL��5      $��
Adressbuch��6    $��20(�65   $
��Left=�6C   $��Center=�6^   $��0��6y   $��0��6�   $��20,0,0,0q�6�   �� 5   
   $��0��6   $��3��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   .+�5      �� -   5        $ SrchL��5      $��Suche:��6#   $��Center=�64   �� 5      -   5         ��Name$ 	TxtSearch��5      $	��100��6)   $��25��65    � ToolTip$! Suche mit Enter bestätigen��6U   �� 5      -   5         ��Name$ 	BtnSearch��5      $��Go��6(   $��Right=�65   $��25��6i   $ Suche starten��6u   5      �� 5   
   -   5        $ ListBack��5      $��1��6'   $��3��64   $��0��6E   .+�5      �� $ 
Horizontal=�6   $��35��62   .+�5      c� .@�5      �� -   5        $ BtnPpl��5      $ Alle Kontakte anzeigen��6B   .��5       �� $��MicrosoftTeams-image.png��6    5!      �� 5"      -	   5        $ BtnDate��5"      $ Kalender anzeigen��6D   .��5#      �� $��Geburtstage.png��6    5$      �� 5%      -
   5        $ BtnAdd��5%      $ Kontakt hinzufügen��6B   .��5&      �� $��hinzufügen.png��6    5'      �� 5(      -   5        $ BtnDel��5(      $$ Ausgewählten Kontakt löschen��6B   .��5)      �� $��Löschen.png��6    5*      �� 5+      -   5        $
 dark��5+      .��5,      �� $��dark.png��6    $ Darkmode (experimental)��62   5-      5.      5/      �� 50      -   5        	 ��Name$	 	ListNames��50      6Y   51      � 52   
   -   5        
 �Name$
 ContBack��52      $��1��6!   $��1��6.   $��2��6>   $��3��6R   .+�53      �� -   5         ��Name$ TheGrid��53      54      55      56      