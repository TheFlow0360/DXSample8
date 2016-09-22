using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace DXSample8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<RowObject>()
            {
                new RowObject()
                {
                    Id = 0,
                    Name = "Name 0",
                    State = (Int16)AddressState.Normal
                },
                new RowObject()
                {
                    Id = 1,
                    Name = "Name 1",
                    State = (Int16)AddressState.None
                },
                new RowObject()
                {
                    Id = 2,
                    Name = "Name 2",
                    State = (Int16)AddressState.Normal
                },
                new RowObject()
                {
                    Id = 3,
                    Name = "Name 3",
                    State = (Int16)AddressState.Major
                },
                new RowObject()
                {
                    Id = 4,
                    Name = "Name 4",
                    State = (Int16)AddressState.Blocked
                },
                new RowObject()
                {
                    Id = 5,
                    Name = "Name 5",
                    State = (Int16)AddressState.Minor
                },
            };
            Grid.ItemsSource = Items;
        }

        public ObservableCollection<RowObject> Items;
    }
}
