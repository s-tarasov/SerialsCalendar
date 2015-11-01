﻿using System.Threading.Tasks;

namespace Calendar.Builder.ReleaseProviders.TvRage
{
    public interface ISerialIdProvider
    {
        Task<string> GetSerialId(string serialAlias);
    }
}