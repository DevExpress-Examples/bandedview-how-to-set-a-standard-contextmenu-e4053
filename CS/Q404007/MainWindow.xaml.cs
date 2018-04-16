using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using System.Windows.Interactivity;

namespace Q404007 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = TestDataList.Create();
        }
    }

    public class TableViewContextMenuAdapter : Behavior<TableView> {
        public static readonly DependencyProperty ContextMenuProperty =
            DependencyProperty.Register("ContextMenu", typeof(ContextMenu), typeof(TableViewContextMenuAdapter),
            new PropertyMetadata(null));
        public ContextMenu ContextMenu {
            get { return (ContextMenu)GetValue(ContextMenuProperty); }
            set { SetValue(ContextMenuProperty, value); }
        }
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.ContextMenuOpening += new ContextMenuEventHandler(AssociatedObject_ContextMenuOpening);
        }
        protected override void OnDetaching() {
            AssociatedObject.ContextMenuOpening -= new ContextMenuEventHandler(AssociatedObject_ContextMenuOpening);
            base.OnDetaching();
        }
        void AssociatedObject_ContextMenuOpening(object sender, ContextMenuEventArgs e) {
            e.Handled = true;
            ContextMenu.IsOpen = true;
        }
    }
	public class TestDataList : List<TestDataItem> {
        public static TestDataList Create() {
            TestDataList res = new TestDataList();
            for(int i = 0; i < 10; i++) {
                TestDataItem item = new TestDataItem();
                item.ID = i;
                item.Value = "A";
                res.Add(item);
            }
            for(int i = 0; i < 10; i++) {
                TestDataItem item = new TestDataItem();
                item.ID = i;
                item.Value = "B";
                res.Add(item);
            }
            return res;
        }
    }
    public class TestDataItem {
        public int ID { get; set; }
        public string Value { get; set; }
    }
}
