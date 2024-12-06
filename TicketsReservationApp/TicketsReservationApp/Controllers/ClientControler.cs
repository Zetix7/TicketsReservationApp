using Microsoft.AspNetCore.Mvc;
using TicketsReservation.DataAccess.Entities;
using TicketsReservation.DataAccess.Repository;

namespace TicketsReservation.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IRepository<Client> _repository;

    public ClientController(IRepository<Client> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("")]
    public IEnumerable<Client> GetAllClients()
    {
        return _repository.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public Client? GetClientById(int id)
    {
        return _repository.GetById(id);
    }
}
