using System.ComponentModel;

namespace Sample.Model
{
    /// <summary>
    /// カウントアップとカウントダウンを実行するロジックを実装するクラスを示すインターフェース
    /// </summary>
    public interface ICounterModel : INotifyPropertyChanged
    {
        public int Count { get; set; }
        public void Increment();
        public void Decrement();
    }
}