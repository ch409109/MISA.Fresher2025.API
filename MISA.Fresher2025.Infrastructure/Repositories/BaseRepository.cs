using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Infrastructure.Repositories
{
    public class BaseRepository<T> where T : class
    {
        readonly string connectionString;
        IDbConnection dbConnection;
        public BaseRepository(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
            dbConnection = new MySqlConnection(connectionString);
        }

        public List<T> GetAll()
        {
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr != null ? tableAttr.Name : typeof(T).Name.ToLower();

            var sqlCommand = $"SELECT * FROM {tableName}";

            var data = dbConnection.Query<T>(sqlCommand).ToList();
            return data;
        }

        public T GetById(string id)
        {
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr != null ? tableAttr.Name : typeof(T).Name.ToLower();
            var sqlCommand = $"SELECT * FROM {tableName} WHERE {tableName}_id = @id";
            var data = dbConnection.QueryFirstOrDefault<T>(sqlCommand, new { id });
            return data;
        }

        public void Create(T entity)
        {
            var properties = typeof(T).GetProperties();
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr != null ? tableAttr.Name : typeof(T).Name.ToLower();
            var columns = "";
            var columnParam = "";
            var parameters = new DynamicParameters();
            foreach (var prop in properties)
            {
                var keyAttr = prop.GetCustomAttribute<KeyAttribute>();
                if (keyAttr != null)
                {
                    continue;
                }

                var columnAttr = prop.GetCustomAttribute<ColumnAttribute>();
                var columnName = columnAttr != null ? columnAttr.Name : prop.Name;

                columns += $"{columnName},";
                columnParam += $"@{prop.Name},";
                parameters.Add($"@{prop.Name}", prop.GetValue(entity));
            }

            columns = columns.TrimEnd(',');
            columnParam = columnParam.TrimEnd(',');

            var sqlCommand = $"INSERT INTO {tableName} ({columns}) VALUES ({columnParam})";

            var res = dbConnection.Execute(sqlCommand, parameters);
        }

        public void Update(T entity, string id)
        {
            var properties = typeof(T).GetProperties();
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr != null ? tableAttr.Name : typeof(T).Name.ToLower();
            var setClause = "";
            var parameters = new DynamicParameters();
            foreach (var prop in properties)
            {
                if (prop.Name.EndsWith("Id"))
                {
                    continue;
                }
                var columnAttr = prop.GetCustomAttribute<ColumnAttribute>();
                var columnName = columnAttr != null ? columnAttr.Name : prop.Name;
                setClause += $"{columnName} = @{prop.Name},";
                parameters.Add($"@{prop.Name}", prop.GetValue(entity));
            }
            setClause = setClause.TrimEnd(',');
            var sqlCommand = $"UPDATE {tableName} SET {setClause} WHERE {tableName}_id = @id";
            parameters.Add("@id", id);
            var res = dbConnection.Execute(sqlCommand, parameters);
        }

        public void Delete(string id)
        {
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr != null ? tableAttr.Name : typeof(T).Name.ToLower();
            var keyColumn = typeof(T).GetCustomAttributes<KeyAttribute>();
            var sqlCommand = $"DELETE FROM {tableName} WHERE {tableName}_id = @id";

            var res = dbConnection.Execute(sqlCommand, new { id });
        }
    }
}
