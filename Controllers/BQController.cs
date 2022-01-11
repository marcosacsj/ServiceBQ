using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceBQ.Interfaces;
using Google.Cloud.BigQuery.V2;
using Google.Apis.Bigquery.v2.Data;

namespace ServiceBQ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BQController : ControllerBase
    {
        private readonly BQInterface _bigQuery;

        public BQController(BQInterface bigQuery)
        {
            _bigQuery = bigQuery;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [Route("")]
        public IActionResult Get( )
        {
            string query = @"
            SELECT
             *
            FROM
              `bigquery-public-data.covid19_open_data.covid19_open_data`
              where location_key = 'BR'
              Limit 10
            ";

            var rows = _bigQuery.GetRows(query);
            List<BigQueryRow> _rows = rows.ToList();
            List<TableRow> _tableRows = new List<TableRow>();
            foreach (var row in _rows)
            {
                _tableRows.Add(row.RawRow);
            }
            return Ok(_rows[0].Schema.Fields);
        }
    }
}