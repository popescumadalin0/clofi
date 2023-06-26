using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DatabaseLayout.Data;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public class ClientController : BaseController
    {
        private readonly ClofiContext _clofiContext;

        public ClientController(ClofiContext context)
        {
            _clofiContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetUsers()
        {
            var users = _clofiContext.Clients.ToList();

            return Ok(users);
        }
    }
}
