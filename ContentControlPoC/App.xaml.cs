using ContentControlPoC.Interfaces;
using ContentControlPoC.Utils;
using System.Windows;
using Unity;

namespace ContentControlPoC
{
    public partial class App : Application
    {
        private MainWindowViewModel _mainWindowViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            UnityContainer container = new UnityContainer();
            container.RegisterType<IClockManager, ClockManager>();

            _mainWindowViewModel = container.Resolve<MainWindowViewModel>();
            var window = new MainWindow { DataContext = _mainWindowViewModel };
            window.Show();
        }
        
        protected override void OnExit(ExitEventArgs e)
        {
            if (_mainWindowViewModel != null)
                _mainWindowViewModel.Dispose();

            base.OnExit(e);
        }
    }
}
