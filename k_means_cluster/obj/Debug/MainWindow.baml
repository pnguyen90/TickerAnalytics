   M S B A M L   `   `   `  ����  k_means_cluster     k_means_cluster.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  k-means-cluster��5   	   $	��350��6!   $	��525��6.   ��5      �� 5   
    �� ImageSource$ /Properties/k-means.png��6    j� Stretch$ UniformToFill=�6;   6V   .��5      � .+�5	   
   (  "System.Windows.Controls.DatePicker  -   5        $��date1��5	   \   $
��Left=�6   $��
63,136,0,0q�60   $	��Top=�6D   6\     5
   
   -   5        $��date2��5
   ]   $
��Left=�6   $��225,136,0,0q�60   $	��Top=�6E   6]   �� 5   
   -   5        $��Upload file��5      $
��Left=�6'   $��	63,61,0,0q�6B   $	��Top=�6U   $��75��6m   6x   �� 5   
   $
��Left=�6   $��
165,64,0,0q�6/   $
��Wrap=�6C   $3��-Upload a .csv file. Ex. AMRN, MSFT, GOOG, ...��6W   $	��Top=�6�   $
��Bold"�6�   ���	#FFFDFCFC6�   �� 5   
   -   5        $��Get Clusters��5      $
��Left=�6(   $��
63,205,0,0q�6C   $	��Top=�6W   $��86��6o   6z   �� 5   
   $��X coordinate��6   $
��Left=�6'   $��
351,85,0,0q�6B   $	��Top=�6V   �� 5   
   $��Y coordinate��6   $
��Left=�6'   $��351,137,0,0q�6B   $	��Top=�6W   �� 5   
   -   5        $��xcoor��5   �   $
��Left=�6   $��23��6-   $��351,111,0,0q�69    �� TextWrapping$
 Wrap=�6N   $��TICKER1��6b   $	��Top=�6q   $	��120��6�   6�   �� 5   
   -   5        $��ycoor��5   �   $
��Left=�6   $��23��6-   $��351,163,0,0q�69   $
 Wrap=�6N   $��TICKER2��6b   $	��Top=�6q   $	��120��6�   6�   �� 5   
   -   5        $��filepath��5   �   $
��Left=�6   $��23��6-   $��	63,85,0,0q�69   $
 Wrap=�6L   $�� ��6`   $	��Top=�6h   $	��120��6�   6�   �� 5   
   -   5        $��k_param��5   �   $
��Left=�6   $��23��6-   $��351,211,0,0q�69   $
 Wrap=�6N   $��Enter integer��6b   $	��Top=�6w   $	��120��6�   6�   �� 5   
   $��How many clusters?��6   $
��Left=�6-   $��351,185,0,0q�6H   $	��Top=�6]   5      5      