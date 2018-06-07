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
        private List<Item> _items;
        private Item _selectedItem;

        public ViewModel()
        {
            Items = Enumerable.Range(0, 10).Select(x => new Item() {Name = "Name " + x, Email = x + "@gmail.com"}).ToList();
        }

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set { this.RaiseAndSetIfChanged(ref _selectedItem, value); }
        }

        public List<Item> Items
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
}
