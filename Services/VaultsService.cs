using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository vr)
    {
      _repo = vr;
    }
    internal IEnumerable<Vault> Get(string userId)
    {
      // return _repo.Get();
      return _repo.Get(userId);
    }
    internal Vault GetById(int id, string userId)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      else if (exists.UserId != userId) { throw new Exception("Not valid vault - user permission"); }
      return exists;
    }

    internal Vault Create(Vault newVault)
    {
      //   newVault.Id = _repo.Create(newVault);
      _repo.Create(newVault);
      return newVault;
    }

    internal Vault Edit(Vault update)
    {
      Vault exists = _repo.GetById(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      // if (exists.UserId != update.UserId)
      // {
      //   throw new Exception("Invalid User");
      // }
      _repo.Edit(update);
      return update;
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