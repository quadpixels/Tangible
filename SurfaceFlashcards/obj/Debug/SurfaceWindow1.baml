   M S B A M L   `   `   `  ����  SurfaceFlashcards    HelloWorld.SurfaceWindow1   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      e aMicrosoft.Surface.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e351s)http://schemas.microsoft.com/surface/2008  5        � Title$  
HelloWorld��5      $	��640��6   $	��140��6'    � 	Resources 5         WindowBackground j� Stretch �� Opacity �� ImageSource��%x   &	        �� 5   
   $
 None=�6.   $	 0.6Q�6=   $; 5pack://application:,,,/Resources/WindowBackground.jpg��6K   5      .��5
      � #��[  6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   ;  5Microsoft.Surface.Presentation.Controls.SurfaceButton  -   5        $��SurfaceButtonAddImplicit��5      
�������$��Add Item (Implicit)��5      $��0��5      $��0��6   $��30��5      $	��160��6   6%     5   
   -   5        $��SurfaceButtonAddExplicit��5      
�������$��Add Item (Explicit)��5       $��1��5!      $��0��6   $��30��5"      $	��160��6   6%     5$   
   -   5        $��SuperButton��5%      
�������$��Magic button��5'      $��2��5(      $��0��6   $��30��5)      $	��160��6   6%   9  3Microsoft.Surface.Presentation.Controls.ScatterView  5+   
   -   5        $��MyScatterView��5,      $��Stretch=�5+      $��Stretch=�66   $��0��5-      $��4��6(   $��1��6<   50      52      54      