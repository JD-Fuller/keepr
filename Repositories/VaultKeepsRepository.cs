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
    internal VaultKeep GetById(int vaultId, int keepId, string userId)
    {
      string sql = @"SELECT * FROM vaultkeeps WHERE vaultId = @VaultId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId, userId });
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"
      SELECT k.* FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @vaultId AND vk.userId = @userId)
      ";
      return _db.Query<Keep>(sql, new { vaultId, userId });
    }

    internal VaultKeep Find(VaultKeep vaultData)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId)";
      return _db.QueryFirstOrDefault(sql, vaultData);
    }


    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = @"
            INSERT INTO vaultkeeps (vaultId, keepId, userId) VALUES (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }


    internal void Delete(int vaultId, int keepId, string userId)
    {
      string sql = @"DELETE FROM vaultkeeps WHERE vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId";
      _db.Execute(sql, new { vaultId, keepId, userId });
    }
    // internal void Delete(int id)
    // {
    //   string sql = @"DELETE FROM vaultkeeps WHERE id = @Id";
    //   _db.Execute(sql, new { id });
    // }
  }
}