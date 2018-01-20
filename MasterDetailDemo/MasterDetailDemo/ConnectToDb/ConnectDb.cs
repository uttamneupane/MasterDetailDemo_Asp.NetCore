using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterDetailDemo.ConnectToDb
{
    public class ConnectDb : DbContext
    {
        public ConnectDb(DbContextOptions<ConnectDb> options) : base(options)
        { }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<PortfolioAccount> PortfolioAccounts { get; set; }
        public DbSet<StockReceiveMast> StockReceiveMasts { get; set; }
        public DbSet<StockReceiveDetl> StockReceiveDetls { get; set; }
    }
}
