using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }
    // [HttpGet]
    // [Authorize]
    // public ActionResult<IEnumerable<VaultKeep>> Get()
    // {
    //   try
    //   {
    //     return Ok(_vks.Get());
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   };
    // }

    // [HttpGet("{id}")]
    // [Authorize]
    // public ActionResult<VaultKeep> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_vks.GetById(id));
    //   }
    //   catch (Exception e)
    //   {

    //     return BadRequest(e.Message);
    //   }
    // }
    [HttpGet("{vaultId}/keeps")]
    [Authorize]
    public ActionResult<VaultKeep> Get(int vaultId)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.GetKeepsByVaultId(vaultId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpPost]
    [Authorize]
    public ActionResult<String> Create([FromBody] VaultKeep newData)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newData.UserId = userId;
        _vks.Create(newData);
        return Ok("Success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // [HttpDelete("{vaultId}/keeps/{keepId}")]
    // [Authorize]
    // public ActionResult<string> Delete(int vaultId, int keepId)
    // {
    //   try
    //   {
    //     var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    //     return Ok(_vks.Delete(vaultId, keepId, userId));
    //   }
    //   catch (Exception e)
    //   {

    //     return BadRequest(e.Message); ;
    //   }
    // }
    [HttpDelete("{vaultId}/keeps/{keepId}")]
    [Authorize]
    public ActionResult<string> Delete(int vaultId, int keepId)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Delete(vaultId, keepId, userId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message); ;
      }
    }

  }
}