﻿using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foosball.Services
{
    public class LiteDbContext
    {
        public readonly LiteDatabase Context;
        public LiteDbContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                if (Context == null)
                {
                    var db = new LiteDatabase(configs.Value.Path);
                    if (db != null)
                        Context = db;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }
    }
}
