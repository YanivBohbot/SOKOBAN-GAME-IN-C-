   M S B A M L   `   `   `  ����B  >SOKOBAN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SOKOBANSOKOBAN  5   	       SOKOBAN.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:SOKOBAN     5   	     � Title$  
MainWindow��5   	   $��648.5��6   $��611.5��6+    � 
ResizeMode$ NoResize=�69   .��5	      �� ���	#FFF0DF3C$��0,0,-6,0q�6$    J� RenderTransformOrigin$ 0.493,0.491&�66   .+�5
   
   �� -   5         ��Name$ canvas_gride��5
      $��504.045��6'    �� Left$ 44.333��68   
 �� Top$ 94.824��6M   $��507.667��6a   
���   �$ 0.512,0.482&�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleY$ 0.189Q�6$   �� 5      T� 5       T� Y$ 0.765Q�6)   5      5      �� 5   
   -   5        $ 
cnv_Mobile��5      $��501.045��6%   $��507.667��66   $
 45.5��6F   $ 96.455��6Y   �� 5   
   -   5         ��Name$ btn_restart��5      $��restart ��6&   $ 70.009��69   $ 34.333��6N   $��104.314��6b   $ 0.5,0.5&�6r   $��30.627��6�   $��Segoe UI Black)�6�   $��16(�6�   z�5      V� 5      .~�5      �� �� 5      	 �� AngleX$	 -1.739Q�6$   �� 5      T� 5      
 T� X$
 -0.303Q�6)   5      5      �� 5   
   -   5         ��Name$ txt_numbermoves��5      $	 207��6-   $
��Wrap=�6?   $ 35��6S   $��32��6c   $	��195��6o   $��Segoe UI Black)�6{   $ 
0.549,0.81&�6�   $��16(�6�   z�5       V� 5!      .~�5"      �� �� 5#      $ 0.169Q�6$   �� 5$      T� 5%      $ 0.363Q�6)   5&      �� 5'   *   $�Numbers  of moves��6.   �� 6I   $�     :��6M   6^   �� 5(   
   -   5        $ txt_bock_count��5(      $	 413��6,   $
��Wrap=�6>   $ 37��6R   $��24��6b   $��54��6n   $��16(�6y   �� 6�   $
�    ��6�   �� 6�   $
��Bold"�6�   $�0��6�   6�   5)      5*      