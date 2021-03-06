﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace Calendar.Caching
{
    public class FileSystemCache : IStringCache
    {
        private readonly string _directory;

        public FileSystemCache(string directory)
        {
            _directory = directory;

            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }
        }

        public async Task<string> GetOrCreateAsync(string key, Func<Task<string>> factory)
        {
            var filename = _directory + "\\" + key;

            if (File.Exists(filename))
            {
                return await File.ReadAllTextAsync(filename);
            }

            var value = await factory();

            await File.WriteAllTextAsync(filename, value);

            return value;
        }
    }
}
