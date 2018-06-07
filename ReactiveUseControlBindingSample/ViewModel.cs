using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace ReactiveUseControlBindingSample
{
    public class ViewModel : ReactiveObject
    {
        private List<BigItem> _items;
        private BigItem _selectedItem;

        public ViewModel()
        {
            Items = Enumerable.Range(0, 10).Select(x => new BigItem(){Item = new Item() {Name = "Name " + x, Email = x + "@gmail.com"}}).ToList();
        }

        public BigItem SelectedItem
        {
            get { return _selectedItem; }
            set { this.RaiseAndSetIfChanged(ref _selectedItem, value); }
        }

        public List<BigItem> Items
        {
            get { return _items; }
            set { this.RaiseAndSetIfChanged(ref _items, value); }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class BigItem
    {
        public Item Item { get; set; }
    }
}
