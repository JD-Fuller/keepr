using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _repo = vkr;
    }
    internal IEnumerable<VaultKeep> Get()
    {
      return _repo.Get();
    }
    internal VaultKeep GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }

    internal VaultKeep GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      //   newVault.Id = _repo.Create(newVault);
      _repo.Create(newVaultKeep);
      return newVaultKeep;
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