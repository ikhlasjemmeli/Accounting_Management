using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using WebApplication2.data;
using WebApplication2.Models;
using WebApplication2.Models.Domain;

namespace WebApplication2.Controllers
{
    public class Facturecontroller : Controller
    {
        public readonly MVCDemoDBcontext mvcDemoDBcontext;
        public Facturecontroller(MVCDemoDBcontext mvcDemoDBcontext) 
        { 
            this.mvcDemoDBcontext = mvcDemoDBcontext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
          var facture = await mvcDemoDBcontext.Facture.ToListAsync();
            return View(facture);
            
        }

		public async Task<IActionResult> Contact()
		{
			var facture = await mvcDemoDBcontext.Facture.ToListAsync();
			return View(facture);

		}



		[HttpGet] 
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFacture AddFactureRequest)
        {

            var facture = new Facture()
            {

                Id = Guid.NewGuid(),
                Name = AddFactureRequest.Name,
                Numfac = AddFactureRequest.Numfac,
                Numclient = AddFactureRequest.Numclient,
                StartDate = AddFactureRequest.StartDate,
                EndDate = AddFactureRequest.EndDate,
                Adresse = AddFactureRequest.Adresse,
                CodePostal = AddFactureRequest.CodePostal,
                Pays = AddFactureRequest.Pays,
                Rue = AddFactureRequest.Rue,
                Typ = AddFactureRequest.Typ,
                Total= AddFactureRequest.Total

            };
            await mvcDemoDBcontext.Facture.AddAsync(facture);
            await mvcDemoDBcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddConf()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddConf(AddFacture AddFactureRequest)
        {

            var facture = new Facture()
            {

                Id = Guid.NewGuid(),
                Name = AddFactureRequest.Name,
                Numfac = AddFactureRequest.Numfac,
                Numclient = AddFactureRequest.Numclient,
                StartDate = AddFactureRequest.StartDate,
                EndDate = AddFactureRequest.EndDate,
                Adresse = AddFactureRequest.Adresse,
                CodePostal = AddFactureRequest.CodePostal,
                Pays = AddFactureRequest.Pays,
                Rue = AddFactureRequest.Rue,

				  Typ = AddFactureRequest.Typ,
				Total = AddFactureRequest.Total

			};
            await mvcDemoDBcontext.Facture.AddAsync(facture);
            await mvcDemoDBcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddLivr()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLivr(AddFacture AddFactureRequest)
        {

            var facture = new Facture()
            {

                Id = Guid.NewGuid(),
                Name = AddFactureRequest.Name,
                Numfac = AddFactureRequest.Numfac,
                Numclient = AddFactureRequest.Numclient,
                StartDate = AddFactureRequest.StartDate,
                EndDate = AddFactureRequest.EndDate,
                Adresse = AddFactureRequest.Adresse,
                CodePostal = AddFactureRequest.CodePostal,
                Pays = AddFactureRequest.Pays,
                Rue = AddFactureRequest.Rue,
				Typ = AddFactureRequest.Typ,
				Total = AddFactureRequest.Total

			};
            await mvcDemoDBcontext.Facture.AddAsync(facture);
            await mvcDemoDBcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddOff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOff(AddFacture AddFactureRequest)
        {

            var facture = new Facture()
            {

                Id = Guid.NewGuid(),
                Name = AddFactureRequest.Name,
                Numfac = AddFactureRequest.Numfac,
                Numclient = AddFactureRequest.Numclient,
                StartDate = AddFactureRequest.StartDate,
                EndDate = AddFactureRequest.EndDate,
                Adresse = AddFactureRequest.Adresse,
                CodePostal = AddFactureRequest.CodePostal,
                Pays = AddFactureRequest.Pays,
                Rue = AddFactureRequest.Rue,
				Typ = AddFactureRequest.Typ,
				Total = AddFactureRequest.Total

			};
            await mvcDemoDBcontext.Facture.AddAsync(facture);
            await mvcDemoDBcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var facture = await mvcDemoDBcontext.Facture.FirstOrDefaultAsync(x =>x.Id==id);
    
            if (facture != null)
            {
                var ViewModel = new UpdateFacture()
                {
                    Id = facture.Id,
                    Name = facture.Name,
                    Numfac = facture.Numfac,
                    Numclient = facture.Numclient,
                    StartDate = facture.StartDate,
                    EndDate = facture.EndDate,
                    Adresse = facture.Adresse,
                    CodePostal = facture.CodePostal,
                    Pays = facture.Pays,
                    Rue = facture.Rue,
					Typ = facture.Typ,
					Total = facture.Total

				};
                return await Task.Run(() => View("View",ViewModel));
            }
          
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateFacture model)
        {
            var facture = await mvcDemoDBcontext.Facture.FindAsync(model.Id);
            if (facture != null)
            {
                facture.Name = model.Name;
                facture.Numfac = model.Numfac;
                facture.Numclient = model.Numclient;
                facture.StartDate = model.StartDate;
                facture.EndDate = model.EndDate;
                facture.Adresse = model.Adresse;
                facture.CodePostal = model.CodePostal;
                facture.Pays = model.Pays;
                facture.Rue = model.Rue;
                facture.Typ = model.Typ;
                facture.Total = model.Total;


				await mvcDemoDBcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


   
        [HttpPost]

        public async Task<IActionResult> Delete(UpdateFacture model)
        {
            var facture = await mvcDemoDBcontext.Facture.FindAsync(model.Id);

            if (facture != null)
            {
                mvcDemoDBcontext.Facture.Remove(facture);
                await mvcDemoDBcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


      

    }
}
