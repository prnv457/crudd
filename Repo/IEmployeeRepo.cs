using crudd.Model;

namespace crudd.Repo
{
    public class IEmployeeRepo
    {
        Task<List<Employee>> GetAll();
        Task<List<Employee>> Getbycode(int code);
        Task<string> Create(Employee employee);

        Task<string> Update(Employee employee,int code);
        Task<string> Remove( int code);


    }
}
