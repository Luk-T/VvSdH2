﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WPFGUI.ViewModels;
using WPFGUI.Interface;
using System.Windows.Input;
using Core;
using ApplicationShared;
using Application;
using System.Windows.Ink;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Reflection;
using System.Linq;
using System.ComponentModel;
using Attribute = Core.Attribute;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Markup;

namespace WPFGUI.ViewModels
{
    class RoomStruct : INotifyPropertyChanged
    {
        public const string Initial = "#FFFFFF";
        public const string Available = "#FF5CB85C";
        public const string Filtered = "#FFF0AD4E";
        public const string Booked = "#FFD9534F";

        public event PropertyChangedEventHandler PropertyChanged;

        private string _background;
        private string _building;
        private int _number;
        private string _title;
        private string _email;

        public string Background {
            get => _background;
            set
            {
                _background = value;
                NotifyPropertyChanged("Background");
            } 
        }

        public int RoomID { get; set; }

        public int Number {
            get => _number;
            set
            {
                _number = value;
                NotifyPropertyChanged(nameof(Number));
                NotifyPropertyChanged(nameof(RoomName));
            }
        }

        public string Building
        {
            get => _building;
            set
            {
                _building = value;
                NotifyPropertyChanged(nameof(Building));
                NotifyPropertyChanged(nameof(RoomName));
            }
        }

        public string RoomName
        {
            get => Building == null ? "" : $"{Building} {Number}";
        }

