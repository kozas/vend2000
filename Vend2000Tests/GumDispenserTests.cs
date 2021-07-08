using Shouldly;
using System;
using System.Collections.Generic;
using Vend2000;
using Xunit;

namespace Vend2000Tests
{
    public class GumDispenserTests
    {
        private readonly GumDispenser10 sut10;
        private readonly GumDispenser20 sut20;

        public GumDispenserTests()
        {
            sut10 = new GumDispenser10();
            sut20 = new GumDispenser20();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        public void Add_WhenNotFull_ShouldAddGumPackets(int amountToAdd)
        {
            for (int i = 0; i < amountToAdd; i++)
            {
                sut10.Add(new GumPacket());
                sut20.Add(new GumPacket());
            }

            sut10.Quantity.ShouldBe(amountToAdd);
            sut20.Quantity.ShouldBe(amountToAdd);
        }

        [Fact]
        public void Add_WhenFull_ShouldNotAddGumPackets()
        {
            for (int i = 0; i < sut10.Capacity; i++)
            {
                sut10.Add(new GumPacket());
            }
            for (int i = 0; i < sut20.Capacity; i++)
            {
                sut20.Add(new GumPacket());
            }

            sut10.Add(new GumPacket());
            sut20.Add(new GumPacket());

            sut10.Quantity.ShouldBe(sut10.Capacity);
            sut20.Quantity.ShouldBe(sut20.Capacity);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        public void Dispense_WhenNotEmpty_ShouldDispenseGumPackets(int amountToDispense)
        {
            var dispensedGumFrom10 = new List<GumPacket>();
            var dispensedGumFrom20 = new List<GumPacket>();
            for (int i = 0; i < sut10.Capacity; i++)
            {
                sut10.Add(new GumPacket());
            }
            for (int i = 0; i < sut20.Capacity; i++)
            {
                sut20.Add(new GumPacket());
            }

            for (int i = 0; i < amountToDispense; i++)
            {
                dispensedGumFrom10.Add(sut10.Dispense());
            }
            for (int i = 0; i < amountToDispense; i++)
            {
                dispensedGumFrom20.Add(sut20.Dispense());
            }

            dispensedGumFrom10.Count.ShouldBe(amountToDispense);
            dispensedGumFrom20.Count.ShouldBe(amountToDispense);
            sut10.Quantity.ShouldBe(sut10.Capacity - amountToDispense);
            sut20.Quantity.ShouldBe(sut20.Capacity - amountToDispense);
        }

        [Fact]
        public void Dispense_WhenEmpty_ShouldNotDispenseGumPackets()
        {
            sut10.Dispense();
            sut20.Dispense();

            sut10.Quantity.ShouldBe(0);
            sut20.Quantity.ShouldBe(0);
        }
    }
}
