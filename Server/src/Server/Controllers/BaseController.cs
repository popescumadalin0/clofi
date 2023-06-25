using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
}