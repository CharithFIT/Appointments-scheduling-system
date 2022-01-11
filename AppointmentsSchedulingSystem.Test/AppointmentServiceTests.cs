using AppointmentsSchedulingSystem.Repository.Appointments;
using AppointmentsSchedulingSystem.Repository.Models;
using AppointmentsSchedulingSystem.Service.Appointments;
using AppointmentsSchedulingSystem.Service.Appointments.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppointmentsSchedulingSystem.Test
{
    [TestFixture]
    public class AppointmentServiceTests
    {
        [Test]
        public async Task When_CallGetAppointmentsAsync_ShouldReturnAppointments()
        {
            var data = new List<Appointment>
            {
                new Appointment {
                    CreationDate = DateTime.UtcNow, 
                    EndTime= DateTime.UtcNow.AddDays(1),
                    Person = new Person{
                        Email = "cmadu701@gmail.com",
                        Name = "Charith Madushanka",
                        PhoneNumber = "+6593838314",
                        Id = 2
                    },
                    PersonId = 2,
                    Id = 1,
                    StartTime = DateTime.UtcNow
                },
                new Appointment {
                    CreationDate = DateTime.UtcNow,
                    EndTime= DateTime.UtcNow.AddDays(3),
                    Person = new Person{
                        Email = "cmadu701q@gmail.com",
                        Name = "Charith Madushankaq",
                        PhoneNumber = "+6593838312",
                        Id = 3
                    },
                    PersonId = 3,
                    Id = 2,
                    StartTime = DateTime.UtcNow.AddDays(2)
                },
            };

            Mock<IAppointmentRepository>? mockAppointmentRepository = new Mock<IAppointmentRepository>();
            mockAppointmentRepository.Setup(c => c.GetAppintmentsAsync(CancellationToken.None)).Returns(Task.FromResult(data.ToList()));

            Mock<IMapper>? mockMapper = this.MockAutoMapper();

            var service = new AppointmentService(mockAppointmentRepository.Object, mockMapper.Object);
            var appointments = await service.GetAppointmentsAsync();

            Assert.AreEqual(2, appointments.Count);
            Assert.AreEqual(data[0].Person.Name, appointments[0].PersonName);
            Assert.AreEqual(data[0].CreationDate, appointments[0].CreationDate);
            Assert.AreEqual(data[0].Person.Email, appointments[0].Email);
            Assert.AreEqual(data[0].StartTime, appointments[0].StartDate);
            Assert.AreEqual(data[0].EndTime, appointments[0].EndDate);
        }

        private Mock<IMapper> MockAutoMapper()
        {
            Mock<IMapper>? mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<AppointmentDto>(It.IsAny<Appointment>()))
           .Returns((Appointment source) => new AppointmentDto
           {
               CreationDate = source.CreationDate,
               EndDate = source.EndTime,
               Email = source.Person.Email,
               PersonName = source.Person.Name,
               PhoneNumber = source.Person.PhoneNumber,
               StartDate = source.StartTime,
           });

            return mockMapper;
        }
    }
}
