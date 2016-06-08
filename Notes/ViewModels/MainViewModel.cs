
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Views;

using Notes.Models;

namespace Notes.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Views;
    using GalaSoft.MvvmLight.Command;

    public class MainViewModel : ViewModelBase
{
        private readonly NavigationService _navigationService;
        public ObservableCollection<Note> AllNotes { get; }
        public IEnumerable<Note> ReadList => AllNotes.Take((int)NumberOfNotes);

        public double NumberOfNotes { get; set; }

        public MainViewModel()
        {
            NumberOfNotes = 3;
            _navigationService = new NavigationService();
            _navigationService.Configure("CreateNote", typeof(CreateNote));
            _navigationService.Configure("ReadNote", typeof(ReadNote));
            _navigationService.Configure("SearchNotes", typeof(SearchNotes));
            _navigationService.Configure("Settings", typeof(Settings));

            Note newNote = new Note("Short Lorem","Lorem Isum Kauderwelsch, blabla blabla", DateTime.Now);

            AllNotes = new ObservableCollection<Note>()
            {
                 new Note("Hallo Message","Halli Hallo, ich bin eine kleine Nachricht!", DateTime.Now),
                 new Note("Hallo","asdfjklö,asdfjklö",DateTime.Now),
                 new Note("Hoi","jkadjkgjakdjgkajgkjdfj",DateTime.Now),
                newNote
            };
        }

        // Moved into CreateViewModel
       /* public string NewTextTitle { get; set; }
        public string NewTextNote { get; set; }*/

        /*public void SaveNewNote()
        {
            if ( !String.IsNullOrEmpty(NewTextTitle))
            {
                AllNotes.Add(new Note(NewTextTitle, NewTextNote, DateTime.Now));
                _navigationService.GoBack();
                NewTextTitle = String.Empty;
                NewTextNote = String.Empty;
            }
        }

        public void CancelNewNote()
        {
            if (String.IsNullOrEmpty(NewTextNote))
            {

             _navigationService.GoBack();
            }
            else
            {
                DialogService dialog = new DialogService();
                dialog.ShowMessage("Your note is not saved, Cancel without saving?","Note not saved!","Quit anyway","Let me return",
                    confirmed =>
                    {
                        if (confirmed)
                        {
                            NewTextTitle = String.Empty;
                            NewTextNote = String.Empty;
                            _navigationService.GoBack();
                        }

                    });
            } 
        }*/

        public void NavigateToPage2()
        {
            _navigationService.NavigateTo("CreateNote");
        }

        public void NavigateToPage3()
        {
            _navigationService.NavigateTo("ReadNote");
        }

        public void NavigateToPage4()
        {
            _navigationService.NavigateTo("SearchNotes");
        }

        public void NavigateToPage5()
        {
            _navigationService.NavigateTo("Settings");
        }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }

        
}
}
