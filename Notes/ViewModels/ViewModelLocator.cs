using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Notes.Services;

namespace Notes.ViewModels
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            // ServiceLocator makes it possible to exchange the SimpleIoc to another Funktion 
            // in the future and saves time and work if we want to exchange it
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CreateViewModel>();
            SimpleIoc.Default.Register<ReadViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<EditViewModel>();

            // Implemting the DataService and StorageService to every viewmodel as dependency injection
            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<IStorageService, StorageService>();
        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();
        public CreateViewModel CreateViewModel => ServiceLocator.Current.GetInstance<CreateViewModel>();
        public ReadViewModel ReadViewModel => ServiceLocator.Current.GetInstance<ReadViewModel>();
        public SearchViewModel SearchViewModel => ServiceLocator.Current.GetInstance<SearchViewModel>();
        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();
        public EditViewModel EditViewModel => ServiceLocator.Current.GetInstance<EditViewModel>();

    }
}
