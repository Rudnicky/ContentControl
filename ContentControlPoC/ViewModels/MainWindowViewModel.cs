using ContentControlPoC.Interfaces;

namespace ContentControlPoC
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private readonly IClockManager _clockManager;
        private int _counter = 0;
        #endregion

        #region Properties
        private int _currentDataTemplate;
        public int CurrentDataTemplate
        {
            get { return _currentDataTemplate; }
            set
            {
                if (_currentDataTemplate != value)
                {
                    _currentDataTemplate = value;
                    NotifyPropertyChanged(nameof(CurrentDataTemplate));
                }
            }
        }
        #endregion

        #region Ctor
        public MainWindowViewModel(IClockManager clockManager)
        {
            this._clockManager = clockManager;

            Setup();
        }
        #endregion

        #region Private Methods
        private void Setup()
        {
            if (_clockManager != null)
            {
                _clockManager.OnTimeEllapsed += ClockManager_OnTimeEllapsed;
                _clockManager.CallEvery(1500);
                _clockManager.Start();
            }
        }

        private void ClockManager_OnTimeEllapsed(object sender, System.EventArgs e)
        {
            if (_counter <= 3)
                _counter++;

            switch (_counter)
            {
                case 1:
                    CurrentDataTemplate = _counter;
                    break;
                case 2:
                    CurrentDataTemplate = _counter;
                    break;
                case 3:
                    CurrentDataTemplate = _counter;
                    break;
                default:
                    break;
            }

            if (_counter == 3)
                _counter = 0;
        }

        public void Dispose()
        {
            if (_clockManager != null)
            {
                _clockManager.OnTimeEllapsed -= ClockManager_OnTimeEllapsed;
                _clockManager.Dispose();
            }
        }
        #endregion
    }
}
