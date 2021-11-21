using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Day12.Tests
{
    [TestFixture]
    public class SumNumbersTests
    {
        [Test]
        public void SimpleArray()
        {
            var input = "[1,2,3]";
            var doc = JArray.Parse(input);

            var result = Program.SumNumbers(doc);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void SimpleObject()
        {
            var input = "{\"a\":2,\"b\":4}";
            var doc = JObject.Parse(input);

            var result = Program.SumNumbers(doc);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void NestedArrays()
        {
            var input = "[[[3]]]";
            var doc = JArray.Parse(input);

            var result = Program.SumNumbers(doc);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void NestedObjects()
        {
            var input = "{\"a\":{\"b\":4},\"c\":-1}";
            var doc = JObject.Parse(input);

            var result = Program.SumNumbers(doc);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void ObjectWithRedPropertyIsIgnored()
        {
            var input = "[1,{\"c\":\"red\",\"b\":2},3]";
            var doc = JArray.Parse(input);

            var result = Program.SumNumbers(doc);

            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void ObjectWithRedPropertyIsIgnored2()
        {
            var input = "{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}";
            var doc = JObject.Parse(input);

            var result = Program.SumNumbers(doc);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void RedElementInArrayHasNoEffect()
        {
            var input = "[1,\"red\",5]";
            var doc = JArray.Parse(input);

            var result = Program.SumNumbers(doc);

            Assert.That(result, Is.EqualTo(6));
        }
    }
}
