using Shouldly;
using System;
using Vend2000;
using Xunit;

namespace Vend2000Tests
{
    public class CoinStorageTests
    {
        private CoinStorage sut;

        public CoinStorageTests()
        {
            sut = new CoinStorage();
        }

        [Fact]
        public void Add_Once_ShouldAddCoin()
        {
            sut.Add(new GoldCoin());

            sut.CoinCount.ShouldBe(1);
        }

        [Fact]
        public void Add_Twice_ShouldAddTwoCoin()
        {
            sut.Add(new GoldCoin());
            sut.Add(new GoldCoin());

            sut.CoinCount.ShouldBe(2);
        }

        [Fact]
        public void Add_WhenFull_ShouldNotAddCoin()
        {
            for (int c = 0; c < 100; c++)
            {
                sut.Add(new GoldCoin());
            }

            sut.Add(new GoldCoin());

            sut.CoinCount.ShouldBe(100);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(25)]
        [InlineData(100)]
        public void Empty_WhenNotEmpty_ShouldEmptyStorage(int coinsInStorage)
        {
            for (int c = 0; c < coinsInStorage; c++)
            {
                sut.Add(new GoldCoin());
            }

            var emptiedCoins = sut.Empty();

            emptiedCoins.Count.ShouldBe(coinsInStorage);
            sut.CoinCount.ShouldBe(0);
        }
    }
}
