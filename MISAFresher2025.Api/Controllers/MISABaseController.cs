using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace MISA.Fresher2025.Api.Controllers
{
    public class MISABaseController<T>() : ControllerBase where T : class
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var connectionString = "Host=localhost;Port=3306;Database=misa_sale_order;User Id=root;Password=Bluefukuoka22112003.;";
            using var connection = new MySqlConnection(connectionString);
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr != null ? tableAttr.Name : typeof(T).Name.ToLower();
            var sqlCommand = $"SELECT * FROM {tableName} WHERE {tableName}_id = @id";
            var data = connection.QueryFirstOrDefault<T>(sqlCommand, new { id });
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(T entity)
        {
            var connectionString = "Host=localhost;Port=3306;Database=misa_sale_order;User Id=root;Password=Bluefukuoka22112003.;";
            var connection = new MySqlConnection(connectionString);
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
                //if (prop.Name.EndsWith("Id"))
                //{
                //    continue;
                //}

                var columnAttr = prop.GetCustomAttribute<ColumnAttribute>();
                var columnName = columnAttr != null ? columnAttr.Name : prop.Name;

                columns += $"{columnName},";
                columnParam += $"@{prop.Name},";
                parameters.Add($"@{prop.Name}", prop.GetValue(entity));
            }

            columns = columns.TrimEnd(',');
            columnParam = columnParam.TrimEnd(',');

            var sqlCommand = $"INSERT INTO {tableName} ({columns}) VALUES ({columnParam})";

            var res = connection.Execute(sqlCommand, parameters);

            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] T entity)
        {
            var connectionString = "Host=localhost;Port=3306;Database=misa_sale_order;User Id=root;Password=Bluefukuoka22112003.;";
            var connection = new MySqlConnection(connectionString);
            var properties = typeof(T).GetProperties();
            //var tableName = typeof(T).Name.ToLower();
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
            var res = connection.Execute(sqlCommand, parameters);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var connectionString = "Host=localhost;Port=3306;Database=misa_sale_order;User Id=root;Password=Bluefukuoka22112003.;";
            var connection = new MySqlConnection(connectionString);
            var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
            var tableName = tableAttr != null ? tableAttr.Name : typeof(T).Name.ToLower();
            var keyColumn = typeof(T).GetCustomAttributes<KeyAttribute>();
            var sqlCommand = $"DELETE FROM {tableName} WHERE {tableName}_id = @id";

            var res = connection.Execute(sqlCommand, new { id });

            return Ok(res);
        }
    }
}
