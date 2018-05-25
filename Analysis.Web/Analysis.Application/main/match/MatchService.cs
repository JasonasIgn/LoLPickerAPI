﻿using AutoMapper;
using Analysis.Application.main.match.dto;
using Analysis.EF.entities;
using Analysis.EF.repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Analysis.Application.main.match
{
    public class MatchService : IMatchService
    {
        protected readonly IMapper _mapper;
        protected readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository MatchRepository, IMapper mapper)
        {
            _matchRepository = MatchRepository;
            _mapper = mapper;
        }

        public int SaveRiotMatchById(long id, string api)
        {
            int match = _matchRepository.SaveRiotMatchById(id, api);
            return match;
        }
        public Match FindMatch(string team1, string team2)
        {
            return _matchRepository.FindMatch(team1, team2);
        }



    }
}
