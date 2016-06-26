using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Notes.Services;
using Notes.Models;

namespace Notes.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IStorageService storageService;

        public SettingsViewModel(IStorageService storageService, INavigationService navigationService)
        {
            this._navigationService = navigationService;
            this.storageService = storageService;
            Load();
        }

        public int NumberOfNotes { get; set; } = 2;
        public bool IsSortAscending { get; set; } = true;
        public string TenantId { get; set; }


        public void Save()
        {
            storageService.Write(nameof(NumberOfNotes), NumberOfNotes);
            storageService.Write(nameof(IsSortAscending), IsSortAscending);
            storageService.Write(nameof(TenantId), TenantId);
        }

        public void Load()
        {
            NumberOfNotes = storageService.Read<int>(nameof(NumberOfNotes), 2);
            IsSortAscending = storageService.Read<bool>(nameof(IsSortAscending), true);
            TenantId = storageService.Read<String>(nameof(TenantId), "S1510237044");
        }
    }
}
