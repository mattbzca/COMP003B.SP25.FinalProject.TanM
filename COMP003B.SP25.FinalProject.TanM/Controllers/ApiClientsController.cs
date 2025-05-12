using Microsoft.AspNetCore.Http;
using COMP003B.SP25.FinalProject.TanM.Data;
using COMP003B.SP25.FinalProject.TanM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.TanM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiClientsController : ControllerBase
    {
        // Uses current database for CRUD operations
        private readonly ApplicationDbContext _context;
        public ApiClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/clients, retrieving all clients
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            //returns all clients from asynced ApplicationDbContext
            return Ok(await _context.Clients.ToListAsync());
        }
        // GET: api/clients/{id}, retrieving a specific client by its ID.
        // Added route constraint {id:int} to enforce integers for client ID's.
        // Added optional segment {slug?}.
        [HttpGet("{id:int}/{slug?}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            // Find the client with the specified ID
            var client =  await _context.Clients.FindAsync(id);

            // if the client is not found, return a 404 Not Found response
            if (client is null)
                return NotFound();
            // if the client is found, return it with a 200 OK response
            return Ok(client);
        }
        // POST: api/clients, with endpoint creating a new client
        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            // Client is added to the database and saved via async
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            // Return a 201 Created response with the location of the new product
            return CreatedAtAction(nameof(GetClient), new { id = client.ClientId }, client);
        }
        // PUT: api/clients/{id}, with endpoint updating existing client. 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, Client updatedClient)
        {
            // Check if the client with the specified ID exists
            var existingClient = await _context.Clients.FindAsync(id);
            // if the product is not found, reutnr a 404 Not Found response
            if (existingClient is null)
                return NotFound();
            // Update the existing client's properties with the new values
            existingClient.Name = updatedClient.Name;
            _context.Entry(existingClient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            // Return a 204 No Content response to indicate success
            return NoContent();
        }
        // DELETE: api/clients/{id}, with endpoint deleting client by its ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            // Find the client with the specified ID
            var client = await _context.Clients.FindAsync(id);
            // if the client is not found, return a 404 Not Found Response
            if (client is null)
                return NotFound();
            // Remove the client from the database
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            // Return a 204 No Content response to indicate success
            return NoContent();
        }
        // GET: api/clients/filter?name={name}, with endpoint retrieving clients filtered by name.
        [HttpGet("filter")]
        public async Task<ActionResult<List<Client>>> FilterClients(string name)
        {
            // Filter clients based on the specified name, ordered by name
            var filteredClients = await _context.Clients
                .Where(c => c.Name.Contains(name))
                .OrderBy(c => c.Name)
                .ToListAsync();

            //if no clients match the filter, return a 404 Not Found response
            return Ok(filteredClients);
        }
        // GET: api/clients/names, with endpoint retrieving a list of client names. 
        [HttpGet("names")]
        public async Task<ActionResult<List<string>>> GetClientNames()
        {
            // Retrieve client names and order them alphabetically
            var clientNames = await _context.Clients
                .OrderBy(c => c.Name)
                .Select(c => c.Name)
                .ToListAsync();
            // if no clients are found return a 404 Not Found response
            return Ok(clientNames);
        }
    }
}
