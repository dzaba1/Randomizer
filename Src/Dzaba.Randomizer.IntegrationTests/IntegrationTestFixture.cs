﻿using Ninject;
using NUnit.Framework;

namespace Dzaba.Randomizer.IntegrationTests
{
    public class IntegrationTestFixutre<T>
    {
        protected IKernel Container { get; private set; }

        [SetUp]
        public void Setup()
        {
            DbUtils.Delete();
            Container = Bootstrapper.CreateContainer();
        }

        [TearDown]
        public void Cleanup()
        {
            DbUtils.Delete();
        }

        protected T CreateSut()
        {
            return Container.Get<T>();
        }
    }
}