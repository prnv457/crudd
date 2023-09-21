using crudd.Model;
using crudd.Model.Data;
using Dapper;
using System.Data;

namespace crudd.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapDBContext context;
        public EmployeeRepo(DapDBContext context)
        {
            this.context = context;
        }
        public async Task<string> Create(Employee employee) 
        {
            string response = string.Empty;
            string query = "Insert into Employee (Name,Email,Phone,Designations) values (@name,@email,@phone,@designations)";
            var parameters = new DynamicParameters();
            parameters.Add("name",employee.Name,DbType.String);
            parameters.Add("email", employee.Email, DbType.String);
            parameters.Add("phone", employee.Phone, DbType.String);
            parameters.Add("desiganations", employee.Designations, DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                await connectin.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
        public async Task<List<Employee>> GetAll()
        {
            string query = "Select * From Employee";
            using(var connection=this.context.CreateConnection())
            {
                var emplist=await connection.QueryAsync<Employee>(query);
                return emplist.ToList();
            }
        }
        public async Task<Employee> Getbycode(int code) 
        {
            string query = "Select * From Employee where code=@code";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.QueryFirstOrDefaultAsync<Employee>(query, new {code});
                return emplist;
            }
        }
        public async Task Remove(Employee employee) 
        {
            string response = string.Empty;
            string query = "Select * From Employee where code=@code";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.ExecuteAsync(query, new { code });
                return "pass";
            }
            return response;
        }
        public async void Update(Employee employee) 
        {
            string response = string.Empty;
            string query = "Update Employee set Name=@name,Email=@email,Phone=@phone,Desiganations=@designations, where code=@code";
            var parameters = new DynamicParameters();

            parameters.Add("code", employee.Eid, DbType.String);
            parameters.Add("name", employee.Name, DbType.String);
            parameters.Add("email", employee.Email, DbType.String);
            parameters.Add("phone", employee.Phone, DbType.String);
            parameters.Add("desiganations", employee.Designations, DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                await connectin.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
