using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace todolist.ViewModel
{

    internal class ViewModelList : INotifyPropertyChanged
    {
        string name = "";

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Add { get; set; }
        public ICommand Delete { get; set; }
        public ObservableCollection<ItemOfList> Items { get; set; } = new();


        public class ItemOfList
        {
            public string Name { get; set; } = "";
            public ItemOfList(string name)
            {
                Name = name;
            }
        }

        public ViewModelList()
        {
            Add = new Command(() =>
            {
                if (Name != "")
                    Items.Add(new ItemOfList(Name));
                Name = "";
            });

            Delete = new Command((object? args) =>
            {
                if (args is ItemOfList item)
                    Items.Remove(item);
            });
        }



        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }

}
