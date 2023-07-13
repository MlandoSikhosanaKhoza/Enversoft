using Enversoft.DAL;
using Enversoft.Shared;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.UnitTests
{
    public class SupplierRepositoryTests
    {
        //SUT
        private readonly ISupplierRepository _supplierRepository;
        private readonly ApplicationDbContext _dbContext;
        public SupplierRepositoryTests()
        {
            _dbContext = GetDbContext().GetAwaiter().GetResult();
            IUnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            _supplierRepository = new SupplierRepository(unitOfWork);
        }

        #region DBContext Setup
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Supplier.CountAsync() == 0)
            {
                await databaseContext.Supplier.AddAsync(new Supplier { Code = 300, Name = "Cow", Telephone = "0000000715" });
                await databaseContext.Supplier.AddAsync(new Supplier { Code = 350, Name = "Frog", Telephone = "008888888" });
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }
        #endregion DBContext Setup

        [Fact]
        public void SupplierRepository_AddSupplier_ReturnCount()
        {
            //Arrange
            int count = 0;
            //Act
            _supplierRepository.AddSupplier(new Supplier { Code = 345, Name = "Chicken", Telephone = "000049494" });
            count=_dbContext.Supplier.Count();
            //Assert
            count.Should().Be(3);
        }
        [Fact]
        public void SupplierRepository_GetSuppliers_ReturnCount()
        {
            //Arrange
            int count = 0;
            //Act
            List<Supplier> suppliers = _supplierRepository.GetSuppliers();
            count = _dbContext.Supplier.Count();
            //Assert
            count.Should().Be(2);
        }
    }
}
