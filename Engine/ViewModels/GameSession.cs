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
                GivePlayerObjectiveAtLocation();
                GetMonsterAtLocation();
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
        public Weapon CurrentWeapon { get; set; }
        public bool HasMonster => CurrentMonster != null;

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
                RaiseMessage($"Your attack missed the {CurrentMonster.Name}!");
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
                        RaiseMessage($"The {CurrentMonster.Name}'s attack missed you!");
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
    }
}
