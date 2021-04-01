using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class BookController : ApiController
    {
        DatabaseContext db = new DatabaseContext();
        public IEnumerable<Books> GetBooks()
        {
            return db.Books.ToList();
        }

        public Books GetBook(int id)
        {
            return db.Books.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddBooks(Books model)
        {
            try
            {
                db.Books.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateBooks(int id, Books model)
        {
            try
            {
                if (id == model.id)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }


        public HttpResponseMessage DeleteUser(int id)
        {
            Books td = db.Books.Find(id);
            if (td != null)
            {
                db.Books.Remove(td);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return response;
            }
        }
    }
}
