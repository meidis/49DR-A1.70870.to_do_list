   M S B A M L   `   `   `  ����  	Zadanie_3    Zadanie_3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
MainWindow��5   	   $	��800��6   $	��600��6)   .��5      � .+�5	   
   �� .+�5
      � $��Center=�6   $��0 2 0 2q�65   .+�5      �� $��0 2 2 0q�6   $��Wszystkie zadania��6)   $��Center=�6E   $
��18px(�6b   �� 5      -   5        $��AddNewWorkItem��5      $��0 2 2 0q�6/   $��Right=�6@   $
��25px��6\   $
��65px��6j   $��Dodaj��6w   6�   �� 5      -   5        $��DeleteWorkItem��5      $��0 2 2 0q�6/   $��Right=�6@   $
��25px��6\   $
��65px��6j   $��Usuń��6w   6�   5      �� 5      -   5        $��allWorkItems��5   E    %� IsVirtualizing .  $��800px��6Y   $��600px��6h    �� View 5      �� 5      .P�5      �� $��Tytuł��6)    �� Width$	 150��68    �� DisplayMemberBinding 6D   �� *Title+�� 5      $
��Opis��6)   $	 150��67    6C   �� *Description+�� 5      $��Data utworzenia��6)   $	 150��6B    6N   �� *DateCreated+�� 5      $��Data zakończenia��6)   $	 150��6C    6O   �� *	EndDate+5       � 	Resources 5       �� 
TargetType �� Triggers �� Binding	 �� Value
 �� Property �� Value��%  '��       �� 5      " ��6    5      �� 5       6*   �� *CurrentStatus+	 35   *   .a�5   "   �� 
 � ��
 �  ��5   )   5       �� 5!       6*   �� *CurrentStatus+	 25"   *   .a�5#   "   �� 
 � ��
 � ���5$   )   5%      5'      5(      5)      5*      5+      5,      