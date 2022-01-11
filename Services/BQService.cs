using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBQ.Interfaces;
using Google.Cloud.BigQuery.V2;
using Google.Apis.Auth.OAuth2;

namespace ServiceBQ.Services
{
    public class BQService:BQInterface
    {
        const string PROJECT_ID = "bqservice";

        readonly IWebHostEnvironment _hostingEnvironment;

        public BQService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public BigQueryClient GetBigqueryClient()
        {
            string config = Path.Combine(_hostingEnvironment.WebRootPath, "bq-key.json");

            GoogleCredential credential = null;
            using (var jsonStream = new FileStream(config, FileMode.Open, FileAccess.Read, FileShare.Read))
                credential = GoogleCredential.FromStream(jsonStream);

            return BigQueryClient.Create(PROJECT_ID, credential);
        }
        public BigQueryResults GetRows(string _query)
        {

            
            BigQueryClient client = GetBigqueryClient();
            
            //usando pesquisa caheada
            QueryOptions queryOptions = new QueryOptions
            {
                UseQueryCache = true
            };

            BigQueryResults results = client.ExecuteQuery(_query, parameters: null, queryOptions: queryOptions);

            return results;
        }
    }
}