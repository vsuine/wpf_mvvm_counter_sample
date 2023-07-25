using System.ComponentModel;

namespace Sample.Model
{
    /// <summary>
    /// カウントアップとカウントダウンを実行するロジックを実装するクラス
    /// </summary>
    internal class CounterModel : ICounterModel
    {
        private int _count;
        public event PropertyChangedEventHandler? PropertyChanged;

        public CounterModel()
        {
            this._count = 0;
        }

        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
                // 更新したことをViewModelに通知する
                OnPropertyChanged(nameof(Count));
            }
        }

        public void Increment()
        {
            // カウントアップし、更新が通知される
            this.Count++;
        }

        public void Decrement()
        {
            // カウントダウンし、更新が通知される
            this.Count--;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}