using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player : BaseClass
    {
        private int _exp;
        private int _level;
        private int _gold;
        private int _hp;
        private string _name;
        private string _job;
        public string Name
        { 
            get {  return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Job
        { 
            get {  return _job; }
            set
            {
                _job = value;
                OnPropertyChanged(nameof(Job));
            }
        }
        public int HP {
            get { return _hp; }
            set
            {
                _hp = value;
                OnPropertyChanged(nameof(HP));
            }
        }
        public int EXP
        {
            get { return _exp; }
            set
            {
                _exp = value;
                OnPropertyChanged(nameof(EXP));
            }
        }
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public ObservableCollection<GameItem> Inventory { get; set; }
        public ObservableCollection<ObjectiveStatus> Objectives { get; set; }
        public List<GameItem> Weapons => Inventory.Where(i => i is Weapon).ToList();
        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Objectives = new ObservableCollection<ObjectiveStatus>();
        }
        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);
            OnPropertyChanged(nameof(Weapons));
        }
    }
}
