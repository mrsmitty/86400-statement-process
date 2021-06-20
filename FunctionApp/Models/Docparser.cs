using System;
using System.Collections.Generic;

namespace FunctionApp.Models
{
    public class TableData
    {
        public string key_0 { get; set; }
        public string key_1 { get; set; }
        public string key_2 { get; set; }
        public string key_3 { get; set; }
        public string key_4 { get; set; }
    }

    public class DocParserRoot
    {
        public string id { get; set; }
        public string document_id { get; set; }
        public string remote_id { get; set; }
        public string file_name { get; set; }
        public string media_link { get; set; }
        public string media_link_original { get; set; }
        public string media_link_data { get; set; }
        public int page_count { get; set; }
        public DateTime uploaded_at { get; set; }
        public DateTime processed_at { get; set; }
        public List<TableData> table_data { get; set; }
    }

}