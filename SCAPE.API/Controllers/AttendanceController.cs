using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCAPE.API.ActionsModels;
using SCAPE.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAPE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IMapper _mapper;

        public AttendanceController(IAttendanceService attendanceService,IMapper mapper)
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a Attendance from Web Service
        /// </summary>
        /// <param name="data">>Object in DTO (Data Transfer Object) Format with data of attendance</param>
        /// <returns>
        /// If insert is fail, return a "Code error",
        /// If insert is succesful, return a "Code status 200"
        /// </returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> addAttendance(AttendanceModel data)
        {
            string documentEmployee = data.documentEmployee;
            string type = data.type;
            DateTime date = data.dateTime;

            bool resultInsert = true;
            try
            {
                resultInsert = await _attendanceService.addAttendance(date, type, documentEmployee);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(resultInsert);
        }
    }
}
