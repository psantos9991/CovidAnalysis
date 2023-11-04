using CovidAnalysis.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.Core.Queries
{
    public class GetOneCovidStatisticsQuery : IRequest<CovidStatistic>
    {
        public int Id { get; set; }
    }
}
