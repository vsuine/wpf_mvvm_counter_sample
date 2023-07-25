using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sample.Model;

namespace Sample.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public RelayCommand IncrementCommand { get; }
        public RelayCommand DecrementCommand { get; }
        public event PropertyChangedEventHandler? PropertyChanged;
        private ICounterModel _counterModel;

        public MainWindowViewModel(ICounterModel counterModel)
        {
            // 注入されたICounterModelを保持し、それを使用する
            this._counterModel = counterModel;
            // 更新通知を受け取るメソッドを登録する
            this._counterModel.PropertyChanged += Counter_PropertyChanged;
            // 各コマンドをモデルの動作を与えて初期化する
            this.IncrementCommand = new RelayCommand(this._counterModel.Increment);
            this.DecrementCommand = new RelayCommand(this._counterModel.Decrement);
        }

        public int Count
        {
            // Modelが値を保持しているため、そのままViewに渡す。
            get { return _counterModel.Count; }
        }

        /// <summary>
        /// Modelの更新通知を受け取った際の動作
        /// </summary>
        private void Counter_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Countが更新されたという通知である場合にViewに更新通知する
            if (e.PropertyName == nameof(Count))
            {
                this.OnPropertyChanged(nameof(Count));
            }
        }
        /// <summary>
        /// Viewに更新を通知するメソッド
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}