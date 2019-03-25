using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        { }

        public DbSet<Portfolio> Blogs { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Envelope> Envelopes { get; set; }
        public DbSet<SwapData> SwapData { get; set; }
        public DbSet<AdditionalFields> AdditionalFields { get; set; }

    }

    public class Portfolio
    {
        public ICollection<Trade> Posts { get; set; }
    }

    public class Trade
    {
        public string TradeId { get; set; }
        public string TradeType { get; set; }
        public Envelope Envelope { get; set; }
        public SwapData SwapData { get; set; }
    }

    public class Envelope
    {
        public string CounterPart { get; set; }
        public string NettingSetId { get; set; }
        public string PortfolioIds { get; set; }

        public AdditionalFields AdditionalFields { get; set; }
    }
    public class AdditionalFields
    {
        public string Sector { get; set; }
        public string Book { get; set; }
        public string Rating { get; set; }
    }

    public class SwapData
    {

    }
}