using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactBook.Controllers
{
    public class ContactBookController : Controller
    {
        private readonly ContactBookContext _context;

        public ContactBookController(ContactBookContext context)
        {
            this._context = context;
        }

        // GET: /ContactBook
        public async Task<IActionResult> Index()
        {
            return View(_context.Contacts);
        }



        // GET: /ContactBook/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contacts.SingleOrDefault(m => m.ID == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        //POST /ContactBook/Edit/{ID}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("name,age,gender,email,favoriteBeer")] Contact contact)
        {
            if (id == 0)
            {
                return NotFound();
            } else
            {
                contact.ID = id;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException)
                {
                    if (!isExistsContact(id))
                    {
                        return NotFound();
                    } else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }
            
            return View(contact);
        }

        // Valida si Contacto existe
        private bool isExistsContact(int id)
        {
            return _context.Contacts.Any(c => c.ID == id);
        }

        // GET: /ContactBook/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = _context.Contacts.SingleOrDefault(m => m.ID == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        //GET /ContactBook/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //POST /ContactBook/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,age,gender,email,favoriteBeer")] Contact contact)
        { 
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            return View(contact);
        }


    }
}

