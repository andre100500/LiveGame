using Live.Classes;
using Live.Classes.AnimalsClasses;
using Live.Classes.PlantsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Live
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  

        public MainWindow()
        {
            InitializeComponent();

            Map map = new Map(10, 10); 
            LogBox.Items.Add(map.ShowMapLog());
            map.ShowMap();
            LogBox.Items.Add("First day");
            map.ShowVegetables();

            map.NextFrame();


            Console.WriteLine("Second day");
            map.ShowVegetables();
             
        } 

    }
}
