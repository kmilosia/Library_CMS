   M S B A M L   `   `   `  ����T  PLibrary_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Library_Management_SystemLibrary_Management_System  5      #    Library_Management_System.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      9local'clr-namespace:Library_Management_System     5        �� 	Resources  5         validationTemplate �� Orientation �� ElementName �� Path ��Name  textBoxInError �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value  datepickerInError(  "System.Windows.Controls.DatePicker��%  &	        &	 5    &	 l    �� 5   
   .R�5      ]� .+�5	      �� $ 
Horizontal=�6   $	��Top=�66   .+�5
      �� 
���  ��$��0,0,0,2q�61   ��5      �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      5      �� 5      $ ErrorAdorner��6,   5      5      5      �� 5   
   " ��6'   .�5      ��  � ��
 �   �6+   �� 5       � ��$ 14(�6)   �� 5       � ��$	 200��6&   �� 5       � ��$ 25��6'   �� 5       � ��$ 
0 10 10 10q�6'   �� 5       � ��$ 2 0 0 0q�6(   �� 5       � ��
 �����6+   �� 5       � �� �#d6b9fc6,   �� 5       � ��$ 1q�60   �� 5       � ��$ Center=�69    5      P� 5      	 � {�$
 False��6/   . �5       ��  � ��
 �   �63   �� 5!       � �� �#C49BFF64   5"      5$      �� 5%   
   "  6*   .�5&      ��  � ��
 �   �6+   �� 5'       � ��$ 14(�6)   �� 5(       � ��$	 200��6&   �� 5)       � ��$ 25��6'   �� 5*       � ��$ 
0 10 10 10q�6'   �� 5+       � ��
 �����6+   �� 5,       � �� �#d6b9fc6,   �� 5-       � ��$ 1q�60   �� 5.       � ��$ Center=�69   5/      50      51      