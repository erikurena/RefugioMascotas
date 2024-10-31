using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RefugioMascotas.Controllers;
using RefugioMascotas.dbContext;
using RefugioMascotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioMascotas.Controllers.Tests
{
    [TestClass()]
    public class EmpleadoesControllerTests
    {
        private readonly dbRefugioContext? _context;
        private EmpleadoesController _CtrlEmpleado;
        
        public EmpleadoesControllerTests(dbRefugioContext contexto, EmpleadoesController CtrlEmpleado)
        {
            _context = contexto;
            _CtrlEmpleado = CtrlEmpleado;
        }

        [TestMethod()]
        public async  Task CreateTest()
        {
            EmpleadoesController objEmpleado = new EmpleadoesController(_context);
            //arranque       
            var ModEmpleado = new Empleado
            {
                Nombre = "eri",
                Apellido = "ure",
                IdSexo = 1,
                Cargo = "Administrador",
                Telefono = "123321"
            };

            //actuar
             var a = objEmpleado.Create(ModEmpleado);

            //asercion
            var EmpleadoGuardado = await _context.empleados.FirstOrDefaultAsync(e => e.Nombre == "eri");
            Assert.IsNotNull(EmpleadoGuardado);
            Assert.AreEqual("ure", EmpleadoGuardado.Apellido);
            Assert.AreEqual(1, EmpleadoGuardado.IdSexo);
            Assert.AreEqual("Administrador",EmpleadoGuardado.Cargo);
            Assert.AreEqual("123321",EmpleadoGuardado.Telefono);
        }
    }
}