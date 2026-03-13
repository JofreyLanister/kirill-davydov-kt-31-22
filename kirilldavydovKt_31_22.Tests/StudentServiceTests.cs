using kirilldavydovKt_31_22.Data;
using kirilldavydovKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace kirilldavydovKt_31_22.Tests
{
    public class StudentServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public StudentServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task AddStudent_Test()
        {
            using var context = new AppDbContext(_dbContextOptions);

            var group = new Group
            {
                Name = "KT-31-22"
            };

            await context.Groups.AddAsync(group);
            await context.SaveChangesAsync();

            var student = new Student
            {
                FullName = "Иванов Иван Иванович",
                GroupId = group.Id
            };

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();

            var studentsCount = await context.Students.CountAsync();

            Assert.Equal(1, studentsCount);
        }
    }
}