using CovidAnalysis.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.Core.Queries
{
    internal class GetOneCovidStatisticsHandler : IRequestHandler<GetOneCovidStatisticsQuery, CovidStatistic>
    {
        private readonly ICovidStatisticRepository _covidStatisticRepository;

        public GetOneCovidStatisticsHandler(ICovidStatisticRepository covidStatisticRepository)
        {
            _covidStatisticRepository= covidStatisticRepository;
        }

        public async Task<CovidStatistic> Handle(GetOneCovidStatisticsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>  _covidStatisticRepository.GetOneCovidStatistics(request.Id));
        }
    }
}
