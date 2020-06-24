using System;

namespace Lawrence.Tsuro.TechTest.Entities.Contracts
{
    public interface IAudit
    {
        DateTime Updated { get; set; }
    }
}