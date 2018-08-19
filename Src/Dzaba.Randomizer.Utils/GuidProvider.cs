﻿using System;

namespace Dzaba.Randomizer.Utils
{
    public interface IGuidProvider
    {
        Guid CreateNew();
    }

    internal sealed class GuidProvider : IGuidProvider
    {
        public Guid CreateNew()
        {
            return Guid.NewGuid();
        }
    }
}
