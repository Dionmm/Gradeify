   M S B A M L   `   `   `  ����E  ACoursework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Coursework
Coursework  5           Coursework.DisplayStudents   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Coursework     5        N� Title$  DisplayStudents��5	       � 	Resources 5
         Coursework.StudentList   passedStudents  failedStudents��%:   &	        &	        5   
   6     5   
   6   5      .��5      � -   5         �Name$ studentGrid��5        myStudentList � DataContext# [ 6     � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      �� 5      �� 5      $
��1.5* �6   .+�5   
   �� -   5         ��Name$ Header��5      $��0��6    $��0��6-   $��2��6=   $��All Students��6Q   ���#1c2f2f$��bottom=�6}   $
��left=�6�   $��veranda)�6�   $��15(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ studentListBox��5      $��1��6*   $��0��67   $��2��6G   $��2��6[   $��10q�6l   ��6x   �� 6�   � 5   
   $��0��6   $��4��6   $��2��6,   $��10,0,0,0q�6�    6@   ��  �� ElementName$ studentListBox��	 �� Path$	 SelectedItem� 5      �� 5      �� 5       5!      �� 5"      �� 5#      �� 5$      �� 5%      .+�5'      �� -   5        $ studentName��5'      $��0��6K   $��0��6X   $��SemiBold"�6h   ��6)   �� $	 FullName�6h   �� 5(      -   5        $ studentMatric��5(      $��0��6R   $��1��6_   $��SemiBold"�6o   ��6+   �� $	 Matriculation�6o   �� 5)      -   5        $ studentCom1��5)      $��1��6M   $��1��6Z   ��6)   �� $	 
Component1�6Z   �� 5*      -   5        $ studentCom2��5*      $��2��6M   $��1��6Z   ��6)   �� $	 
Component2�6Z   �� 5+      -   5        $ studentCom3��5+      $��3��6M   $��1��6Z   ��6)   �� $	 
Component3�6Z   �� 5,      $��Component 1:��6   $��1��6+   $��0��68   �� 5-      $��Component 2:��6   $��2��6+   $��0��68   �� 5.      $��Component 3:��6   $��3��6+   $��0��68   5/      50      51      