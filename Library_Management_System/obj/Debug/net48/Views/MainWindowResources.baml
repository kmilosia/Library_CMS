   M S B A M L   `   `   `  ����T  PLibrary_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Library_Management_System.ViewModels$Library_Management_System.ViewModels  5      Q-clr-namespace:Library_Management_System.ViewsLibrary_Management_System.Views  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� DataType9    3Library_Management_System.ViewModels.StockViewModel/   )Library_Management_System.Views.StockView;   5Library_Management_System.ViewModels.NewUserViewModel1   +Library_Management_System.Views.NewUserViewB   <Library_Management_System.ViewModels.NewPublicationViewModel8   2Library_Management_System.Views.NewPublicationView=   7Library_Management_System.ViewModels.BorrowingViewModel3   -Library_Management_System.Views.BorrowingView=   7Library_Management_System.ViewModels.ReturningViewModel3	   -Library_Management_System.Views.ReturningView<
   6Library_Management_System.ViewModels.AllUsersViewModel2   ,Library_Management_System.Views.AllUsersViewC   =Library_Management_System.ViewModels.AllPublicationsViewModel9   3Library_Management_System.Views.AllPublicationsView?   9Library_Management_System.ViewModels.NewEmployeeViewModel5   /Library_Management_System.Views.NewEmployeeView@   :Library_Management_System.ViewModels.AllEmployeesViewModel6   0Library_Management_System.Views.AllEmployeesViewA   ;Library_Management_System.ViewModels.AllBorrowingsViewModel7   1Library_Management_System.Views.AllBorrowingsView?   9Library_Management_System.ViewModels.StockUpdateViewModel5   /Library_Management_System.Views.StockUpdateView=   7Library_Management_System.ViewModels.NewAuthorViewModel3   -Library_Management_System.Views.NewAuthorView@   :Library_Management_System.ViewModels.NewPublisherViewModel6   0Library_Management_System.Views.NewPublisherViewA   ;Library_Management_System.ViewModels.OverdueChargeViewModel7   1Library_Management_System.Views.OverdueChargeViewE   ?Library_Management_System.ViewModels.AllOverdueChargesViewModel;   5Library_Management_System.Views.AllOverdueChargesViewD   >Library_Management_System.ViewModels.SettlementReportViewModel:   4Library_Management_System.Views.SettlementReportView>    8Library_Management_System.ViewModels.AllAuthorsViewModel4!   .Library_Management_System.Views.AllAuthorsViewA"   ;Library_Management_System.ViewModels.AllPublishersViewModel7#   1Library_Management_System.Views.AllPublishersView?$   9Library_Management_System.ViewModels.NewCategoryViewModel5%   /Library_Management_System.Views.NewCategoryViewB&   <Library_Management_System.ViewModels.NewSubcategoryViewModel8'   2Library_Management_System.Views.NewSubcategoryView?(   9Library_Management_System.ViewModels.NewLocationViewModel5)   /Library_Management_System.Views.NewLocationView?*   9Library_Management_System.ViewModels.NewPositionViewModel5+   /Library_Management_System.Views.NewPositionViewC,   =Library_Management_System.ViewModels.UpdateDailyRateViewModel9-   3Library_Management_System.Views.UpdateDailyRateView   OpenMenu �� TargetProperty �� 
TargetName9.  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu  BorderAroundWorkspace �� 
TargetType �� Property �� Value  SlidePanelButton  	LogButton �� ImageSource  SearchButton  CloseButton  ResizeButton  MinimizeButton 	 CommandsTemplate	 �� Path
 �� Orientation 
 ClosableTabItemTemplate  LeftMenuGrid  FullGrid  MainHCCStyle �� 
TargetType  SubMenuItem  StatusBarLabel  StatusBarDefault  TaskConfirmationLabel  	ImageLogo ��Name �� Triggers P� Property P� Value �� 
TargetName  DefaultToggleButton �� Triggers  
ToolbarNew ��Name d� 	IsChecked �� 	ClickMode a�Name K� IsItemsHost  WorkspacesTemplate$ �� IsSynchronizedWithCurrentItem�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      9vm2clr-namespace:Library_Management_System.ViewModels  5      4vw-clr-namespace:Library_Management_System.Views  5      %�#  (��       5      *,  +)(�� 2     5
      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)(�� ,    5      *, +)(�� ^    5      *, +)(�� �    5      *, +)(�� �    5"      *, +)(�� �    5%      *, +)(�� &    5(      *, +)(�� X    5+      *, +)(�� �    5.      *, +)(�� �    51      *, +)(�� �    54      *, +)(��      57      *,  +)(�� R    5:      *," +)(�� �    5=      *,$ +)(�� �    5@      *,& +)(�� �    5C      *,( +)(��     5F      *,* +)(�� L    5I      *,, +)&	  ~    &	 C    &	     &	 �    &	 �    &	 �    &	 	    &	 �
    &	 �    &		 �    &	
 �    &	 �    &	     &	 V    'o� �    &	 �    '�� J    &	 �    '�� *    &	 �    '�� �    &	     &	 �    '�� ^    &	 �    &	 �    &	 �    7 
 �� 5      "    6   .R�5   
     5	      �� 5
      "   6   .R�5   
     5      �� 5      "   6   .R�5   
     5      �� 5      "   6   .R�5   
     5      �� 5      "   6   .R�5   
   	  5      �� 5      "  
 6   .R�5   
     5      �� 5      "   6   .R�5   
     5      �� 5      "   6   .R�5   
     5      �� 5      "   6   .R�5    
     5!      �� 5"      "   6   .R�5#   
     5$      �� 5%      "   6   .R�5&   
     5'      �� 5(      "   6   .R�5)   
     5*      �� 5+      "   6   .R�5,   
     5-      �� 5.      "   6   .R�5/   
     50      �� 51      "   6   .R�52   
     53      �� 54      "   6   .R�55   
     56      �� 57      "    6   .R�58   
   !  59      �� 5:      "  " 6   .R�5;   
   #  5<      �� 5=      "  $ 6   .R�5>   
   %  5?      �� 5@      "  & 6   .R�5A   
   '  5B      �� 5C      "  ( 6   .R�5D   
   )  5E      �� 5F      "  * 6   .R�5G   
   +  5H      �� 5I      "  , 6   .R�5J   
   -  5K      �� 5O      .��5P   
   U� $ (FrameworkElement.Width)�6(   $ GridMenu��6]   .\�5Q      .  $ 0��6#   $ 40Q�6/   .  5R      $ 0:0:0.2��6#   $	 200Q�65   5S      5T      �� 5U      .��5V   
   U� $ (FrameworkElement.Width)�6(   $ GridMenu��6]   .\�5W      .  $ 0��6#   $	 200Q�6/   .  5X      $ 0:0:0.0��6#   $ 40Q�65   5Y      5Z      �� 5]      " ��6*   .�5^   
   ��  � �� �#1818226(   �� 5_   
    � �� �#1818226'   �� 5`   
    � ��$ 5 0 0 0q�6,   �� 5a   
    � ��$ 0q�6#   5b      �� 5e      " ��6%   .�5f   
   ��  � ��$ 25��6"   �� 5g   
    � ��$ 25��6#   �� 5h   
    � ��$
 Left=�60   �� 5i   
    � ��$ 0 0 5 0q�6#   �� 5j   
    � ��$ 0q�6,   5k      �� 5n      " ��6   .�5o   
   ��  � ��$ 25��6#   �� 5p   
    � ��$ 25��6"   �� 5q   
    � ��$ 0q�6,   �� 5r   
    � �� 5s      �� 5t      $ /Views/Icons/log.png��6   5v      5w      �� 5z      " ��6!   .�5{   
   ��  � ��$ 25��6#   �� 5|   
    � ��$ 25��6"   �� 5}   
    � ��$ 0q�6,   �� 5~   
    � �� 5      �� 5�      $ /Views/Icons/search.png��6   5�      5�      �� 5�      " ��6    .�5�   
   ��  � ��$ 30��6#   �� 5�   
    � ��$ 30��6"   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��$ 5q�6#   �� 5�   
    � �� 5�      �� 5�      $ /Views/Icons/close.png��6   5�      5�      �� 5�      " ��6!   .�5�   
   ��  � ��$ 30��6#   �� 5�   
    � ��$ 30��6"   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��$ 5q�6#   �� 5�   
    � �� 5�      �� 5�      $ /Views/Icons/resize.png��6   5�      5�      �� 5�      " ��6#   .�5�   
   ��  � ��$ 30��6#   �� 5�   
    � ��$ 30��6"   �� 5�   
    � ��$ 0q�6,   �� 5�   
    � ��$ 5q�6#   �� 5�   
    � �� 5�      �� 5�      $ /Views/Icons/minus.png��6   5�      5�      �� 5�      .R�5�   
   �� $��False��6   $��0q�6A   ���#181822���#181822��6)   �� ��5�      �� 5�      .R�5�      �� $��0 0 0 0q�5�      $	��9.5q�5�      ���#181822$��0q�5�      $
