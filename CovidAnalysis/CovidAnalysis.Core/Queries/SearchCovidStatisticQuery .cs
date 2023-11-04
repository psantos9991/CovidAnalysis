using CovidAnalysis.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.Core.Queries
{
    public class SearchCovidStatisticQuery : IRequest<List<CovidStatistic>>
    {
        public string? Keyword { get; set; }
        public int Take { get; set; }
    }


}
