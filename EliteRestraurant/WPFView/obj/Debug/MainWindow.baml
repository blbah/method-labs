   M S B A M L   `   `   `  ����B  >WPFView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPFViewWPFView  5   	       WPFView.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WPFView     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $��Menu:��6   $
��Left=�6    $��28��6;   $��
171,25,0,0q�6G   $	��Top=�6[   $	��133��6s   �� 5   
   $
��Left=�6   $	��338��6-   $��	70,58,0,0q�6:   $	��Top=�6M   $	��249��6e   ��6q   �� *Dishes+ �� SelectedItem 5      �� *SelectedDish+�� 5   
   $��384,43,255.6,253q�6:    � DataContext 6   �� *SelectedDish+.+�5      �� $
��Name��6   �� 5      ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $
��Type��6   �� 5      $��28��6W   $��
0,0,-0.4,0q�6c   ��6   �� *
DishType+$ PropertyChanged=�6c   5      �� 5   
   $��Your Order:��6   $
��Left=�6&   $��28��6A   $��
587,25,0,0q�6M   $	��Top=�6a   $	��133��6y    J� RenderTransformOrigin$ 0.517,0.734&�6�   �� 5   
   $��Make
Order��6   $
��Left=�6/   $��621,346,0,0q�6J   $	��Top=�6_   $��50��6w   $	��114��6�   ��6�   �� *AddOrderCommand+�� 5   
   $��    Add
to order��6   $
��Left=�65   $��424,346,0,0q�6P   $	��Top=�6e   $��50��6}   $	��114��6�   ��6�   �� *AddDishCommand+�� 5   
   $
��Left=�6   $	��244��6-   $��
587,71,0,0q�6:   $	��Top=�6N   $	��166��6f   ��6r   �� *	Ordered+�� 5   
   $
��Left=�6Q   $��384,231,0,0q�6l   $	��Top=�6�   $ 0.441,0.082&�6�   $��84��6�   $	��170��6�   ��6   �� *	Message+$ PropertyChanged=�6�   5      5      