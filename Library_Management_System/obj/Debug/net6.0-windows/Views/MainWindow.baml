   M S B A M L   `   `   `  ����T  PLibrary_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Library_Management_SystemLibrary_Management_System  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   *    $Library_Management_System.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Library_Management_System     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5          � Title$   System obsługi biblioteki��5	   	    � 
ResizeMode$ NoResize=�6H    � WindowStyle$
 None=�6^   $	��600��6q   $
��1050��6~    � 	Resources 5       �� Source�� 5   
   $ MainWindowResources.xaml?�6   %     J� InputBindings 5      �� 5   
   
 �� Key$ N��6    �� 	Modifiers$
 Ctrlf�6    �� Command 6.   �� *NewUserCommand+�� 5   
   $ D��6   $
 Ctrlf�6    6.   �� *NewBookCommand+�� 5   
   $ S��6   $
 Ctrlf�6    6.   �� *AllBooksCommand+�� 5   
   $ U��6   $
 Ctrlf�6    6.   �� *AllUsersCommand+�� 5   
   $ T��6   $
 Ctrlf�6    6.   �� *CalendarCommand+�� 5   
   $ W��6   $
 Ctrlf�6    6.   �� *RentingCommand+�� 5   
   $ Z��6   $
 Ctrlf�6    6.   �� *ReturnCommand+�� 5   
   $ M��6   $
 Ctrlf�6    6.   �� *StockCommand+	 � Triggers	 5      :� 5   
   
 :� RoutedEvent$
 ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5      ��    OpenMenu#��[  6   5       :� 5!   
   $
 ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5"      ��   	CloseMenu#��[ 6   5#      .��5'      �   FullGrid#��[ 6    � RowDefinitions 5(   
   �� 5)      $��40 �6   �� 5*      $��40 �6   �� 5+      $��* �6   �� 5,      $��40 �6   .+�50   
   � $��0��6    � ColumnDefinitions 51      �� 52      $
��auto �6#   �� 53      .+�55      o� $��0��6   .@�56      m� $��_Okno��6   .@�57      m� -   5        $��Zamknij okno��57        SubMenuItem#��[ 65    m� Icon 58      �� 59      $��/Views/Icons/bcross.png��6$   5;      m� 5<      -   5        $��Maksymalizuj okno��5<      #��[ 6:    5=      �� 5>      $��/Views/Icons/bsquare.png��6$   5@      m� 5A      -   5        $��Minimalizuj okno��5A      #��[ 69    5B      �� 5C      $��/Views/Icons/bminus.png��6$   5E      5F      m� 5G      $��_Użytkownik��6   .@�5H      m� $��Dodaj użytkownika��6   #��[ 6:    m� InputGestureText$ Ctrl + N��6�    m� Command 6`   �� *NewUserCommand+ 5I      �� 5J      $��/Views/Icons/badd.png��6$   5L      m� 5M      $��Usuń użytkownika��6   #��[ 69    6^   ��  5N      �� 5O      $��/Views/Icons/bremove.png��6$   5Q      m� 5R      $��Edytuj użytkownika��6   #��[ 6;    6`   ��  5S      �� 5T      $��/Views/Icons/bedit.png��6$   5V      m� 5W      $��Użytkownicy��6   #��[ 64   $ Ctrl + U��6}    6Y   �� *AllUsersCommand+ 5X      �� 5Y      $��/Views/Icons/bpeople.png��6$   5[      5\      m� 5]      $��
_Książki��6   .@�5^      m� $��Dodaj książkę��6   #��[ 66   $ Ctrl + D��6~    6[   �� *NewBookCommand+ 5_      �� 5`      $��/Views/Icons/bbook.png��6$   5b      m� 5c      $��Usuń książkę��6   #��[ 65    6Z   ��  5d      �� 5e      $��/Views/Icons/btrash.png��6$   5g      m� 5h      $��Spis książek��6   #��[ 65   $ Ctrl + S��6~    6Z   �� *AllBooksCommand+ 5i      �� 5j      $��/Views/Icons/blist.png��6$   5l      5m      m� 5n      $��_Magazyn��6   .@�5o      m� $��Magazyn��6   #��[ 60   $ Ctrl + M��6v    6U   �� *StockCommand+ 5p      �� 5q      $!��/Views/Icons/binventory.png��6$   5s      5t      m� 5u      $��_Wypożyczenia��6   .@�5v      m� $��	Wypożycz��6   #��[ 61   $ Ctrl + W��6y    6V   �� *RentingCommand+ 5w      �� 5x      $��/Views/Icons/bcart.png��6$   5z      m� 5{      $��Zwrot��6   #��[ 6.   $ Ctrl + Z��6u    6S   �� *ReturnCommand+ 5|      �� 5}      $��/Views/Icons/breturn.png��6$   5      m� 5�      $��
Przedłuż��6   #��[ 61    6V   ��  5�      �� 5�      $��/Views/Icons/btime.png��6$   5�      m� 5�      $��Opłata za przedłużenie��6   #��[ 6?    6d   ��  5�      �� 5�      $��/Views/Icons/bpay.png��6$   5�      5�      m� 5�      $��_Pomoc��6   6-   �� 5�       � ToolTip$ Szukaj��6     SearchButton#��[ 6*   5�      �� 5�      $��1��6   $��Right=�6)   .+�5�      �� -   5        $ Minimalizuj��5�        MinimizeButton#��[ 6/   6W   �� 5�      -   5        $ Maksymalizuj��5�        ResizeButton#��[ 60   6V   �� 5�      -   5        $ Zamknij��5�        CloseButton#��[ 6+   6P   5�      5�      c� 5�   
     
