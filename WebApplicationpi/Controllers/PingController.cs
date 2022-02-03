using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationpi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PingController : ControllerBase
{
    private Dictionary<string, string> hosts;
    
    public PingController(Dictionary<string, string> hosts)
    {
        this.hosts = hosts;
    }

    [HttpGet]
    public ActionResult<string> Get([FromQuery] string address, [FromQuery] string host)
    {
        //add host to hosts
        if (host != "" && address != "")
        {
            hosts.Add(host, address);
        }

        Console.Out.WriteLine(address + " " + host);
        
        return Ok(new {address,host});
    }
    
    [HttpGet("host")]
    public ActionResult<string> GetHost([FromQuery] string host)
    {
        if (hosts.ContainsKey(host))
        {
            return Ok(hosts[host]);
        }
        else
        {
            return NotFound();
        }
    }
}