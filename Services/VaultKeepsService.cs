using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultsRepository _repo;
    public VaultKeepsService(VaultsRepository vr)
    {
      _repo = vr;
    }
    internal IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }
    internal Vault GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }

    internal Vault Create(Vault newVault)
    {
      //   newVault.Id = _repo.Create(newVault);
      _repo.Create(newVault);
      return newVault;
    }

    internal string Delete(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null)
      {
        throw new Exception("Invalid ID");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }

  }
}