using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.Xpf.Editors.Settings;

namespace DXSample8
{
    public class AddressStateControl : ComboBoxEdit
    {
        public AddressStateControl()
        {
            StateCollection = new HashSet<AddressStateWrapper>();
            StateCollection.Add(new AddressStateWrapper());
            foreach (var adressStatus in Enum.GetValues(typeof(AddressState)).Cast<AddressState>())
            {
                StateCollection.Add(new AddressStateWrapper() { State = adressStatus });
            }
            this.ItemsSource = StateCollection;
            this.SelectedIndex = 0;
        }

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(
            "State",
            typeof(AddressState?),
            typeof(AddressStateControl),
            new FrameworkPropertyMetadata(AddressState.None, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public AddressState? SelectedState
        {
            get { return (AddressState?)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public ICollection<AddressStateWrapper> StateCollection { get; set; }

        protected override BaseEditSettings CreateEditorSettings() {
            return new AddressStateEditSettings();
        }
    }

    public class AddressStateWrapper
    {
        public AddressState? State { get; set; }
    }

    public class AddressStateWrapperConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            var statusWrapper = new AddressStateWrapper();
            if (value is AddressState?)
            {
                statusWrapper.State = (AddressState?)value;
            }
            return statusWrapper;
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            var statusWrapper = value as AddressStateWrapper;
            if (statusWrapper == null || !statusWrapper.State.HasValue)
            {
                return null;
            }
            return statusWrapper.State.Value;
        }
    }


    public class AddressStateEditSettings : ComboBoxEditSettings {

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(
            "State",
            typeof(AddressState),
            typeof(AddressStateEditSettings),
            new FrameworkPropertyMetadata(AddressState.None, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public AddressState? SelectedState {
            get { return (AddressState)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public ICollection<AddressStateWrapper> StateCollection { get; set; }


        static AddressStateEditSettings() {
            EditorSettingsProvider.Default.RegisterUserEditor2(typeof(AddressStateControl), typeof(AddressStateEditSettings), optimized => optimized ? new InplaceBaseEdit() : (IBaseEdit)new AddressStateControl(), () => new AddressStateEditSettings());
        }

        public AddressStateEditSettings() { }

        protected override void AssignToEditCore(IBaseEdit edit) {
            base.AssignToEditCore(edit);
            if (edit is AddressStateControl) {
                var editor = (AddressStateControl)edit;
                editor.SelectedState = SelectedState;
                editor.StateCollection = StateCollection;
            }
        }
    }
}