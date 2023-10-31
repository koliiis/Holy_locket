﻿
using Holy_locket.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        public List<Doctors> doctors { get; set; }
        public DoctorRepository()
        {
            string fileName = "Doctors.json";
            string jsonString;
            using (StreamReader reader = new StreamReader(fileName))
            {
                jsonString = reader.ReadToEnd();
            }


            doctors = JsonSerializer.Deserialize<List<Doctors>>(jsonString);


        }
        public IEnumerable<Doctors> GetAll()
        {

            return doctors;
        }

        public Doctors GetById(int id)
        {
            return doctors[id];
        }

        public void Add(Doctors doctor)
        {
            doctors.Add(doctor);
            string fileName = "Doctors.json";
            string jsonString = JsonSerializer.Serialize(doctors);
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(jsonString);
            }
            return;
        }

        public void Delete(int id)
        {
            doctors.RemoveAt(id);
            string fileName = "Doctors.json";
            string jsonString = JsonSerializer.Serialize(doctors);
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(jsonString);
            }
            return;
        }

        public void Update(Doctors doctor, int id)
        {
            doctors[id] = doctor;
            string fileName = "Doctors.json";
            string jsonString = JsonSerializer.Serialize(doctors);
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(jsonString);
            }
            return;
        }
    }
}