��Left=�5�      ���#181822
�������$��12(�5�      ��5�      �� $	 Command���5�      �� 5�      $
 
Horizontal=�6)   .+�5�   "   �� $��20��6H   $��20��6T   ��6(   �� *displayImage+6T   �� 5�   "   $��2 0 0 0q�6H   ��6(   �� *DisplayName+6H   5�      5�      5�      5�      5�      �� 5�      .R�5�   
   ]� $	��140��6   .+�5�      �� $��X��5�   	   $��Right=�5�   	   $|�False��5�   	   $��10(�5�   	   $��Medium"�5�   	   $��0,1,0,0q�5�   	   $��0 0 0 0q�5�   	   $��0q�5�   	   $��Center=�5�   	   $��16��5�   	   $��16��6   
������ 
���������5�   	   �� $	 CloseCommand�5�   	   �� 5�      $��Center=�5�   	   ��5�   	   �� $	 DisplayName�5�   	   5�      5�      �� 5�      " �6!   .�5�   
   ��  � ��$ 40��6"   �� 5�   
    � ��$
 Left=�60   5�      �� 5�      " �6   .�5�   
   ��  � �� �#1818226'   5�      �� 5�      " ��6!   .�5�   
   ��  � ��$ False��6&   �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      ]� .+�5�      �� $	��Top=�5�   	   $��Header��5�   	   #��z��5�   	   �� 5�      $��Content��5�   	   #��z��5�   	   5�      5�      5�      5      �� 5     " o�6   .�5  
   ��  � ��$ 4q�6#   �� 5  
    � �� �#20202d6'   �� 5  
    � ��$ 0q�6,   �� 5  
    � �� �#1818226(   �� 5  
    � ��
 �����6'   �� 5	  
    � ��$ Center=�6.   �� 5
  
    � ��$ 16(�6%   5     �� 5     " m�6    .�5  
   ��  � ��
 �   �6'   �� 5  
    � ��
 �����6'   �� 5  
    � ��$ 0q�6,   5     �� 5     " ��6   .�5  
   ��  � ��
 �����6'   5     �� 5     " ��6#   .�5  
   ��  � ��$ 15(�6%   �� 5  
    � ��$ Center=�6.   �� 5  
    � ��
 �����6'   5     �� 5"     " ��6   .�5#  
   ��  �@��Orientation$ 
Horizontal=�6(   5$     �� 5'     " ��6%   .�5(  
   ��  � �� �#20202d6'   �� 5)  
    � ��$ Center=�6.   �� 5*  
    � ��$ 0 0 0 0q�6#   �� 5+  
    � �� �#1818226'   �� 5,  
    � �� �#20202d6(   �� 5-  
    � ��$ 2q�6,   5.     �� 51     " ��6   .�52  
   ��  � ��$ Right=�60   �� 53  
    � ��$ Center=�65   54     �� 56     " ��6*   .�57  
   ��  � ��$ Center=�65   �� 58  
    � ��
 �����6'   �� 59  
    � ��$ 14(�6%   �� 5:  
    � ��$ 	200 0 0 0q�6#   5;     �� 5=     " ��6   .�5>  
   ��  � ��$ 	10 3 10 3q�6#   �� 5?  
    � ��$# /Views/Icons/storytelling.png��6#   5@     �� 5D     " ��6   .�5E  
   ��  � ��
 �����6'   �� 5F  
    � ��$ SemiBold"�6'   �� 5G  
    � ��$ 0 0 0 0q�6#   �� 5H  
    � �� 5I     �� 5J     " ��6"   .R�5K     � $��Panel��6   .+�5L     �� $ Contentsite��6/   $��Center=�5M     $��Center=�5N     $��Header��5O     $
��10,2q�5P     5Q      5R     P� 5S      �@��
IsSelected$
 True��68   . �5T     �� $ Panel��6%    � ��
 �����6N   �� 5U      � �� �#1818226<   5V     P� 5W      �@��
IsSelected$ False��68   . �5X     �� $ Panel��6%    � �� �#20202d6N   �� 5Y      � ��
 �����6<   5[     P� 5\      �@J�IsMouseOver$
 true��69   . �5]     �� $ Panel��6%    � ��
 �����6N   �� 5^      � �� �#1818226<   5`     5b     5d     5e     �� 5h     " d�6(   .�5i  
   ��  � ��$ 25��6#   �� 5j  
    � ��$ 25��6"   �� 5k  
    � ��$ 0q�6,   �� 5l  
    � ��$ 5 0 0 0q�6#    5m  
   P� 5n      �@J�IsMouseOver$
 True��6-   . �5o     ��  � ��
 �����60   �� 5p      � ��$ 1q�64   5q     P� 5r      � ��$
 True��6+   . �5s     ��  � ��
 ���w�60   �� 5t      � ��$ 1q�64   5u     5w     �� 5z     " c�6   .�5{  
   ��  �@J�SnapsToDevicePixels$
 True��60   �� 5|  
    �@�OverridesDefaultStyle$
 true��62   �� 5}  
    � ��$ Center=�6.   �� 5~  
    � �� 5     �� 5�     " c�6"   .R�5�     �� $ Border��6   $��0q�6-   ���#181822���#181822$��8 2 8 4q�6l   ._�5�     ]� .+�5�     d� $y�	Collapsed=�6+   $��Right=�6B   ${�False��6Y   $ FalseY�6k   $ Press=�6}   5�     a� 5�     $ PART_ToolBarPanel��6+   $
 true��6F   $��0,0,0,0q�6Y   5�     5�     5�     5�     5�     �� 5�     .R�5�  
   �� $
 TrueY�5�     8��  $��0 0 0 0q�5�     ���#181822$��0q�5�     ���#181822��5�     �� 5�     5�     5�     