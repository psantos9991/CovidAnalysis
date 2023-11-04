using CovidAnalysis.Core.Models;

namespace CovidAnalysis.Core
{
    public interface ICovidStatisticRepository
    {
        CovidStatistic GetOneCovidStatistics(int id);
        List<CovidStatistic> GetAllCovidStatistics();
        List<CovidStatistic> GetCovidStatistics(int take);
        List<CovidStatistic> SearchCovidStatistics(int take, string search);
        Task<CovidStatistic> CreateAsync(CovidStatistic entity);
    }
}
