using CovidAnalysis.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.Core.Queries
{
    internal class SearchCovidStatisticQueryHandler : IRequestHandler<SearchCovidStatisticQuery, List<CovidStatistic>>
    {//Aqui faço o processamento de determinada mensagem
        private readonly ICovidStatisticRepository _covidStatisticsRepository;
        public SearchCovidStatisticQueryHandler(ICovidStatisticRepository covidStatisticsRepository)
        {
            _covidStatisticsRepository = covidStatisticsRepository;
        }
        public async Task<List<CovidStatistic>> Handle(SearchCovidStatisticQuery request/*Representação da mensagem a ser processada*/, 
            CancellationToken cancellationToken)
        {//o request contem o input que será usado no meu handler
           return await Task.Run(() => _covidStatisticsRepository
           .SearchCovidStatistics(request.Take, request.Keyword?? string.Empty));//faço com que fique assincrono
        }
    }
}
