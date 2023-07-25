using System.ComponentModel;
using Sample.Model;

namespace MvvmSample.Test.Model
{
    /// <summary>
    /// CounterModelの単体テスト
    /// </summary>
    public class CounterModelTest
    {
        // InlineDataで引数のように値を与えて複数のテストケースを実行できる
        // 実践ではもっと網羅したテストを用意する
        [Theory(DisplayName = "インクリメントのテスト")]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(100000000, 100000000)]
        public void IncrementTest(int incrementCount, int expectedValue)
        {
            ICounterModel counterModel = new CounterModel();
            for (int i = 0; i < incrementCount; i++)
            {
                counterModel.Increment();
            }
            Assert.True(counterModel.Count == expectedValue);
        }

        [Theory(DisplayName = "デクリメントのテスト")]
        [InlineData(0, 0)]
        [InlineData(1, -1)]
        [InlineData(100, -100)]
        [InlineData(100000000, -100000000)]
        public void DecrementTest(int incrementCount, int expectedValue)
        {
            ICounterModel counterModel = new CounterModel();
            for (int i = 0; i < incrementCount; i++)
            {
                counterModel.Decrement();
            }
            Assert.True(counterModel.Count == expectedValue);
        }

        [Fact(DisplayName = "インクリメントで通知が来るかどうかテスト")]
        public void IncrementNotifyTest()
        {
            bool isCalledPropertyChanged = false;
            ICounterModel counterModel = new CounterModel();
            void Counter_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                isCalledPropertyChanged = true;
                if (e.PropertyName == "Count")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.False(true);
                }
            }
            counterModel.PropertyChanged += Counter_PropertyChanged;
            counterModel.Increment();
            Assert.True(isCalledPropertyChanged);
        }

        [Fact(DisplayName = "デクリメントで通知が来るかどうかテスト")]
        public void DecrementNotifyTest()
        {
            bool isCalledPropertyChanged = false;
            ICounterModel counterModel = new CounterModel();
            void Counter_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                isCalledPropertyChanged = true;
                if (e.PropertyName == "Count")
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.False(true);
                }
            }
            counterModel.PropertyChanged += Counter_PropertyChanged;
            counterModel.Decrement();
            Assert.True(isCalledPropertyChanged);
        }
    }
}
