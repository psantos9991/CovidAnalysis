using CovidAnalysis.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidAnalysis.Core.Queries
{
    internal class GetAllCovidStatisticsQueryHandler : IRequestHandler<GetAllCovidStatisticsQuery, List<CovidStatistic>>
    {
        private readonly ICovidStatisticRepository _covidStatisticRepository;
        public GetAllCovidStatisticsQueryHandler(ICovidStatisticRepository covidStatisticRepository) 
        { 
            _covidStatisticRepository= covidStatisticRepository;//faço a injeçao de dependencia
        }
        public async Task<List<CovidStatistic>> Handle(GetAllCovidStatisticsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _covidStatisticRepository.GetAllCovidStatistics());//quando chega aqui é feita uma consulta a base de dados
        }
    }
}
