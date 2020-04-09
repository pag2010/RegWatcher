using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RegWatcher.Data;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace RegWatcher.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public async Task TestConnection()
        {   
            Assert.Pass();
        }
    }
}