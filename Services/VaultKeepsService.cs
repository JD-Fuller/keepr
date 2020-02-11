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
    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      var exists = _repo.GetKeepsByVaultId(vaultId, userId);
      if (exists == null) { throw new Exception("This is not the droid you're looking for"); }
      return exists;
    }
    // internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    // {
    //   var exists = _repo.GetKeepsByVaultId(vaultId);
    //   if (exists == null) { throw new Exception("This is not the droid you're looking for"); }
    //   return exists;
    // }

    internal string Create(VaultKeep newData)
    {
      VaultKeep exists = _repo.Find(newData.VaultId, newData.KeepId);
      if (exists != null) { throw new Exception("Vault Keep already Exists"); }
      // newData.Id = _repo.Create(newData);
      _repo.Create(newData);
      return "Successfully created";
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
  }
}