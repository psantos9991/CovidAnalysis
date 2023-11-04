using CovidAnalysis.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.Core.Commands
{
    public class CovidStatisticCreateCommandHandler : IRequestHandler<CovidStatisticCreateCommand, CovidStatistic>
    {

        private readonly ICovidStatisticRepository _covidStatisticRepository;
        public CovidStatisticCreateCommandHandler(ICovidStatisticRepository covidStatisticRepository)
        {
            _covidStatisticRepository = covidStatisticRepository;
        }


        public async Task<CovidStatistic> Handle(CovidStatisticCreateCommand request, CancellationToken cancellationToken)
        {
            CovidStatistic covidStatistic = new CovidStatistic();
            covidStatistic.Country = request.Country;
            covidStatistic.Population = request.Population;
            covidStatistic.DeathsPer1Mpopulation = request.DeathsPer1Mpopulation;
            covidStatistic.TestsPer1Mpopulation = request.TestsPer1Mpopulation;
            covidStatistic.TotCasesPer1Mpopulation = request?.TotCasesPer1Mpopulation;
            covidStatistic.SeriousCritical = request?.SeriousCritical;
            covidStatistic.ActiveCases = request?.ActiveCases;
            covidStatistic.NewCases = request?.NewCases;
            covidStatistic.NewDeaths = request?.NewDeaths;
            covidStatistic.NewRecovered = request?.NewRecovered;
            covidStatistic.TotalTests= request?.TotalTests;

            return await _covidStatisticRepository.CreateAsync(covidStatistic);
        }
    }
}
