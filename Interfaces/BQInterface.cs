using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.BigQuery.V2;

namespace ServiceBQ.Interfaces
{
    public interface BQInterface
    {
        BigQueryResults GetRows(string query);
        BigQueryClient GetBigqueryClient();
    }
}