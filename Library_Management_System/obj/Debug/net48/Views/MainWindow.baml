   M S B A M L   `   `   `  ����T  PLibrary_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Library_Management_SystemLibrary_Management_System  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   *    $Library_Management_System.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Library_Management_System     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5          � Title$   System obsługi biblioteki��5	   	    � 
ResizeMode$ NoResize=�6H    � WindowStyle$
 None=�6^   $	��666��6q   $
��1184��6~    � 	Resources 5       �� Source�� 5   
   $ MainWindowResources.xaml?�6   %     J� InputBindings 5      �� 5   
   
 �� Key$ A��6    �� 	Modifiers$
 Ctrlf�6    �� Command 6.   �� *NewAuthorCommand+�� 5   
   $ A��6   $ Shiftf�6    6/   �� *AllAuthorsCommand+�� 5   
   $ B��6   $
 Ctrlf�6    6.   �� *NewPublisherCommand+�� 5   
   $ B��6   $ Shiftf�6    6/   �� *AllPublishersCommand+�� 5   
   $ C��6   $
 Ctrlf�6    6.   �� *NewCategoryCommand+�� 5   
   $ C��6   $ Shiftf�6    6/   �� *NewSubcategoryCommand+�� 5   
   $ E��6   $
 Ctrlf�6    6.   �� *NewEmployeeCommand+�� 5   
   $ E��6   $ Shiftf�6    6/   �� *AllEmployeesCommand+�� 5   
   $ I��6   $
 Ctrlf�6    6.   �� *StockUpdateCommand+�� 5   
   $ L��6   $
 Ctrlf�6    6.   �� *NewLocationCommand+�� 5    
   $ M��6   $
 Ctrlf�6    6.   �� *StockCommand+�� 5"   
   $ O��6   $
 Ctrlf�6    6.   �� *OverdueChargeCommand+�� 5#   
   $ O��6   $ Shiftf�6    6/   �� *AllOverdueChargesCommand+�� 5%   
   $ P��6   $
 Ctrlf�6    6.   �� *NewPublicationCommand+�� 5&   
   $ P��6   $ Shiftf�6    6/   �� *AllPublicationsCommand+�� 5(   
   $ R��6   $
 Ctrlf�6    6.   �� *SettlementReportCommand+�� 5)   
   $ R��6   $ Shiftf�6    6/   �� *UpdateDailyRateCommand+�� 5+   
   $ S��6   $
 Ctrlf�6    6.   �� *NewPositionCommand+�� 5-   
   $ U��6   $
 Ctrlf�6    6.   �� *NewUserCommand+�� 5.   
   $ U��6   $ Shiftf�6    6/   �� *AllUsersCommand+�� 50   
   $ W��6   $
 Ctrlf�6    6.   �� *BorrowingCommand+�� 51   
   $ Z��6   $
 Ctrlf�6    6.   �� *ReturningCommand+�� 52   
   $ W��6   $ Shiftf�6    6/   �� *AllBorrowingsCommand+	 � Triggers	 57      :� 58   
   
 :� RoutedEvent$
 ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�59      ��    OpenMenu#��[  6   5:      :� 5;   
   $
 ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5<      ��   	CloseMenu#��[ 6   5=      .��5A      �   FullGrid#��[ 6    � RowDefinitions 5B   
   �� 5C      $��40 �6   �� 5D      $��40 �6   �� 5E      $��* �6   �� 5F      $��40 �6   .+�5J   
   � $��0��6   ���#20202d � ColumnDefinitions 5K      �� 5L      $
��auto �6#   �� 5M      .+�5O      o� $��0��6   .@�5P      m� $��_Okno��6   .@�5Q      m� -   5        $��Zamknij okno��5Q        SubMenuItem#��[ 65    m� Icon 5R      �� 5S      $��/Views/Icons/bcross.png��6$   5U      m� 5V      -   5        $��Maksymalizuj okno��5V      #��[ 6:    5W      �� 5X      $��/Views/Icons/bsquare.png��6$   5Z      m� 5[      -   5        $��Minimalizuj okno��5[      #��[ 69    5\      �� 5]      $��/Views/Icons/bminus.png��6$   5_      5a      m� 5b      $��_Użytkownik��6   .@�5c      m� $��Dodaj/edytuj użytkownika��6   #��[ 6A    m� InputGestureText$ Ctrl + U��6�    m� Command 6g   �� *NewUserCommand+ 5d      �� 5e      $��/Views/Icons/badd.png��6$   5g      m� 5h      $��Spis użytkowników��6   #��[ 6:   $ 	Shift + U��6�    6_   �� *AllUsersCommand+ 5i      �� 5j      $��/Views/Icons/bpeople.png��6$   5l      5m      m� 5o      $��_Publikacje��6   .@�5p      m� $��Dodaj/edytuj publikację��6   #��[ 6@   $ Ctrl + P��6�    6e   �� *NewPublicationCommand+ 5q      �� 5r      $��/Views/Icons/bbook.png��6$   5t      m� 5u      $��Spis publikacji��6   #��[ 68   $ 	Shift + P��6�    6]   �� *AllPublicationsCommand+ 5v      �� 5w      $��/Views/Icons/blist.png��6$   5y      5z      m� 5|      $��_Magazyn��6   .@�5}      m� $��Stan magazynu��6   #��[ 66   $ Ctrl + M��6|    6[   �� *StockCommand+ 5~      �� 5      $!��/Views/Icons/binventory.png��6$   5�      m� 5�      $��Inwentaryzacja magazynu��6   #��[ 6@   $ Ctrl + I��6�    6e   �� *StockUpdateCommand+ 5�      �� 5�      $��/Views/Icons/bstock.png��6$   5�      5�      m� 5�      $��_Wypożyczalnia��6   .@�5�      m� $��	Wypożycz��6   #��[ 61   $ Ctrl + W��6{    6V   �� *BorrowingCommand+ 5�      �� 5�      $��/Views/Icons/bcart.png��6$   5�      m� 5�      $��Zwróć��6   #��[ 6.   $ Ctrl + Z��6x    6S   �� *ReturningCommand+ 5�      �� 5�      $��/Views/Icons/breturn.png��6$   5�      m� 5�      $��Lista wypożyczeń��6   #��[ 69   $ 	Shift + W��6�    6^   �� *AllBorrowingsCommand+ 5�      �� 5�      $!��/Views/Icons/bnumerlist.png��6$   5�      5�      m� 5�      $��_Kadra��6   .@�5�      m� $��Nowy pracownik��6   #��[ 67   $ Ctrl + E��6�    6\   �� *NewEmployeeCommand+ 5�      �� 5�      $��/Views/Icons/badd.png��6$   5�      m� 5�      $��Wszyscy pracownicy��6   #��[ 6;   $ 	Shift + E��6�    6`   �� *AllEmployeesCommand+ 5�      �� 5�      $��/Views/Icons/bbadge.png��6$   5�      5�      m� 5�      $��Opłaty��6   .@�5�      m� $��Zrealizuj nową opłatę��6   #��[ 6>   $ Ctrl + O��6�    6c   �� *OverdueChargeCommand+ 5�      �� 5�      $��/Views/Icons/bpayment.png��6$   5�      m� 5�      $��Wszystkie opłaty��6   #��[ 69   $ 	Shift + O��6�    6^   �� *AllOverdueChargesCommand+ 5�      �� 5�      $��/Views/Icons/bmoney.png��6$   5�      5�      m� 5�      $��Słownik��6   .@�5�      m� $��Dodaj nowego autora��6   #��[ 6<   $ Ctrl + A��6�    6a   �� *NewAuthorCommand+ 5�      �� 5�      $��/Views/Icons/bplus.png��6$   5�      m� 5�      $��Dodaj nowe wydawnictwo��6   #��[ 6?   $ Ctrl + B��6�    6d   �� *NewPublisherCommand+ 5�      �� 5�      $��/Views/Icons/bplus.png��6$   5�      m� 5�      $��Dodaj nową kategorię��6   #��[ 6=   $ Ctrl + C��6�    6b   �� *NewCategoryCommand+ 5�      �� 5�      $��/Views/Icons/bplus.png��6$   5�      m� 5�      $��Dodaj nową podkategorię��6   #��[ 6@   $ 	Shift + C��6�    6e   �� *NewSubcategoryCommand+ 5�      �� 5�      $��/Views/Icons/bplus.png��6$   5�      m� 5�      $��Dodaj nową lokalizację��6   #��[ 6?   $ Ctrl + L��6�    6d   �� *NewLocationCommand+ 5�      �� 5�      $��/Views/Icons/bplus.png��6$   5�      m� 5�      $��Dodaj nowe stanowisko��6   #��[ 6>   $ Ctrl + S��6�    6c   �� *NewPositionCommand+ 5�      �� 5�      $��/Views/Icons/bplus.png��6$   5�      m� 5�      $��Aktualizuj ratę dzienną��6   #��[ 6@   $ 	Shift + R��6�    6e   �� *UpdateDailyRateCommand+ 5�      �� 5�      $��/Views/Icons/bmoney.png��6$   5�      m� 5�      $��Wszyscy autorzy��6   #��[ 68   $ 	Shift + A��6�    6]   �� *AllAuthorsCommand+ 5�      �� 5�      $��/Views/Icons/blist.png��6$   5�      m� 5�      $��Wszystkie wydawnictwa��6   #��[ 6>   $ 	Shift + B��6�    6c   �� *AllPublishersCommand+ 5�      �� 5�      $��/Views/Icons/blist.png��6$   5�      5�      m� 5�      $��_Raport��6   .@�5�      m� $��Raport rozliczeń��6   #��[ 69   $ Ctrl + R��6�    6^   �� *SettlementReportCommand+ 5�      �� 5�      $��/Views/Icons/breport.png��6$   5�      5�      5�      �� 5�      $��1��6   $��Right=�6)   .+�5�      �� -   5         � ToolTip$ Minimalizuj��5�        MinimizeButton#��[ 6/   6W   �� 5�      -   5        $ Maksymalizuj��5�        ResizeButton#��[ 60   6V   �� 5�      -   5        $ Zamknij��5�        CloseButton#��[ 6+   6P   5�      5�      c� 5�   
     
