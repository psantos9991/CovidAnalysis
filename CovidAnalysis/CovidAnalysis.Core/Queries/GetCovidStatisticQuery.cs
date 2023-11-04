using CovidAnalysis.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.Core.Queries
{
    public class GetCovidStatisticQuery : IRequest<List<CovidStatistic>>
    {
        public int Take { get; set; }
    }


}
