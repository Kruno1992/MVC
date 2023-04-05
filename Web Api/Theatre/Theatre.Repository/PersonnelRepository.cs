using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Theatre.Common;
using Theatre.Model;
using Theatre.Repository.Common;

namespace Theatre.Repository
{
    public class PersonnelRepository : IPersonnelRepository
    {
        public static string connectionString = "Data Source=DESKTOP-6E381JI;Initial Catalog=ProdajaKarataKazalište;Integrated Security=True";

        public async Task<List<Personnel>> GetAllPersonnelAsync(Paging paging, Sorting sorting, Filtering filtering)
        {
            try
            {
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    using (connection)
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM Personnel;", connection);
                        connection.Open();
                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        List<Personnel> worker = new List<Personnel>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Personnel personnel = new Personnel
                                {
                                    Id = reader.GetGuid(0),
                                    PersonnelName = reader.GetString(1),
                                    Surname = reader.GetString(2),
                                    Position = reader.GetString(3),
                                    HoursOfWork = reader.GetInt32(4)
                                };
                                worker.Add(personnel);
                            }
                            reader.Close();
                            return worker;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Personnel> GetPersonnelAsync(Guid id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Personnel WHERE Id=@Id;", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        Personnel personnel = new Personnel();

                        personnel.Id = reader.GetGuid(0);
                        personnel.PersonnelName = reader.GetString(1);
                        personnel.Surname = reader.GetString(2);
                        personnel.Position = reader.GetString(3);
                        personnel.HoursOfWork = reader.GetInt32(4);

                        reader.Close();
                        return personnel;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> AddPersonnelAsync(Personnel personnel)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Personnel (Id, PersonnelName, Surname, Position, HoursOfWork)" +
                                   " VALUES (@Id, @personnelname, @surname, @position, @hoursofwork)", connection);
                    personnel.Id = Guid.NewGuid();
                    command.Parameters.AddWithValue("@id", personnel.Id);
                    command.Parameters.AddWithValue("@personnelname", personnel.PersonnelName);
                    command.Parameters.AddWithValue("@surname", personnel.Surname);
                    command.Parameters.AddWithValue("@position", personnel.Position);
                    command.Parameters.AddWithValue("@hoursofwork", personnel.HoursOfWork);


                    connection.Open();

                    int RowsAffected = await command.ExecuteNonQueryAsync();
                    if (RowsAffected >= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> EditPersonnelAsync(Guid id, Theatre.Model.Personnel personnel)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {

                    SqlCommand command = new SqlCommand("UPDATE Personnel SET PersonnelName=@personnelname, Surname=@surname, Position=@position, HoursOfWork=@hoursofwork WHERE Id=@id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@personnelname", personnel.PersonnelName);
                    command.Parameters.AddWithValue("@surname", personnel.Surname);
                    command.Parameters.AddWithValue("@position", personnel.Position);
                    command.Parameters.AddWithValue("@hoursofwork", personnel.HoursOfWork);

                    connection.Open();
                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeletePersonnelAsync(Guid id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Personnel WHERE Id=@Id", connection);

                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    int numberOfAffectedRows = await command.ExecuteNonQueryAsync();
                    if (numberOfAffectedRows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<Personnel>> PagingSortingFiltering(Paging paging,Sorting sorting,Filtering filtering) //PAGING SORTING FILTERING
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    StringBuilder queryString = new StringBuilder();
                    queryString.AppendLine("SELECT*FROM Personnel WHERE 1=1 ");

                    //filtering
                    if (filtering != null)
                    {
                        if (filtering.Id != Guid.Empty)
                        {
                            queryString.AppendLine("AND Id = @Id ");
                        }
                    }
                    
                    //sorting
                    if (sorting != null)
                    {
                        queryString.AppendLine($"ORDER BY {sorting.OrderBy} ");
                    }

                    //paging
                    if (paging != null)
                    {
                        queryString.AppendLine(" OFFSET (@pageNumber -1) * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY;");
                    }
                    
                    SqlCommand command = new SqlCommand(queryString.ToString(), connection);
                    command.Parameters.AddWithValue("@Id", filtering.Id);
                    command.Parameters.AddWithValue("@PageSize", paging.PageSize);
                    command.Parameters.AddWithValue("@PageNumber", paging.PageNumber);


                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    List<Personnel> personnel = new List<Personnel>();

                    while (reader.Read())
                    {
                        Personnel pers = new Personnel();

                        pers.Id = reader.GetGuid(0);
                        pers.PersonnelName = reader.GetString(1);
                        pers.Surname = reader.GetString(2);
                        pers.Position = reader.GetString(3);
                        pers.HoursOfWork = reader.GetInt32(4);

                        personnel.Add(pers);
                    }

                    if (reader.HasRows)
                    {
                        reader.Close();
                        return personnel;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