ToolbarNew#��[ 6   $��1��66   .@�5�      �� -   5         ��Name$ ButtonOpenMenu��5�   &   $ Rozwiń��6     SlidePanelButton#��[ 6>   ��5�      �� 5�       �� ImageSource$ /Views/Icons/menu.png��6!   5�      �� 5�      -	   5        $ ButtonCloseMenu��5�   $   $ Zwiń��6   $y�	Collapsed=�6=   #��[ 6T   ��5�      �� 5�      $ /Views/Icons/menu.png��6!   5     d� 5     $0 *Raport rozliczenia opłat za przetrzymanie��6    	 DefaultToggleButton#��� 	 6O   ��6}   �� *SettlementReportCommand+��5     �� 5     $ /Views/Icons/report.png��6!   5     �� 5     $0��*Raport rozliczenia opłat za przetrzymanie��6   d� 5     $ Autor��6   #��� 	 6+   ��6Y   �� *NewAuthorCommand+��5	     �� 5
     $ /Views/Icons/plus.png��6!   5     �� 5     $��Dodaj nowego autora��6   d� 5     $ Wydawnictwo��6   #��� 	 61   ��6_   �� *NewPublisherCommand+��5     �� 5     $ /Views/Icons/plus.png��6!   5     �� 5     $��Dodaj nowe wydawnictwo��6   5     � 5  
   $��2��6    5     �� 5     -
   5         ��Name$ ColumnAnimate��5  #   $��40 �6:   �� 5     $��* �6#   .+�5     � -   5         �Name$ GridMenu��5  #   $��0��6    
 LeftMenuGrid#��[
 66    5     �� 5     $
��auto �6$   �� 5     $
��auto �6$   .+�5!     �� $��1��6)   $��0 2 0 0q�6X     CommandsTemplate#��[ 5"       MainHCCStyle#��[ 6F   ��5!  6   ��  �� Path$ Commands�5"  F   5#     �� 5&     $��1��6     BorderAroundWorkspace#��[ 6%   ._�5'     ��   WorkspacesTemplate#��[ 5)     #��[ 5*     ��5(     �� $ 
Workspaces�5*     5,     5-     �� 50  
   $��3��6     StatusBarDefault#��[ 6!   .@�51     �� $
��Left=�6   .��52     �� $9��3Biblioteka Publiczna im. Hansa Christiana Andersena��6     StatusBarLabel#��[ 6V   53     �� 54     .��55     ��   TaskConfirmationLabel#��[ 6>   ��6   �� *StatusInformation+6>   56     �� 57     $��Right=�6   .��58     �� .+�59     �� $+ %Czas i data od ostatniej aktualizacji��6    #��[ 6�   ��6P   �� 
 �� Now �� Source# Z 6�   �� 5:       	ImageLogo#��[ 6   5;     5<     5=     5?     5@     