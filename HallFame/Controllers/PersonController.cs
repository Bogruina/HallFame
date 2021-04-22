﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HallOfFame.Models;
using AppContext = HallOfFame.Models.AppContext;

namespace HallOfFame.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppContext _context;

        public PersonController(AppContext context)
        {
            _context = context;
        }

        // GET: api/v1/persons Получение всех сотрудников
        [Route("~/api/v1/Person")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return Ok(await _context.Persons.ToListAsync());
        }

        // GET: api/v1/person/id Получить конкретного сотрудника
        [Microsoft.AspNetCore.Mvc.HttpGet ("{id}")]
        public async Task<ActionResult<Person>> GetPerson(long id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                errors["Others"] = "Сущности с таким id не существует";
                return NotFound(errors);
            }

            return Ok(person);
        }

        // PUT: api/v1/person/id Обновление данных конкретного сотрудника
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<IActionResult> PutPerson(long id, Person updatedPerson)
        {
            if (id != updatedPerson.Id)
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                errors["Others"] = "Такого id не существует";
                return BadRequest(errors);
            }


            var person = await _context.Persons.FindAsync(id);

            _context.Entry(person).CurrentValues.SetValues(updatedPerson);

            var personSkills = person.Skills.ToList();

            foreach (var personSkill in personSkills)
            {
                var skill = updatedPerson.Skills.SingleOrDefault(s => s.Name == personSkill.Name);
                if (skill != null)
                {
                    _context.Entry(personSkill).CurrentValues.SetValues(skill);
                }
            }

            foreach (var skill in updatedPerson.Skills)
            {
                if (personSkills.All(s => s.Name != skill.Name))
                {
                    person.Skills.Add(skill);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!PersonExists(id))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    errors["Others"] = "Сущности с таким id не существует";
                    return NotFound(errors);
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return Ok(person);
        }

        // POST: api/v1/person Добавление нового сотрудника
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        // DELETE: api/v1/person/id  Удаление существующего сотрудника
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(long id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                errors["Others"] = "Сущности с таким id не существует";
                return NotFound(errors);
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        private bool PersonExists(long id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}
