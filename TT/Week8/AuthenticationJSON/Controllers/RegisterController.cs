using AuthenticationJSON.DTO;
using AuthenticationJSON.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AuthenticationJSON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] JsonElement request)
        {
            if (!request.TryGetProperty("role", out var roleElement))
                return BadRequest("Role is required.");

            var role = roleElement.GetString()?.ToLower();

            if (string.IsNullOrEmpty(role))
                return BadRequest("Invalid role.");

            switch (role)
            {
                case "seeker":
                    var seekerDto = JsonSerializer.Deserialize<RegisterSeekerDto>(request.GetRawText());
                    var seekerValidation = ValidateSeekerDto(seekerDto);
                    if (seekerValidation != null) return seekerValidation;
                    var seeker = MapSeeker(seekerDto);
                    return Ok(new { Message = "Seeker registered", User = seeker.User.Email });

                case "employer":
                    var employerDto = JsonSerializer.Deserialize<RegisterEmployerDto>(request.ToString());
                    var employerValidation = ValidateEmployerDto(employerDto);
                    if (employerValidation != null) return employerValidation;
                    var employer = MapEmployer(employerDto);
                    return Ok(new { Message = "Employer registered", User = employer.User.Email });

                default:
                    return BadRequest("Unsupported role.");
            }
        }

        // Manual validation (can be replaced with FluentValidation)
        private IActionResult ValidateSeekerDto(RegisterSeekerDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Education))
                return BadRequest("Invalid seeker data.");
            return null;
        }

        private IActionResult ValidateEmployerDto(RegisterEmployerDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Company))
                return BadRequest("Invalid employer data.");
            return null;
        }

        // Mapping logic to domain entities
        private Seeker MapSeeker(RegisterSeekerDto dto)
        {
            return new Seeker
            {
                Education = dto.Education,
                Age = dto.Age,
                User = new User
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    Password = dto.Password,
                    Role = dto.Role
                }
            };
        }

        private Employer MapEmployer(RegisterEmployerDto dto)
        {
            return new Employer
            {
                Company = dto.Company,
                Designation = dto.Designation,
                User = new User
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    Password = dto.Password,
                    Role = dto.Role
                }
            };
        }
    }
}
