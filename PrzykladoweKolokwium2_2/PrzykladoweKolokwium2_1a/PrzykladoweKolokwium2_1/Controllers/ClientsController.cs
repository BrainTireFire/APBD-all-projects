using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzykladoweKolokwium2_1.Models;
using PrzykladoweKolokwium2_1.Models.DTOs;
using PrzykladoweKolokwium2_1.Services;
using System.Transactions;

namespace PrzykladoweKolokwium2_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public ClientsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("{clientID}/orders")]
        public async Task<IActionResult> AddNewOrder(int clientID, NewOrderDTO newOrder)
        {
            if (!await _dbService.DoesClientExist(clientID))
                return NotFound($"Client with given ID - {clientID} doesn't exist");
            if (!await _dbService.DoesEmployeeExist(newOrder.EmployeeID))
                return NotFound($"Employee with given ID - {newOrder.EmployeeID} doesn't exist");

            var order = new Order
            {
                ClientID = clientID,
                EmployeeID = newOrder.EmployeeID,
                AcceptedAt = newOrder.AcceptedAt,
                Comments = newOrder.Comments,
            };

            var pastries = new List<OrderPastry>();
            foreach (var newPastry in newOrder.Pastries)
            {
                var pastry = await _dbService.GetPastryByName(newPastry.Name);
                if(pastry is null)
                    return NotFound($"Pastry with name - {newPastry.Name} doesn't exist");

                pastries.Add(new OrderPastry
                {
                    PastryID = pastry.ID,
                    Amount = newPastry.Amount,
                    Comments = newPastry.Comments,
                    Order = order
                });
            }

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _dbService.AddNewOrder(order);
                await _dbService.AddOrderPastries(pastries);

                scope.Complete();
            }

            return Created("api/orders", "");
        }
    }
}
