using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwium2_1.Data;
using PrzykladoweKolokwium2_1.Models;
using PrzykladoweKolokwium2_1.Models.DTOs;

namespace PrzykladoweKolokwium2_1.Services
{
    public class DbService : IDbService
    {
        private readonly PastryContext _context;
        public DbService(PastryContext context)
        {
            _context = context;
        }

        public async Task AddNewOrder(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrderPastries(IEnumerable<OrderPastry> orderPastries)
        {
            await _context.AddRangeAsync(orderPastries);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DoesClientExist(int clientID)
        {
            return await _context.Clients.AnyAsync(e => e.ID == clientID);
        }

        public async Task<bool> DoesEmployeeExist(int employeeID)
        {
            return await _context.Employees.AnyAsync(e => e.ID == employeeID);
        }

        public async Task<ICollection<Order>> GetOrdersData(string? clientLastName)
        {
            return await _context.Orders
                .Include(e => e.Client)
                .Include(e => e.OrderPastries)
                .ThenInclude(e => e.Pastry)
                .Where(e => clientLastName == null || e.Client.LastName == clientLastName)
                .ToListAsync();
        }

        public async Task<Pastry?> GetPastryByName(string name)
        {
            return await _context.Pastries.FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}
