

using Dapper;
using Npgsql;

var connString = "Server=localhost; Port=5432; Database=Dapper1; User Id=postgres; Password=233223";

await using var conn = new NpgsqlConnection(connString);

Add("Shahrom2", "Sharipov2", "Shahrom2@gmail.com");
Add("Bakhtovar2", "Rizozoda2", "Bakhtovar2@gmail.com");
Add("Chori2", "kobilov2", "Chori2@gmail.com"); 


void Add(string firstName, string lastName, string email)
{
    using (var conn = new NpgsqlConnection(connString))
    {
        var sql = $"insert into users(first_name, last_name,email)" +
            $"values" +
            $"('{firstName}','{lastName}', '{email}')";
        conn.Execute(sql);
    }
}


Delete(3);
void Delete(int id)
{
    using (var conn = new NpgsqlConnection(connString))
    {
        var sql = $"delete from users where  id= ({id})";
        conn.Execute(sql);
    }
}


Update(1, "Shahrom", "Sharipov", "Shahrom12@gmail.com");
void Update(int id, string firstName, string lastName, string email)
{
    using (var conn = new NpgsqlConnection(connString))
    {
        var sql = $"update users set " +
            $"first_name ='{firstName}', " +
            $"last_name = '{lastName}'," +
            $" email = '{email}'" +
            $" where  id= ('{id}')";
        conn.Execute(sql);
    }
}

void Get()
{
    using (var conn = new NpgsqlConnection(connString))
    {
        conn.Open();
        var sql = $"select * from users";
        var users = conn.Query(sql);

        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.id}\n" +
                $"firstName: {user.first_name} \n" +
                $"LastName: {user.last_name} \n" +
                $"Email: {user.email}\n");
        }   }
}
Get();


void GetById(int id)
{
    using (var conn = new NpgsqlConnection(connString))
    {
        conn.Open();
        var sql = $"select * from users where id = {id}";
        var users = conn.Query(sql);

        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.id}\n" + 
                $"firstName: {user.first_name} \n" +
                $"LastName: {user.last_name} \n" +
                $"Email: {user.email}  \n");
        }
    }
}
GetById(5);

