using Cwiczenie6.Data;
using Cwiczenie6.DTOs;
using Cwiczenie6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Sockets;

namespace Cwiczenie6.Services
{
    public class DoctorService : IDoctorService
    {
        public readonly DataContext _context;
        public DoctorService(DataContext context)
        {
            _context = context;
        }

        public async Task AddDoctor(DoctorDTO doctorDTO)
        {
            var maxId = await GetMaxClientId();

            var doctor = new Doctor
            {
                //IdDoctor = maxId + 1,
                FirstName = doctorDTO.FirstName,
                LastName = doctorDTO.LastName,
                Email = doctorDTO.Email,
            };
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task EditDoctor(int idDoctor, DoctorDTO doctor)
        {
            var doctorExisiting = await _context.Doctors.FirstOrDefaultAsync(e => e.IdDoctor == idDoctor);
            doctorExisiting.FirstName = doctor.FirstName;
            doctorExisiting.LastName = doctor.LastName;
            doctorExisiting.Email = doctor.Email;
            await _context.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int idDoctor)
        {
            return await _context.Doctors.FirstOrDefaultAsync(e => e.IdDoctor == idDoctor);
        }

        public async Task<Doctor> GetDoctorByNameAndSurnameAndEmailAsync(DoctorDTO doctorDTO)
        {
            return await _context.Doctors.FirstOrDefaultAsync(e => e.FirstName == doctorDTO.FirstName && e.LastName == doctorDTO.LastName && e.Email == doctorDTO.Email);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _context.Doctors
                .Include(e => e.Prescriptions)
                .ThenInclude(e => e.Patient)
                .ToListAsync();
        }

        private async Task<int> GetMaxClientId()
        {
            int maxId = await _context.Doctors.MaxAsync(c => c.IdDoctor);
            return maxId;
        }
    }
}
