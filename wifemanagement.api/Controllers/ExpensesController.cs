using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using wmta.Infrustructure;
using wmta.domain;
using wmta.Repository;

namespace wifemanagement.api.Controllers
{
    [RoutePrefix("api/Expenses")]
    public class ExpensesController : ApiController
    {
        private readonly IExpenseRepository _expenseRepository;
      
        public ExpensesController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        

        // GET: api/Expenses
        public IQueryable<Expense> Get()
        {
            //var x = _expenseRepository.All();
            return _expenseRepository.All();
        }

        // GET: api/Expenses/5
        [ResponseType(typeof(Expense))]
        public IHttpActionResult Get(int id)
        {
            Expense expense = _expenseRepository.GetByID(id);
            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT: api/Expenses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _expenseRepository.Update(expense);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(ModelState);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Expenses
        [ResponseType(typeof(Expense))]
        public IHttpActionResult Post(Expense expense)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _expenseRepository.Insert(expense);

            return CreatedAtRoute("DefaultApi", new { id = expense.id }, expense);
        }

        // DELETE: api/Expenses/5
        [ResponseType(typeof(Expense))]
        public IHttpActionResult Delete(int id)
        {
            Expense expense = _expenseRepository.GetByID(id);
            if (expense == null)
            {
                return NotFound();
            }
            else
            _expenseRepository.delete(id);

            return Ok(expense);
        }

        
    }
}