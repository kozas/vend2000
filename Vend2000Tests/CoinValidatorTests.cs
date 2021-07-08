using Shouldly;
using System;
using System.Collections.Generic;
using Vend2000;
using Xunit;

namespace Vend2000Tests
{
    public class CoinValidatorTests
    {
        private readonly CoinValidator sut;

        public CoinValidatorTests()
        {
            sut = new CoinValidator();
        }

        [Fact]
        public void DetermineCoinType_WhenBronzeCoinPassed_ShouldReturnCorrectCoinType()
        {
            var coinType = sut.DetermineCoinType(new BronzeCoin());

            coinType.ShouldBe(CoinType.Bronze);
        }

        [Fact]
        public void DetermineCoinType_WhenSilverCoinPassed_ShouldReturnCorrectCoinType()
        {
            var coinType = sut.DetermineCoinType(new SilverCoin());

            coinType.ShouldBe(CoinType.Silver);
        }

        [Fact]
        public void DetermineCoinType_WhenGoldCoinPassed_ShouldReturnCorrectCoinType()
        {
            var coinType = sut.DetermineCoinType(new GoldCoin());

            coinType.ShouldBe(CoinType.Gold);
        }

        [Fact]
        public void DetermineCoinType_WhenUnknownCoinPassed_ShouldReturnCorrectCoinType()
        {
            var coinType = sut.DetermineCoinType(new FakeCoin());

            coinType.ShouldBe(CoinType.Unknown);
        }
    }
}
