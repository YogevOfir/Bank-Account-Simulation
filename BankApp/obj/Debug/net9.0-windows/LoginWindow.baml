   M S B A M L   `   `   `  ����B  >BankApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BankAppBankApp  5   	       BankApp.LoginWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:BankApp     5   	     � Title$  
Bank Login��5   	   $	��450��6   $	��400��6)   ���#F5F5F5 � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   �� ���#1976D2 �� Padding$ 	0,20,0,20q�6&   ._�5      �� $��Bank Account Login��6   $��28(�5      $
��Bold"�6$   
�������$��Center=�5      5      � 5   
   $��20,20,20,20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��0��6   
������� �� CornerRadius$ 5��65   $ 20q�6F   $��0,0,0,20q�6S   ._�5       �� .+�5!      �� $��Login to Your Account��6    $��20(�6=   $
��Bold"�6K   $��0,0,0,20q�6]   � 5#       5$      �� 5%      $
��Auto �6,   �� 5&      $
��Auto �6,   �� 5'      $
��Auto �6,    � ColumnDefinitions 5)      �� 5*      $
��Auto �6/   �� 5+      $��* �6/   .+�5.      �� $��	Username:��6$   $��16(�65   $��Center=�5/   "   $��0,0,10,0q�6=   �� 50      -   5        $��txtUsername��50   "   $	��200��65   $��35��6A   $��1��6M   $��Center=�51   !   $��5q�6C   $��Enter username��52   !   �� 54      $��	Password:��6$   $��16(�65   $��1��6C   $��Center=�55   "   $��	0,10,10,0q�6=   G� 56      -   5        $��txtPassword��56   &   $	��200��69   $��35��6E   $��1��6Q   $��1��6a   $��Center=�57   $   $��5q�6F   $��0,10,0,0q�6R   �� 59      -   5        $��btnLogin��59   !   $��Login��61   $	��120��6A   $��35��6M   $��2��6Y   $��1��6f   ���#1976D2
�������$��0,20,0,0q�5:   I   5;   !   5<      5=      5>      �� 5A      $��1��6   
�������$ 5��65   $ 20q�6F   $��0,0,0,20q�6S   ._�5B      �� .+�5C      �� $��New to Our Bank?��6    $��20(�68   $
��Bold"�6F   $��0,0,0,20q�6X   �� 5D      -   5        $��btnCreateAccount��5D      $��Create New Account��65   $	��200��6R   $��35��6^   ���#4CAF50
�������5F      5G      5H      �� 5K      $��2��6   
�������$ 5��65   $ 20q�6F   ._�5L      �� -   5        $��
txtMessage��5L      $
��Wrap=�6.   $��Center=�5M      $��Center=�67   $��14(�5N      5O      5P      5Q      5R      