   M S B A M L   `   `   `  ����  RecipeAppPOE$    RecipeAppPOE.ScaleRecipeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Scale Recipe��5   	   $	��300��6   $	��400��6+   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5      �� $��Scale Factor:��6   $��10q�6-   $��Center=�69   �� 5      -   5         ��Name$ ScaleFactorTextBox��5      $	��100��62   $��10q�6>   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5      �� -   5        $��Scale��5      $	��100��69   $��10q�6E   �� 5      -   5        $��Reset��5      $	��100��69   $��10q�6E   5      �� 5   
   -   5         ��Name$ IngredientsListBox��5      $��2��6.   $��10q�6;   $	��Top=�6G   ��5      �� 5      .R�5      �� $ 
Horizontal=�6!   .+�5      �� $	��100��6:   ��6$   �� *Name+6:   �� 5      $��50��6>   ��6$   �� *
Quantity+6>   �� 5      $��50��6:   ��6$   �� *Unit+6:   �� 5      $��50��6>   ��6$   �� *
Calories+6>   �� 5      $	��150��6?   ��6$   �� *	FoodGroup+6?   5       5!      5#      5$      5%      