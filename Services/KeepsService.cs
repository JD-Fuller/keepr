using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository kr)
    {
      _repo = kr;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public Keep Create(Keep newKeep)
    {
      //   newKeep.Id = _repo.Create(newKeep);
      _repo.Create(newKeep);
      return newKeep;
    }
  }
}