   M S B A M L   `   `   `  ����M  IPatternEditor_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PatternEditor_MVVMPatternEditor_MVVM  5   	   A%clr-namespace:PatternEditor_MVVM.ViewPatternEditor_MVVM.View  5   	   K*clr-namespace:PatternEditor_MVVM.ViewModelPatternEditor_MVVM.ViewModel  5   	   #    PatternEditor_MVVM.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2local clr-namespace:PatternEditor_MVVM     5   	   4vw%clr-namespace:PatternEditor_MVVM.View     5   	   9vm*clr-namespace:PatternEditor_MVVM.ViewModel     5   	     � Title$  Pattern Editor��5   	   $��829.875��6    $
��1130��61    � 	Resources 5	       �� Source�� 5
   
   $ MainWindowResources.xaml?�6   %    5       J� InputBindings 5      �� 5   
   
 �� Key$ O��6    �� 	Modifiers$ Controlf�6    �� Command 61   ��  �� Path$ OpenCommand�6X   �� 5   
   $ C��6   $ Controlf�6    61   �� $ CloseCommand�6Y   �� 5   
   $ X��6   $ Controlf�6    61   �� $ ExitCommand�6X   .��5      ]� -   5        $��	mainPanel��5      .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� $��_Open��6    � ToolTip$
 Open��6*   	 m� InputGestureText$	 Ctrl+O��6^   
 m� Command
 69   �� $ OpenCommand� m� Icon 5      �� 5      $M��Gpack://application:,,,/PatternEditor_MVVM;component/Images/FileOpen.png��6    $��21��6q   6   5      m� 5      $��_Exit��6   $
 Exit��6*   $	 Ctrl+X��6^   
 69   �� $ ExitCommand�6^   5      5      � 5   
   .+�5       ��    EditorFilesTemplate#��[  5"   	   ��5!   	   �� $ EditorFileVM�5"   	   5$      5%      5&      