        public string Title { 
            get => _title;
            set
            {
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }

        public string Email { 
            get => _email;
            set 
            {
                _email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public RoomStruct(string background, int number, string title, string email)
        {
            Background = background;
            Number = number;
            Title = title;
            Email = email;
        }

        public RoomStruct(int number)
        {
            Background = Available;
            Number = number;
            Title = "";
            Email = "";
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class ReservationViewModel : INotifyPropertyChanged
    {
        private string _selectedBuilding;
        private int _selectedFloor;
        private string _selectedTimeSlot;
        private DateTime _selectedDate;
        private int _selectedRoomSize;

        private bool _isAirConditioningChecked;
        private bool _isComputersChecked;
        private bool _isPowerOutletsChecked;
        private bool _isPresenterChecked;

        private Dictionary<string, FloorRange> _buildingFloors;

        public string SelectedBuilding {
            get => _selectedBuilding;
            set 
            {
                if (value.Contains("Gebäude A"))
                {
                    _selectedBuilding = "A";
                }
                else if (value.Contains("Gebäude B"))
                {
                    _selectedBuilding = "B";
                }
                CheckValidFloor();
                UpdateRoomStatus();
            } 
        }

        public int SelectedFloor
        {
            get => _selectedFloor;
            set
            {
                _selectedFloor = value;
                OnPropertyChanged(nameof(SelectedFloor));
                OnPropertyChanged(nameof(GetFloor));
                UpdateRoomStatus();
            }
        }

        public string GetFloor
        {
            get => "Stockwerk: " + _selectedFloor;
        }

        public string SelectedTimeSlot
        {
            get => _selectedTimeSlot;
            set
            {
                _selectedTimeSlot = value;
            }
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                UpdateRoomStatus();
            }
        }

        public string SelectedRoomSize
        {
            get => "";
            set
            {
                switch (value)
                {
                    case "roomSize1":
                        _selectedRoomSize = 30;
                        break;
                    case "roomSize2":
                        _selectedRoomSize = 50;
                        break;
                    case "roomSize3":
                        _selectedRoomSize = 100;
                        break;
                }
                UpdateRoomStatus();
            }
        }

        public RoomStruct[] Rooms { get; set; }


        public bool IsAirConditioningChecked
        {
            get => _isAirConditioningChecked;
            set
            {
                _isAirConditioningChecked = value;
                UpdateRoomStatus();
            }
        }

        public bool IsComputersChecked
        {
            get => _isComputersChecked;
            set
            {
                _isComputersChecked = value;
                UpdateRoomStatus();
            }
        }

        public bool IsPowerOutletsChecked
        {
            get => _isPowerOutletsChecked;
            set
            {
                _isPowerOutletsChecked = value;
                UpdateRoomStatus();
            }
        }

        public bool IsPresenterChecked
        {
            get => _isPresenterChecked;
            set
            {
                _isPresenterChecked = value;
                UpdateRoomStatus();
            }
        }

        public ICommand RoomClickCommand { get; set; }
        public ICommand LandCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand IncFloor { get; }
        public ICommand DecFloor { get; }

        private readonly NavigationViewModel _navigationViewModel;
        private User user;
        private string _loginas = "Eingeloggt als, ";
        public ReservationViewModel(NavigationViewModel navigationViewModel, User newUser)
        {
            Rooms = new[] {
                new RoomStruct(100),
                new RoomStruct(101),
                new RoomStruct(102),
                new RoomStruct(103),
                new RoomStruct(104),
                new RoomStruct(105),
                new RoomStruct(106),
                new RoomStruct(107),
                new RoomStruct(108),
                new RoomStruct(109),
                new RoomStruct(110),
                new RoomStruct(111),
                new RoomStruct(112),
                new RoomStruct(113),
            };

            // Hardcode floors of the buildings
            _buildingFloors = new Dictionary<string, FloorRange>();
            _buildingFloors.Add("A", new FloorRange(1, 3));
            _buildingFloors.Add("B", new FloorRange(1, 1));

            _navigationViewModel = navigationViewModel;
            _selectedBuilding = "A";
            _selectedFloor = 1;
            user = newUser;

            UpdateRoomStatus();
            RoomClickCommand = new BaseCommand(RoomClick);
            LandCommand = new BaseCommand(OpenLand);
            LoginCommand = new BaseCommand(OpenLogin);
            IncFloor = new BaseCommand(TryIncFloor);
            DecFloor = new BaseCommand(TryDecFloor);

            SelectedDate = DateTime.Now;
        }

        private void TryIncFloor(object _)
        {
            SelectedFloor++;
            CheckValidFloor();
        }

        private void TryDecFloor(object _)
        {
            SelectedFloor--;
            CheckValidFloor();
        }

        /// <summary>
        /// Checks if the selected floor is set to a proper value.
        /// Proper value means that it is in the expected FloorRange for that Building
        /// If it is above or below the range, the value will be set to the nearest valid value.
        /// </summary>
        public void CheckValidFloor()
        {
            Debug.Assert(_buildingFloors.ContainsKey(SelectedBuilding));

            var floorRange = _buildingFloors[SelectedBuilding];
            if (SelectedFloor > floorRange.MaxFloor)
            {
                SelectedFloor = floorRange.MaxFloor;
            }
            else if (SelectedFloor < floorRange.MinFloor)
            {
                SelectedFloor = floorRange.MinFloor;
            }
        }

        private void OpenLand(object obj)
        {
            _navigationViewModel.SelectedViewModel = new LandingPageViewModel(_navigationViewModel, user);
        }

        private async void OpenLogin(object obj)
        {
            IUser _user = new UserController();
            var logout = await _user.Logout(user.Username);
            if (logout)
            {
                string info = "Sie wurden erfolgreich Ausgeloggt.";
                _navigationViewModel.SelectedViewModel = new LoginViewModel(_navigationViewModel, info);

                // close logoutThread
                AutoLogOff.GetToken.Cancel();
            }
        }

        private async void RoomClick(object obj)
        {
            if(obj is string s && int.TryParse(s, out int index))
            {
                var clickedRoom = Rooms[index];
                Attribute attr = new Attribute
                {
                    AirConditioning = _isAirConditioningChecked,
                    Computers = _isComputersChecked,
                    PowerOutlets = _isPowerOutletsChecked,
                    Presenter = _isPresenterChecked
                };
                var controller = new BookingController();
                using var context = new ReservationContext();
                var room = context.Rooms.Where(x => x.RoomNr == clickedRoom.Number && x.Building == clickedRoom.Building).FirstOrDefault();
                
                MessageBoxResult result = MessageBox.Show("Stimmt Ihre Resservierung?" + " Raum: " + clickedRoom.Number + " Gebäude: " + SelectedBuilding + " Datum: " + SelectedDate + " Slot: " + SelectedTimeSlot + ".", "Info", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (await controller.CreateReservation(room, SelectedDate, 0, user))
                        {
                            MessageBox.Show("Reservierung erfolgreich.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Reservierung war nicht erfolgreich. Versuchen Sie es nochmal.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        public string LoginAs
        {
            get => _loginas + user.Username;
        }

        private async void UpdateRoomStatus()
        {
            IRoom _room = new RoomController();
            List<Room> rooms = await _room.GetCurrentStatusForFloor(_selectedBuilding, _selectedFloor);

            Attribute attr = new Attribute
            {
                AirConditioning = _isAirConditioningChecked,
                Computers = _isComputersChecked,
                PowerOutlets = _isPowerOutletsChecked,
                Presenter = _isPresenterChecked
            };

            List<Room> filteredRooms = await _room.Filter(rooms, _selectedRoomSize, attr);

            for (int i = 0; i < Rooms.Length; i++)
            {
                if (i >= rooms.Count)
                {
                    // Floor has not enough rooms
                    Rooms[i].Background = RoomStruct.Initial;
                    Rooms[i].RoomID = 0;
                    Rooms[i].Building = null;
                    Rooms[i].Number = 0;
                    Rooms[i].Email = "";
                    Rooms[i].Title = "";
                    continue;
                }

                Room r = rooms[i];
                Rooms[i].Building = _selectedBuilding;
                Rooms[i].RoomID = r.RoomId;
                Rooms[i].Number = r.RoomNr;
                if (!filteredRooms.Contains(r))
                {
                    Rooms[i].Background = RoomStruct.Filtered;
                }
                else
                {
                    Rooms[i].Background = RoomStruct.Available;
                }

                if (SelectedTimeSlot != null && SelectedDate != null)
                {
                    DateTime timestamp = SelectedDate;

                    TimeSpan ts;
                    switch (SelectedTimeSlot)
                    {
                        case "slot1":
                            ts = new TimeSpan(8, 0, 0);
                            timestamp = timestamp.Date + ts;
                            break;
                        case "slot2":
                            ts = new TimeSpan(9, 45, 0);
                            timestamp = timestamp.Date + ts;
                            break;
                        case "slot3":
                            ts = new TimeSpan(11, 35, 0);
                            timestamp = timestamp.Date + ts;
                            break;
                        case "slot4":
                            ts = new TimeSpan(14, 0, 0);
                            timestamp = timestamp.Date + ts;
                            break;
                        case "slot5":
                            ts = new TimeSpan(15, 45, 0);
                            timestamp = timestamp.Date + ts;
                            break;
                    }

                    (string Username, string RightsName) = await _room.GetReservationForRoom(r, timestamp);

                    if (Username.Length > 0)
                    {
                        Rooms[i].Background = RoomStruct.Booked;
                        Rooms[i].Email = Username;
                        Rooms[i].Title = RightsName;
                    }
                    else
                    {
                        Rooms[i].Email = "";
                        Rooms[i].Title = "";
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    struct FloorRange
    {
        public FloorRange(int minFloor, int maxFloor)
        {
            MinFloor = minFloor;
            MaxFloor = maxFloor;
        }

        public int MinFloor { get; }
        public int MaxFloor { get; }
    }
}
