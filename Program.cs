// See https://aka.ms/new-console-template for more information
using ConsoleAppTOConnectTODB;

class Program
{
    static void Main(string[] args)
    {
        PatientRepository patientRepository = new PatientRepository();
        //patientRepository.CreatePatient("parshuRam","M",24);
        //patientRepository.CreateDoctor("Dr Chadda", "Orthopediac");
        //DateTime times = new DateTime(2024,02,29,13,05,00);
        //patientRepository.DoctorPatientAppointment_Create(3,3, times);
        patientRepository.Patient_Update(25, "Mobile", 05, "O");
    }
}