ToolbarNew#��[ 6   $��1��66   .@�5�      �� -   5         ��Name$ ButtonOpenMenu��5�   &   $ Rozwiń��6    	 SlidePanelButton#��[	 6>   ��5�      �� 5�       �� ImageSource$ /Views/Icons/menu.png��6!   5�      �� 5�      -	   5        $ ButtonCloseMenu��5�   $   $ Zwiń��6   $y�	Collapsed=�6=   #��[	 6T   ��5�      �� 5�      $ /Views/Icons/menu.png��6!   5�      d� 5�      $ Dodaj użytkownika��6    
 DefaultToggleButton#��� 
 67   ��6e   �� *NewUserCommand+��5�      �� 5�      $ /Views/Icons/person.png��6!   5�      �� 5�      $��Dodaj użytkownika��6   d� 5�      $ Lista użytkowników��6   #��� 
 68   ��6f   �� *AllUsersCommand+��5�      �� 5�      $ /Views/Icons/people.png��6!   5�      �� 5�      $��Użytkownicy��6   d� 5�      $ Dodaj książkę��6   #��� 
 63   ��6a   �� *NewBookCommand+��5�      �� 5�      $ /Views/Icons/book.png��6!   5�      �� 5�      $��Dodaj książkę��6   d� 5�      $ Spis książek��6   #��� 
 62   ��6`   �� *AllBooksCommand+��5�      �� 5�      $ /Views/Icons/list.png��6!   5�      �� 5�      $��Spis książek��6   d� 5�      $ 	Wypożycz��6   #��� 
 6.   ��6\   �� *RentingCommand+��5�      �� 5�      $ /Views/Icons/renting.png��6!   5�      �� 5�      $��	Wypożycz��6   d� 5�      $ Zwróć��6   #��� 
 6+   ��6Y   �� *ReturnCommand+��5�      �� 5�      $  /Views/Icons/returning.png��6!   5�      �� 5�      $��Zwróć��6   d� 5�      $ Stan magazynu��6   #��� 
 63   ��6a   �� *StockCommand+��5�      �� 5�      $ /Views/Icons/stock.png��6!   5�      �� 5�      $��Stan magazynu��6   d� 5�      $ Edytuj��6   #��� 
 6,   ��5�      �� 5�      $ /Views/Icons/edit.png��6!   5�      �� 5�      $��Edytuj��6   d� 5�      $ Drukuj��6   #��� 
 6,   ��5�      �� 5�      $ /Views/Icons/print.png��6!   5�      �� 5�      $��Drukuj��6   d� 5�      $ Więcej info��6   #��� 
 61   ��5�      �� 5�      $ /Views/Icons/info.png��6!   5�      �� 5�      $
��Info��6   5�      � 5�   
   $��2��6    5�      �� 5�      $	��150 �6#   �� 5�      $��* �6#   .+�5�      � -
   5         �Name$ GridMenu��5�   #   $��0��6     LeftMenuGrid#��[ 65    5�      �� 5�      $
��auto �6$   �� 5�      $
��auto �6$   .+�5�      �� $��1��6)   $��0 2 0 0q�6X     CommandsTemplate#��[ 5�        MainHCCStyle#��[ 6F   ��5�   6   ��  �� Path$ Commands�5�   F   5�      �� 5�      $��1��6     BorderAroundWorkspace#��[ 6%   ._�5�      ��   WorkspacesTemplate#��[ 5�      #��[ 5�      ��5�      �� $ 
Workspaces�5�      5�      5�      �� 5�   
   $��3��6     StatusBarDefault#��[ 6!   .@�5�      �� .��5�      �� .+�5�      �� $8��2Biblioteka Publiczna im. Marii Skłodowskiej-Curie��6     StatusBarLabel#��[ 6X   5�      5�      �� 5      .��5     �� .+�5     �� $+ %Czas i data od ostatniej aktualizacji��6   #��[ 6�   ��6L   �� 
 �� Now �� Source# Z 6�   �� 5     $ Wyloguj się��6     	LogButton#��[ 63   �� 5     $��Wyloguj��6   #��[ 6.   5     5     5     5	     5
     