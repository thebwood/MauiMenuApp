using Dapper;
using MauiMenuApi.DataAccessLayer.Repositories.Interfaces;
using MauiMenuApi.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MauiMenuApi.DataAccessLayer.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly string _connectionString;
        public MenuItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<MenuItemModel>> GetMainMenu()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"SELECT MenuItemId, ParentMenuItemId, DisplayName, Url
                                    FROM MenuItem
                                    WHERE ParentMenuItemId IS NULL
                                    ORDER BY DisplayName ASC";
                IEnumerable<MenuItemModel>? result = await db.QueryAsync<MenuItemModel>(sqlQuery);
                return result.ToList();
            }
        }

        public async Task<MenuItemModel> GetMenuItemById(int menuItemId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"SELECT MenuItemId, ParentMenuItemId, DisplayName, Url
                                    FROM MenuItem
                                    WHERE MenuItemId = @Id";
                MenuItemModel? result = await db.QuerySingleOrDefaultAsync<MenuItemModel>(sqlQuery, new { Id = menuItemId }) ?? new();
                return result;
            }
        }

        public async Task<List<MenuItemModel>> GetSubMenusByParentId(int parentId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"SELECT MenuItemId, ParentMenuItemId, DisplayName, Url
                                    FROM MenuItem
                                    WHERE ParentMenuItemId = @Id
                                    ORDER BY DisplayName ASC";
                IEnumerable<MenuItemModel>? result = await db.QueryAsync<MenuItemModel>(sqlQuery, new { Id = parentId });
                return result.ToList();
            }
        }
    }
}
