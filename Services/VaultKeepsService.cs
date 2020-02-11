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
    // internal VaultKeep GetById(int id)
    // {
    //   var exists = _repo.GetById(id);
    //   if (exists == null) { throw new Exception("Invalid ID"); }
    //   return exists;
    // }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      return _repo.GetKeepsByVaultId(vaultId, userId);
    }

    internal void Create(VaultKeep newData)
    {
      VaultKeep exists = _repo.Find(newData);
      if (exists != null) { throw new Exception("Vault Keep already Exists"); }
      // newData.Id = _repo.Create(newData);
      _repo.Create(newData);
    }

    internal string Delete(int vaultId, int keepId, string userId)
    {
      var exists = _repo.GetById(vaultId, keepId, userId);
      if (exists == null)
      {
        throw new Exception("Invalid ID");
      }
      _repo.Delete(vaultId, keepId, userId);
      return "Successfully Deleted";
    }
    // internal string Delete(int id)
    // {
    //   var exists = _repo.GetById(id);
    //   if (exists == null)
    //   {
    //     throw new Exception("Invalid ID");
    //   }
    //   _repo.Delete(id);
    //   return "Successfully Deleted";
    // }


  }
}