﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BeeHive.Azure.Tests.Integration
{

    public class AzureCounterStoreTests
    {

        private const string ConnectionString = "UseDevelopmentStorage=true;";

        private const string ContainerName = "band25";


        [Fact]
        public void ConcurrentIncrementWorks()
        {
            ThreadPool.SetMinThreads(20, 20);
            var key = Guid.NewGuid();
            const string CounterName = "TestCounter";
            const int Increment = 10;
            const int ParallelClients = 5;

            var counter = new AzureCounterStore(new BlobSource()
            {
                ConnectionString = ConnectionString,
                ContainerName = ContainerName,
                Path = string.Format("I/Have/Got/A/Dream/{0}/", Guid.NewGuid().ToString("N")) 
            });

            Parallel.For(0, ParallelClients, (i) =>
            {
                counter.IncrementAsync(CounterName, key, Increment).Wait();
            });

            var result = counter.GetAsync(CounterName, key).Result;
            Assert.Equal(ParallelClients * Increment, result);
        }
    }
}
