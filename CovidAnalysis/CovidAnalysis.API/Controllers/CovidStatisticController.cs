using CovidAnalysis.Core.Commands;
using CovidAnalysis.Core.Models;
using CovidAnalysis.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CovidAnalysis.API.Controllers
{//É removida a logica do Controller aqui o controller recebe os requests HTTP e executa o Mediator
    [ApiController]
    [Route("[controller]")]
    public class CovidStatisticController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CovidStatisticController> _logger;

        public CovidStatisticController(IMediator mediator, ILogger<CovidStatisticController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetOneCovidStatistic/{id}")]//Meu roteamento
        public async Task<IActionResult> GetPerID(int id)
        {
            var query = new GetOneCovidStatisticsQuery { Id = id};
            
            var result = await _mediator.Send(query);//vai para o handler no Core que seria no nosso Application e é onde feito o processamento
            return Ok(result);
        }

        [HttpGet("GetAllCovidStatistic")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCovidStatisticsQuery();

            var result = await _mediator.Send(query);//vai para o handler no Core que seria no nosso Application e é onde feito o processamento
            return Ok(result);
        }

        [HttpGet("GetCovidStatistic/{take}")]
        public async Task<IActionResult> Get(int take)
        {
            var query = new GetCovidStatisticQuery
            {
                Take = take
            };
            
            var result = await _mediator.Send(query);//vai para o handler no Core que seria no nosso Application e é onde feito o processamento
            return Ok(result);
        }

        [HttpGet("SearchCovidStatistic/{take}/{keyword}")]
        public async Task<IActionResult> Search(int take, string keyword)
        {
            var query = new SearchCovidStatisticQuery
            {
                Keyword = keyword,
                Take = take
            };

            var result = await _mediator.Send(query);//vai para o handler no Core que seria no nosso Application e é onde feito o processamento
            return Ok(result);
        }

        //COMMAND
        [HttpPost]
        public async Task<IActionResult> Create(CovidStatistic covidStatistic)
        {
            try
            {
                var query = covidStatistic;
                await _mediator.Publish(query);
            }
            catch (Exception ex)
            {

            }

            return Ok(covidStatistic);
        }
    }
}