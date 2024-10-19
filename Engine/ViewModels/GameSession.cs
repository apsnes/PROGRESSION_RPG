using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using Engine.EventArgs;

namespace Engine.ViewModels
{
    public class GameSession : BaseClass
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;
        public World CurrentWorld { get; set; }
        private Location _currentLocation;
        private Monsters _currentMonster;
        private Weapon _currentWeapon;
        private Food _currentItem;
        private NPC _currentNPC;
        public Player CurrentPlayer { get; set; }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationNorth));
                OnPropertyChanged(nameof(HasLocationWest));
                OnPropertyChanged(nameof(HasLocationSouth));
                OnPropertyChanged(nameof(HasLocationEast));
                CompleteObjectiveAtLocation();
                GivePlayerObjectiveAtLocation();
                GetMonsterAtLocation();
                CurrentNPC = CurrentLocation.NPCHere;
            }
        }
        public Monsters CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;
                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));
                if (CurrentMonster != null)
                {
                    RaiseMessage("");
                    string currMonster = CurrentMonster.Name;
                    if (currMonster == "Demonic Bunny of Purgatory")
                    {
                        RaiseMessage($"Looks like the Demonic Bunny is here, beware!!!");
                    }
                    else if (currMonster[0] == 'A' || currMonster[0] == 'E' || currMonster[0] == 'I' || currMonster[0] == 'O' || currMonster[0] == 'U')
                    {
                        RaiseMessage($"There's an {currMonster} here!");
                    }
                    else
                    {
                        RaiseMessage($"There's a {currMonster} here!");
                    }
                }
            }
        }
        public NPC CurrentNPC
        {
            get { return _currentNPC; }
            set
            {
                _currentNPC = value;
                OnPropertyChanged(nameof(CurrentNPC));
                OnPropertyChanged(nameof(HasNPC));
            }
        }
        public Weapon CurrentWeapon
        {
            get { return _currentWeapon;  }
            set
            {
                _currentWeapon = value;
                OnPropertyChanged(nameof(CurrentWeapon));
            }
        }
        public Food CurrentItem
        {
            get { return _currentItem; }
            set
            {
                _currentItem = value;
                OnPropertyChanged(nameof(CurrentItem));
                OnPropertyChanged(nameof(HasItem));
            }
        }
        public bool HasMonster => CurrentMonster != null;
        public bool HasNPC => CurrentNPC != null;
        public bool HasItem => CurrentItem != null;

        public bool HasLocationNorth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;

        public bool HasLocationWest => CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;

        public bool HasLocationSouth => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;

        public bool HasLocationEast => CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "Player One",
                Gold = 5000,
                EXP = 0,
                Level = 1,
                HP = 100,
                Job = "Mage"
            };
            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }
            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);
        }
        public void MoveNorth()
        {
            if (HasLocationNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }
        }
        public void MoveWest()
        {
            if (HasLocationWest)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
        }
        public void MoveSouth()
        {
            if (HasLocationSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
        }
        public void MoveEast()
        {
            if (HasLocationEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
        }
        private void GivePlayerObjectiveAtLocation()
        {
            foreach (Objective objective in CurrentLocation.ObecjtivesHere)
            {
                if (!CurrentPlayer.Objectives.Any(o => o.PlayerObjective.ID == objective.ID))
                {
                    CurrentPlayer.Objectives.Add(new ObjectiveStatus(objective));
                    RaiseMessage("");
                    RaiseMessage($"New objective obtained: {objective.Name}.");
                    RaiseMessage(objective.Description);
                    RaiseMessage("Return with:");
                    foreach (ItemQuantity itemQuantity in objective.RequiredItems)
                    {
                        if (itemQuantity.Quantity > 1)
                        {
                            RaiseMessage($"{itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}s");
                        }
                        else
                        {
                            RaiseMessage($"{itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                        }
                    }
                    RaiseMessage($"Rewards: {objective.RewardEXP} EXP, {objective.RewardGold} Gold.");
                }
            }
        }
        private void CompleteObjectiveAtLocation()
        {
            foreach (Objective objective in CurrentLocation.ObecjtivesHere)
            {
                ObjectiveStatus objectiveToComplete = CurrentPlayer.Objectives.FirstOrDefault(o => o.PlayerObjective.ID == objective.ID && !o.IsCompleted);
                if (objectiveToComplete != null)
                {
                    if (CurrentPlayer.HasTheseItems(objective.RequiredItems))
                    {
                        foreach (ItemQuantity itemQuantity in objective.RequiredItems)
                        {
                            for (int i = 0; i < itemQuantity.Quantity; i++)
                            {
                                CurrentPlayer.RemoveItemFromInventory(CurrentPlayer.Inventory.First(item => item.ItemID == itemQuantity.ItemID));
                            }
                        }
                        RaiseMessage($"You completed the objective: {objective.Name}.");
                        CurrentPlayer.EXP += objective.RewardEXP;
                        if (CurrentPlayer.EXP >= 1000)
                        {
                            CurrentPlayer.EXP = CurrentPlayer.EXP - 1000;
                            CurrentPlayer.Level += 1;
                            CurrentPlayer.HP = CurrentPlayer.Level * 100;
                            RaiseMessage($"You levelled up to level {CurrentPlayer.Level}!");
                        }
                        CurrentPlayer.Gold += objective.RewardGold;
                        foreach(ItemQuantity itemQuantity in objective.RewardItems)
                        {
                            GameItem reward = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                            CurrentPlayer.AddItemToInventory(reward);
                            RaiseMessage($"You receive a {reward.Name}.");
                        }
                        RaiseMessage($"You receive {objective.RewardEXP} EXP.");
                        RaiseMessage($"You receive {objective.RewardGold} Gold.");
                        objectiveToComplete.IsCompleted = true;
                    }
                }
            }
        }
        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
        public void AttackCurrentMonster()
        {
            if (CurrentWeapon == null)
            {
                RaiseMessage("Select your weapon to attack!");
                return;
            }
              
            int damage = RandomNumberGenerator.NumberBetween((CurrentWeapon.Power - CurrentWeapon.Power / 10), (CurrentWeapon.Power + CurrentWeapon.Power / 10));
            if (damage <= 0)
            {
                RaiseMessage($"The {CurrentMonster.Name} evaded your attack.");
            }
            else
            {
                CurrentMonster.HP -= damage;
                if (CurrentWeapon.Name == "Demonic Glowstorm Stave of Purgatory")
                {
                    RaiseMessage($"Power surges from deep within the {CurrentWeapon.Name}. The wind swirls around you and the sky goes dark. With fire burning in your eyes, a firey eruption consumes the {CurrentMonster.Name}. You did {damage} damage.");
                }
                else
                {
                    RaiseMessage($"You conjur up a spell and attack the {CurrentMonster.Name} with the {CurrentWeapon.Name}. You did {damage} damage!");
                }
                if (CurrentMonster.HP <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"You defeated the {CurrentMonster.Name}!");
                    CurrentPlayer.EXP += CurrentMonster.RewardEXP;
                    if (CurrentPlayer.EXP >= 1000)
                    {
                        CurrentPlayer.EXP = CurrentPlayer.EXP - 1000;
                        CurrentPlayer.Level += 1;
                        CurrentPlayer.HP = CurrentPlayer.Level * 100;
                        RaiseMessage($"You levelled up to level {CurrentPlayer.Level}!");
                    }
                    CurrentPlayer.Gold += CurrentMonster.RewardGold;
                    RaiseMessage($"You received {CurrentMonster.RewardEXP} EXP and {CurrentMonster.RewardGold} gold.");
                    foreach (ItemQuantity itemQuantity in CurrentMonster.Inventory)
                    {
                        GameItem item = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                        CurrentPlayer.Inventory.Add(item);
                        if (itemQuantity.Quantity > 1)
                        {
                            RaiseMessage($"You received {itemQuantity.Quantity} {item.Name}'s.");
                        }
                        else
                        {
                            RaiseMessage($"You received a {item.Name}.");
                        }
                    }
                    CurrentMonster = null;
                }
                else
                {
                    int playerDmg = RandomNumberGenerator.NumberBetween((CurrentMonster.DamagePower - CurrentMonster.DamagePower / 10) - CurrentWeapon.Defence, (CurrentMonster.DamagePower + CurrentMonster.DamagePower / 10) - CurrentWeapon.Defence);
                    if (playerDmg <= 0)
                    {
                        RaiseMessage($"You evaded the {CurrentMonster.Name}s attack!");
                    }
                    else
                    {
                        CurrentPlayer.HP -= playerDmg;
                        RaiseMessage($"The {CurrentMonster.Name} attacks you and deals {playerDmg} damage.");
                    }
                    if (CurrentPlayer.HP <= 0)
                    {
                        RaiseMessage("");
                        RaiseMessage($"The {CurrentMonster.Name} killed you.");
                        RaiseMessage("Game Over.");
                        CurrentLocation = CurrentWorld.LocationAt(0, 0);
                        CurrentPlayer.HP = CurrentPlayer.Level * 100;
                    }
                }
            }
        }
        public void UseItem()
        {
            if (CurrentItem != null)
            {               
                CurrentPlayer.HP = Math.Min(CurrentPlayer.HP += CurrentItem.Vitality, CurrentPlayer.Level * 100);
                CurrentPlayer.RemoveItemFromInventory(CurrentItem);
                CurrentItem = null;
            }
        }
    }
}
