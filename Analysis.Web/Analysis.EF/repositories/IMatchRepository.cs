﻿using Analysis.EF.entities;
using System.Collections.Generic;

namespace Analysis.EF.repositories
{
    public interface IMatchRepository
    {
        Match SaveRiotMatchById(long id, string api);
    }
}