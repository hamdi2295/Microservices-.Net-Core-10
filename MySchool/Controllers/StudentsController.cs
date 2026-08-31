using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySchool.Application.Interface;
using MySchool.Application.Students;
using MySchool.Domain.DTOs.Request.Students;
using MySchool.Domain.Entities;
using MySchool.Features.Students;
using MySchool.Helpers;

namespace MySchool.Controllers
{
    [Route(StudentRoutes.Base)]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsUsecase _studentUsecase;

        public StudentsController(StudentsUsecase studentUsecase)
        {
            _studentUsecase = studentUsecase;
        }


        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var student = await _studentUsecase.GetStudentsById(id);

                return Ok(ApiResonseHelpers.Success(student, "Success"));
            }
            catch (Exception ex)
            {

                return ApiResonseHelpers.Error(
                    StatusCodes.Status500InternalServerError,
                    ex.Message.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(M_StudentRequest request)
        {
            try
            {
                await _studentUsecase.CreateStudent(request);

                return Ok(ApiResonseHelpers.Success("", "Success"));
            }
            catch (Exception ex)
            {
                return ApiResonseHelpers.Error(
                    StatusCodes.Status500InternalServerError,
                    ex.Message.ToString());
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(M_StudentRequest request)
        {
            try
            {
                await _studentUsecase.UpdateStudent(request);

                return Ok(ApiResonseHelpers.Success("", "Success"));
            }
            catch (Exception ex)
            {
                return ApiResonseHelpers.Error(
                    StatusCodes.Status500InternalServerError,
                    ex.Message.ToString());
            }
        }


        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _studentUsecase.DeleteAsync(id);

                return Ok(ApiResonseHelpers.Success("", "Success"));
            }
            catch (Exception ex)
            {

                return ApiResonseHelpers.Error(
                    StatusCodes.Status500InternalServerError,
                    ex.Message.ToString());
            }
        }
    }
}
