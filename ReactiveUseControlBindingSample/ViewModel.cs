using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ReactiveUI;
using ReactiveUseControlBindingSample.Annotations;

namespace ReactiveUseControlBindingSample
{
    public class ViewModel : ReactiveObject
    {
        private List<BigItem> _items;
        private BigItem _selectedItem;
        private ItemHolder _holder;
        private ItemValidation _validation;

        public ViewModel()
        {
            var rand = new Random();
            Items = Enumerable.Range(0, 10).Select(x => new BigItem(){Item = new Item() {Name = "Name " + x, Email = x + "@gmail.com", Weight = rand.NextDouble() * 5 - 2}}).ToList();

            Holder = new ItemHolder();

            this.WhenAnyValue(x => x.SelectedItem).Subscribe(x => Holder.Item = x);

            this.WhenAnyValue(x => x.SelectedItem).Subscribe(item =>
            {
                Validation = item != null ? new ItemValidation() {Weight = item.Item.Weight} : null;
            });
        }

        public ItemHolder Holder
        {
            get { return _holder; }
            set { this.RaiseAndSetIfChanged(ref _holder, value); }
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

        public ItemValidation Validation
        {
            get { return _validation; }
            private set { this.RaiseAndSetIfChanged(ref _validation, value); }
        }
    }


    public class ItemHolder : INotifyPropertyChanged
    {
        private BigItem _item;

        public BigItem Item
        {
            get { return _item; }
            set { _item = value; OnPropertyChanged();}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public double Weight { get; set; }
    }

    public class BigItem
    {
        public Item Item { get; set; }
    }
}
