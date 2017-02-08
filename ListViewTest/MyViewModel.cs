using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewTest
{
    public class MyViewModel
    {
        public MyViewModel()
        {
            CreateList();
            ListItems.CollectionChanged += Items_CollectionChanged;
        }

        private void CreateList()
        {
            ListItems.Add(new MyModelBase() { Name = "Prashant" });
            ListItems.Add(new MyModelBase() { Name = "Ved" });
            ListItems.Add(new MyModelBase() { Name = "Niraj" });
            ListItems.Add(new MyModelBase() { Name = "Sanjeev" });
            ListItems.Add(new MyModelBase() { Name = "Rahul" });
            ListItems.Add(new MyModelBase() { Name = "Navneet" });
            ListItems.Add(new MyModelBase() { Name = "Mayank" });
            ListItems.Add(new MyModelBase() { Name = "Pramod" });
            ListItems.Add(new MyModelBase() { Name = "Abhinav" });
        }

        private ObservableCollection<MyModelBase> _listItems = new ObservableCollection<MyModelBase>();
        public ObservableCollection<MyModelBase> ListItems
        {
            get { return _listItems; }
            set { _listItems = value; }
        }

        object m_ReorderItem;
        int m_ReorderIndexFrom;
        void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    m_ReorderItem = e.OldItems[0];
                    m_ReorderIndexFrom = e.OldStartingIndex;
                    break;
                case NotifyCollectionChangedAction.Add:
                    if (m_ReorderItem == null)
                        return;
                    var _ReorderIndexTo = e.NewStartingIndex;
                    HandleReorder(m_ReorderItem, m_ReorderIndexFrom, _ReorderIndexTo);
                    m_ReorderItem = null;
                    break;
            }
            Debug.WriteLine(ListItems.ToArray());
        }








        void HandleReorder(object item, int indexFrom, int indexTo)
        {
            Debug.WriteLine("Reorder: {0}, From: {1}, To: {2}", item, indexFrom, indexTo);
        }

    }
    public class MyModelBase
    {
        public string Name { get; set; }
    }
}
