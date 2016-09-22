using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Editors;

namespace DXSample8
{
    public class AddressStateControl : ComboBoxEdit
    {
        public AddressStateControl()
        {
            StateCollection = new HashSet<AddressState>();
            foreach (var adressStatus in Enum.GetValues(typeof(AddressState)).Cast<AddressState>())
            {
                StateCollection.Add(adressStatus);
            }
            this.ItemsSource = StateCollection;
            this.State = AddressState.None;
        }

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(
            "State",
            typeof(AddressState),
            typeof(AddressStateControl),
            new FrameworkPropertyMetadata(AddressState.None, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public AddressState State
        {
            get { return (AddressState)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public ICollection<AddressState> StateCollection { get; set; }
    }
}