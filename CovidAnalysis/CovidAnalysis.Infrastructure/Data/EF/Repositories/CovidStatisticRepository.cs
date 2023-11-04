using CovidAnalysis.Core;
using CovidAnalysis.Core.Models;
using System.Globalization;

namespace CovidAnalysis.Infrastructure.Data.EF.Repositories
{
    public class CovidStatisticRepository : ICovidStatisticRepository
    {//padrao repositorio
        private readonly CovidDbContext _context;
        public CovidStatisticRepository(CovidDbContext context) 
        {
            _context= context;
        }

        public List<CovidStatistic> GetAllCovidStatistics() 
        { 
            return _context.CovidStatistics.ToList();
        }

        public CovidStatistic GetOneCovidStatistics(int id)
        {
            return _context.CovidStatistics.Where(p => p.Id == id).FirstOrDefault();
        }

        public List<CovidStatistic> GetCovidStatistics (int take)
        {
            return _context.CovidStatistics.Take(take).ToList();
        }


        public List<CovidStatistic> SearchCovidStatistics(int take, string search)
        {
            return _context.CovidStatistics
                .Where(x => x.Country.Contains(search.ToLower()))
                .Take(take).ToList();
        }

        public Task<CovidStatistic> CreateAsync(CovidStatistic entity)
        {
            throw new NotImplementedException();
        }
    }
}
