using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<VaultKeep> Get()
    {
      string sql = "SELECT * FROM vaultkeeps WHERE isPrivate = 0;";
      return _db.Query<VaultKeep>(sql);
    }
    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });

    }
    internal IEnumerable<Keep> GetKeepsByVaultId(int id)
    {
      string sql = @"
      SELECT k.* FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @vaultId AND vk.userId = @userId)
      ";
      return _db.Query<Keep>(sql, new { id });
    }

    internal VaultKeep Create(VaultKeep vaultKeepData)
    {
      string sql = @"
            INSERT INTO vaultkeeps (vaultId, keepId, userId) VALUES (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
      vaultKeepData.Id = id;
      return vaultKeepData;
    }


    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}