using Sample.Model;
using Sample.ViewModel;
using Moq;

namespace MvvmSample.Test.ViewModel
{
    /// <summary>
    /// MainWindowViewModelのテスト
    /// 実践のテストではもっと網羅する
    /// </summary>
    public class MainWindowViewModelTest
    {
        [Fact(DisplayName = "ViewModelのIncrementCommandテスト")]
        public void TestViewModelIncrement()
        {
            // Moqライブラリを使用することで、任意の動作をするMockクラスを用意できる
            // ここではICounterModelを模倣したMockを用意し
            // ViewModelに渡すことでViewModelの単体テストを実現する
            var mock = new Mock<ICounterModel>();
            ICounterModel mockCounterModel = mock.Object;
            int counter = 0;
            mock.SetupGet(m => m.Count).Returns(counter);
            mock.Setup(m => m.Increment()).Callback(() =>
            {
                counter++;
            });
            mock.SetupGet(m => m.Count).Returns(() => counter);
            MainWindowViewModel viewModel = new MainWindowViewModel(mockCounterModel);
            viewModel.IncrementCommand.Execute(null);
            Assert.Equal(1, viewModel.Count);
        }

        [Fact(DisplayName = "ViewModelのDecrementCommandテスト")]
        public void TestViewModelDecrement()
        {
            var mock = new Mock<ICounterModel>();
            ICounterModel mockCounterModel = mock.Object;
            int counter = 0;
            mock.SetupGet(m => m.Count).Returns(counter);
            mock.Setup(m => m.Decrement()).Callback(() =>
            {
                counter--;
            });
            mock.SetupGet(m => m.Count).Returns(() => counter);
            MainWindowViewModel viewModel = new MainWindowViewModel(mockCounterModel);
            viewModel.DecrementCommand.Execute(null);
            Assert.Equal(-1, viewModel.Count);
        }
    }
}
