   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewView  5   	       View.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:View     5   	     � Title$  TaskManager��5   	   $	��500��6   $	��900��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��101* �6   �� 5      $
��199* �6   .+�5   
   �� $��0��6   .��5      �  � RowDefinitions 5      �� 5      $	��37* �6$   �� 5      $��6* �6$   .+�5      �� $��0��6   .+�5      �� ��6   �� *Tasks+ �� SelectedItem 6=   �� *SelectedTask+5      �� 5      $��	0,407,0,0q�6   $��2��60   .+�5      �� $#��Добавить задачу��6   $��24��6U   $	��100��6a   $��10q�6m   $
��Left=�6z   ��67   �� *	CreateNew+6z   5      5       5"      �� 5$   
   $
��Info��6   $��1��6!   .��5%      �  5&      �� 5'      $��38 �6$   �� 5(      $	��367 �6$   .+�5,      ]� $��0��6   .+�5-      �� $��31��6   $��30��6(   
�������$��6,0,0,0q�6e   ��6G   �� *	OpenEdite+.��5.      �� $��Resources\EditeImage.png��6     � ToolTip$- 'Редактировать задачу��6B   5/      �� 51      $��30��6   $��76��6)   
�������$��6,0,0,0q�6f   ��6G   �� *
DeleteTask+.��52      �� $��Resources\DeleteImage.jpg��6    $! Удалить задачу��6C   $��73��6\   53      �� 55      $ ��Взять в работу��6   $��30��66   $��93��6B   
����� �$��40,0,0,0q�57      ��56      �� *SetStateInProgress+58      �� 5:      $ ��Приостановить��6   $��30��65   $��93��6A   
��� ���$��10,0,0,0q�5<      ��5;      �� *SetStateStopped+5=      �� 5>      $��Выполнить��6   $��30��61   $��93��6=   
���/���$��10,0,0,0q�5@      ��5?      �� *SetStateCompleted+5A      �� 5D      $
��Bold"�6B   $��Right=�6T   $��Center=�6p   $��90��6�   $��30��6�   $��0,0,6,0q�6�   ��6   �� *SelectedTask.State+.��6�   5F      5H         View.TaskInfoControl  5I      $��1��6(    � DataContext 65   �� *SelectedTask+�� 5J      $
��Left=�6   $��0��67   $��4,0,0,0q�6B   $��1��6S   
���   �$	��Top=�6o   $	��571��6�   5K      5L      5M      5N      