   M S B A M L   `   `   `  ����?  ;View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:View.CustomControlsView.CustomControls  5   	   =    7View.CustomControls.testWindowForConfigureCustomControl   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:View.CustomControls     5   	     � Title$)  #testWindowForConfigureCustomControl��5   	   $	��450��65   $	��800��6B   .��5      � .+�5   
   �� $
��Left=�6   $��	40,10,0,0q�6/   $
��Wrap=�6B   $��Наименование��6V   $	��Top=�6j   �� 5   
   -   5         ��Name$ 
PART_Title��5      $
��Left=�6'   $��	40,30,0,0q�6B    �� TextWrapping$
 Wrap=�6U   $	��Top=�5      $	��264��65   $��24��6A   �� 5   
   $
��Left=�6   $��	40,76,0,0q�6/   $
��Wrap=�6B   $#��Описание задачи��6V   $	��Top=�6m   �� 5   
   -   5        $ PART_Description��5      $
��Left=�6-   $��
40,105,0,0q�6H   $
 Wrap=�6\   $	��Top=�5      $	��698��65   $	��108��6A   �� 5   
   $
��Left=�6   $��
370,10,0,0q�6/   $
��Wrap=�6C   $��Исполнители��6W   $	��Top=�6j   �� 5   
   -   5        $ PART_Executers��5      $
��Left=�6+   $��
370,31,0,0q�6F   $
 Wrap=�6Z   $	��Top=�5      $	��197��65   $��23��6A   �� 5   
   $y�Hidden=�6   $
��Left=�6(   $��
651,10,0,0q�6C   $
��Wrap=�6W   $%��Дата регистрации��6k   $	��Top=�6�   �� 5   
   -   5        $ PART_DateReg��5   &   $y�Hidden=�6   $
��Left=�6=   $��
638,31,0,0q�6X   $
 Wrap=�6l   $	��Top=�5      $	��142��65   $��23��6A   �� 5"   
   $
��Left=�6   $��
54,256,0,0q�6/   $
��Wrap=�6C   $:��4Плановая трудоемкость (дней)��6W   $	��Top=�6{   �� 5#   
   -   5        $ PART_PlanCost��5#      $
��Left=�6*   $��
54,277,0,0q�6E   $
 Wrap=�6Y   $	��Top=�5$      $��46��65   $��24��6@   �� 5'   
   $
��Left=�6   $��244,257,0,0q�6/   $
��Wrap=�6D   $<��6Фактически затраченное время��6X   $	��Top=�6|   �� 5(   
   -   5        $ PART_FactTimeExecute��5(      $
��Left=�61   $��244,277,0,0q�6L   $
 Wrap=�6a   $	��Top=�5)      $��46��65   $��24��6@   �� 5,   
   $
��Left=�6   $��492,257,0,0q�6/   $
��Wrap=�6D   $#��Дата завершения��6X   $	��Top=�6o   �� 5-   
   -   5        $ PART_DateEnd��5-      $
��Left=�6)   $��492,278,0,0q�6D   $
 Wrap=�6Y   $	��Top=�5.      $	��187��65   $��24��6A   �� 51   
   -   5         ��Name$ PART_FirstButton��51      $��OK��6+   $��25��68   $��81��6D   $��507,375,0,30q�6O   $
��Left=�6e   �� 52   
   -	   5        $ PART_SecondButton��52      $��Отмена��6,   $��25��6=   $��81��6I   $��647,375,0,30q�6T   $
��Left=�6j   56      57      