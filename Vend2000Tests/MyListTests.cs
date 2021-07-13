using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Vend2000;
using Xunit;

namespace Vend2000Tests
{
    public class MyListTests
    {
        private readonly MyList<string> sut;
        private readonly MyList<int> sutInt;

        public MyListTests()
        {
            sut = new MyList<string>();
            sutInt = new MyList<int>();
        }

        [Fact]
        public void Add_String_ShouldAddString()
        {
            sut.Add("apple");
            sut.Add("banana");
            sut.Add("grape");
            sutInt.Add(1);
            sutInt.Add(2);

            sut.Count.ShouldBe(3);
            sutInt.Count.ShouldBe(2);
        }

        [Fact]
        public void AddRange_String_ShouldAddStrings()
        {
            var items = new string[]{"apple", "banana", "grape"};

            sut.AddRange(items);

            sut.Count.ShouldBe(3);
        }

        [Fact]
        public void Remove_String_ShouldRemoveString()
        {
            sut.Add("apple");
            sut.Add("banana");
            sut.Add("grape");

            var removedItem = sut.Remove();

            sut.Count.ShouldBe(2);
            removedItem.ShouldBe("grape");
        }

        [Fact]
        public void First_String_ShouldReturnFirstString()
        {
            sut.Add("apple");
            sut.Add("banana");
            sut.Add("grape");

            var firstString = sut.First();

            firstString.ShouldBe("apple");
        }

        [Fact]
        public void Last_String_ShouldReturnLastString()
        {
            sut.Add("apple");
            sut.Add("banana");
            sut.Add("grape");

            var lastString = sut.Last();

            lastString.ShouldBe("grape");
        }
    }
}
