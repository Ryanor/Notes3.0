using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;

namespace Notes.ViewModels
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CreateViewModel>();
            SimpleIoc.Default.Register<ReadViewModel>();
        }

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
        public CreateViewModel CreateViewModel => SimpleIoc.Default.GetInstance<CreateViewModel>();
        public ReadViewModel ReadViewModel => SimpleIoc.Default.GetInstance<ReadViewModel>();
    }
}
