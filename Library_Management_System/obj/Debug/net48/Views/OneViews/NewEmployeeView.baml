   M S B A M L   `   `   `  ����T  PLibrary_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Library_Management_System.ViewsLibrary_Management_System.Views  5      5    /Library_Management_System.Views.NewEmployeeView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Library_Management_System.Views     5        � 	Resources  5	       �� Source�� 5
   
   $ TabStyle.xaml?�6   %    .��5      �    	LightGrid#��[  6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �� $��0��6     RoundBorder#��[ 6%   $��
20 20 0 10q�6J   ._�5      �� .+�5      �� $��Dodaj nowego pracownika��6     h3#��[ 6>   � 5        FullWindowGrid#��[ 6    5      �� 5      $
��auto �6/   �� 5       5      �� 5      �� 5       �� 5!      �� 5"      .+�5$      �� $��*Imię:��6    $��0��61   $��0��6A     	Text-Form#��[ 6N   �� 5%      $��1��6"   $��0��62     textBoxInError#��[ 6?     validationTemplate =� ErrorTemplate# [ 6g   ��6�   ��  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True���� 5&      $��
*Nazwisko:��6    $��0��65   $��1��6E   #��[ 6R   �� 5'      $��1��6"   $��1��62   #��[ 6?   # [ 6g   ��6�   �� $ Surname�$ PropertyChanged=�$
 True���� 5(      $��*Płeć:��6    $��0��61   $��2��6A   #��[ 6N   �� 5)      $��1��6#   $��2��63     Combobox-Form#��[ 6@    �� DisplayMemberPath$ Value��5+      	 �� SelectedValuePath$		 Key��5,      ��5*      �� *GendersComboBoxItems+
 �� SelectedValue
 5-      �� $ IDGender�$ PropertyChanged=� �� Mode$ TwoWay=��� 5/      $��*Data urodzenia:��6    $��0��6;   $��3��6K   #��[ 6X   (  "System.Windows.Controls.DatePicker  50      $��3��6%   $��1��62     Datepicker-Form#��[ 6B      SelectedDate 6k   �� $ Birthday�$ PropertyChanged=�$ TwoWay=�51      52      53      �� 54      $��1��6   #��[ 6"   $��	20 0 0 20q�6G   ._�55      �� .+�56      �� #��[ 6   $��Dane kontaktowe��68   � 57       	 
WindowGrid#��[	 6    58      �� 59      $
��auto �6/   �� 5:       5<      �� 5=      �� 5>      .+�5@      �� $��*Email:��6    $��0��62   $��0��6B   #��[ 6O   �� 5A      $��1��6"   $��0��62   #��[ 6?   # [ 6g   ��6�   �� $ Email�$ PropertyChanged=�$
 True���� 5B      $��*Numer telefonu:��6    $��0��6;   $��1��6K   #��[ 6X   �� 5C      $��1��6"   $��1��62   #��[ 6?   # [ 6g   ��6�   �� $ PhoneNumber�$ PropertyChanged=�$
 True��5D      5E      5F      5G      � 5H   
   $��1��6    5I      �� 5J      $
��auto �6    �� 5K      .+�5M      �� $��0��6   #��[ 6"   $��
10 20 20 0q�6G   ._�5N      �� .+�5O      �� #��[ 6   $��
Stanowisko��68   � 5P      #��[ 6    5Q      �� 5R      $
��auto �6/   �� 5S      .+�5U      �� $��*Stanowisko:��6    $��0��67   #��[ 6G   �� 5V      $��1��6#   #��[ 63   $ Value��5X      $		 Key��5Y      ��5W      �� *PositionsComboBoxItems+
 5Z      �� $ 
IDPosition�$ PropertyChanged=�$ TwoWay=�5\      5]      5^      �� 5_      $��1��6   #��[ 6"   $��10 10 20 20q�6G   ._�5`      �� .+�5a      �� #��[ 6   $��Adres��68   � 5b      #��[ 6    5c      �� 5d      $
��auto �6/   �� 5e       5g      �� 5h      �� 5i      �� 5j      �� 5k      �� 5l      .+�5n      �� $��*Ulica:��6    $��0��62   $��0��6B   #��[ 6O   �� 5o      $��1��6"   $��0��62    
 Textbox-Form#��[
 6?   ��6e   �� $ Street�$ PropertyChanged=��� 5p      $��Numer domu:��6    $��0��66   $��1��6F   #��[ 6S   �� 5q      $��1��6"   $��1��62   #��[
 6?   ��6e   �� $ HouseNumber�$ PropertyChanged=��� 5r      $��*Kod pocztowy:��6    $��0��69   $��2��6I   #��[ 6V   �� 5s      $��1��6"   $��2��62   #��[
 6?   ��6e   �� $ Postcode�$ PropertyChanged=��� 5t      $��*Miasto:��6    $��0��63   $��3��6C   #��[ 6P   �� 5u      $��1��6"   $��3��62   #��[ 6?   # [ 6g   ��6�   �� $
 City�$ PropertyChanged=�$
 True���� 5v      $��*Kraj:��6    $��0��61   $��4��6A   #��[ 6N   �� 5w      $��1��6"   $��4��62   #��[ 6?   # [ 6g   ��6�   �� $ Country�$ PropertyChanged=�$
 True��5x      5y      5z      5{      5|      5}      