using Microsoft.EntityFrameworkCore;
using kirilldavydovKt_31_22.Data;
using kirilldavydovKt_31_22.Models;

namespace kirilldavydovKt_31_22.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync(StudentFilter filter);
    }

    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync(StudentFilter filter)
        {
            var query = _context.Students
                .Include(s => s.Group)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.GroupName))
            {
                query = query.Where(s => s.Group.Name == filter.GroupName);
            }

            return await query.ToListAsync();
        }
    }
}