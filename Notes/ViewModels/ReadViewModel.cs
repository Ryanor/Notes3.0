using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Notes.Models;
using Notes.Services;
using Notes.Views;

namespace Notes.ViewModels
{
    public class ReadViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IDataService dataService;
        private readonly SettingsViewModel settings;

        

        public ObservableCollection<Note> ReadList { get; set; }

        public ReadViewModel(IDataService _dataService, SettingsViewModel settings, INavigationService navigationService)
        {
            _navigationService = navigationService;
            this.dataService = _dataService;
            this.settings = settings;
        }

        public async void LoadList()
        {
            var getnotes = await dataService.GetAllNotes();

            getnotes = (settings.IsSortAscending) ? getnotes.OrderBy(n => n.Date).Take(settings.NumberOfNotes)
                                                : getnotes.OrderByDescending(n => n.Date).Take(settings.NumberOfNotes);

            ReadList = new ObservableCollection<Note>(getnotes);
        }

        public Note SelectedNote { get; set; }
        public bool IsNoteSelected => SelectedNote != null;

        public void NavigateToPage6()
        {
            _navigationService.NavigateTo("EditNote",SelectedNote);
        }

        public async void DeleteNote()
        {

            DialogService dialog = new DialogService();
            await dialog.ShowMessage("Do you really want to delete the selected note?", "Delete selected note!", "YES, delete", "NO, let me return",
                async confirmed =>
                {
                    if (confirmed)
                    {
                        await dataService.DeleteNote(SelectedNote);
                    }

                });
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}
