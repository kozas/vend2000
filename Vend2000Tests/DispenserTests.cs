using Shouldly;
using System;
using System.Collections.Generic;
using Vend2000;
using Vend2000.Components;
using Vend2000.Interfaces;
using Vend2000.Models;
using Xunit;

namespace Vend2000Tests
{
    public class DispenserTests
    {
        private readonly SmallDispenser10Slots sut10Small;
        private readonly SmallDispenser20Slots sut20Small;
        private readonly LargeDispenser10Slots sut10Large;

        public DispenserTests()
        {
            sut10Small = new SmallDispenser10Slots();
            sut20Small = new SmallDispenser20Slots();
            sut10Large = new LargeDispenser10Slots();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        public void Add_WhenNotFull_ShouldAddProducts(int amountToAdd)
        {
            for (int i = 0; i < amountToAdd; i++)
            {
                sut10Small.Add(new GumPacket());
                sut20Small.Add(new GumPacket());
            }

            sut10Small.Quantity.ShouldBe(amountToAdd);
            sut20Small.Quantity.ShouldBe(amountToAdd);
        }

        [Fact]
        public void Add_WhenFull_ShouldNotProducts()
        {
            for (int i = 0; i < sut10Small.Capacity; i++)
            {
                sut10Small.Add(new GumPacket());
            }
            for (int i = 0; i < sut20Small.Capacity; i++)
            {
                sut20Small.Add(new GumPacket());
            }

            sut10Small.Add(new GumPacket());
            sut20Small.Add(new GumPacket());

            sut10Small.Quantity.ShouldBe(sut10Small.Capacity);
            sut20Small.Quantity.ShouldBe(sut20Small.Capacity);
        }

        [Fact]
        public void Add_SmallProductToLargeDispenser_ShouldNotAddProducts()
        {
            sut10Large.Add(new GumPacket());

            sut10Large.Quantity.ShouldBe(0);
        }

        [Fact]
        public void Add_LargeProductToSmallDispenser_ShouldNotAddProducts()
        {
            sut10Small.Add(new ChipBag());

            sut10Small.Quantity.ShouldBe(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        public void Dispense_WhenNotEmpty_ShouldDispenseProducts(int amountToDispense)
        {
            var dispensedGumFrom10 = new List<IProduct>();
            var dispensedGumFrom20 = new List<IProduct>();
            for (int i = 0; i < sut10Small.Capacity; i++)
            {
                sut10Small.Add(new GumPacket());
            }
            for (int i = 0; i < sut20Small.Capacity; i++)
            {
                sut20Small.Add(new GumPacket());
            }

            for (int i = 0; i < amountToDispense; i++)
            {
                dispensedGumFrom10.Add(sut10Small.Dispense());
            }
            for (int i = 0; i < amountToDispense; i++)
            {
                dispensedGumFrom20.Add(sut20Small.Dispense());
            }

            dispensedGumFrom10.Count.ShouldBe(amountToDispense);
            dispensedGumFrom20.Count.ShouldBe(amountToDispense);
            sut10Small.Quantity.ShouldBe(sut10Small.Capacity - amountToDispense);
            sut20Small.Quantity.ShouldBe(sut20Small.Capacity - amountToDispense);
        }

        [Fact]
        public void Dispense_WhenEmpty_ShouldNotDispenseProducts()
        {
            sut10Small.Dispense();
            sut20Small.Dispense();

            sut10Small.Quantity.ShouldBe(0);
            sut20Small.Quantity.ShouldBe(0);
        }
    }
}
