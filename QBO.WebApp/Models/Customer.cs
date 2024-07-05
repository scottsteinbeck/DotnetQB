using System;
using System.Collections.Generic;

namespace QBO.Shared
{
    public class Customer
    {
        public bool Taxable { get; set; }
        public bool Job { get; set; }
        public bool BillWithParent { get; set; }
        public double Balance { get; set; }
        public double BalanceWithJobs { get; set; }
        public CurrencyRef CurrencyRef { get; set; }
        public string PreferredDeliveryMethod { get; set; }
        public string Id { get; set; }
        public string SyncToken { get; set; }
        public MetaData MetaData { get; set; }
        public string FullyQualifiedName { get; set; }
        public string CompanyName { get; set; }
        public string DisplayName { get; set; }
        public string PrintOnCheckName { get; set; }
        public bool Active { get; set; }
    }

    public class CurrencyRef
    {
        public string value { get; set; }
        public string name { get; set; }
    }

    public class MetaData
    {
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }

    public class QueryResponse
    {
        public List<Customer> Customer { get; set; }
        public int startPosition { get; set; }
        public int maxResults { get; set; }
    }

    public class CustomerResponse
    {
        public QueryResponse QueryResponse { get; set; }
        public string time { get; set; }
    }
}
