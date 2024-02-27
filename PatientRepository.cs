using System.Data;
using Microsoft.Data.SqlClient;

namespace ConsoleAppTOConnectTODB;

public class PatientRepository
{
    string connectionString = "Server=localhost;Database=HMS;Integrated Security=True;TrustServerCertificate=true;";
    public void CreatePatient(string name, string gender, int age)
    {
        // Create a connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("Patient_Create", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@patientName", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@gender", gender);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]} ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("there are no rows to display");
                        }
                    }
                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine("the error" + e.Message);
                }
            }
            connection.Close();
            
        }
    }

    public void Patient_Update(int patientId, string name, int age, string gender)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("Patient_Update",connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@patientId",patientId);
                command.Parameters.AddWithValue("@patientName",name);
                command.Parameters.AddWithValue("@age",age);
                command.Parameters.AddWithValue("@gender",gender);
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"rows affected {reader[0]}");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("no rows affted");
                        }
                    }
                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
    
    public void CreateDoctor(string doctorType, string doctorName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("Doctor_Create",connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@doctorName", doctorName);
                command.Parameters.AddWithValue("@doctorType", doctorType);
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("there are no rows to display");
                        }
                    }
                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            connection.Close();
        }
    }

    public void DoctorPatientAppointment_Create(int patientId, int doctorId, DateTime ApptDate)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("DoctorPatientAppointment_Create",connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@patientId", patientId);
                command.Parameters.AddWithValue("@doctorId",doctorId);
                command.Parameters.AddWithValue("@appointmentTime",ApptDate);
                try
                {
                    using (SqlDataReader re = command.ExecuteReader())
                    {
                        if (re.HasRows)
                        {
                            while (re.Read())
                            {
                                Console.WriteLine($"{re[0]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("there are no rows to display");
                        }
                    }
                }
                catch (System.Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            }
            connection.Close();
        }
    }
    


}
