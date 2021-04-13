
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using crud_apirest_agenda.Data;
using crud_apirest_agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_apirest_agenda.Controllers{

    [ApiController]
    [Route("/Contatos")]
    public class ContatoController : ControllerBase{
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Contato>>> Get([FromServices] DataContext context){
            var contatos = await context.Contato.ToListAsync();
            return contatos;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Contato>> GetById([FromServices] DataContext context, int id){
            var contatos = await context.Contato.SingleOrDefaultAsync(x => x.id == id);

            if(contatos == null) return NotFound();

            return contatos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Contato>> Post([FromServices] DataContext context, [FromBody] Contato model){
            if(ModelState.IsValid){
                context.Contato.Add(model);
                await context.SaveChangesAsync();
                return model;
            }else{
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Contato>> Put([FromServices] DataContext context, [FromBody] Contato model, int id){
            if(ModelState.IsValid){
                var contato = await context.Contato.SingleOrDefaultAsync(x => x.id == id);

                if(contato == null) return NotFound();

                contato.nome = model.nome;
                contato.email = model.email;
                contato.fone = model.fone;

                context.SaveChanges();

                return await context.Contato.SingleOrDefaultAsync(x => x.id == id);
            }else{
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Contato>> Delete([FromServices] DataContext context, int id){
            if(ModelState.IsValid){
                var contato = await context.Contato.SingleOrDefaultAsync(x => x.id == id);

                if(contato == null) return NotFound();

                context.Contato.Remove(contato);

                context.SaveChanges();

                return await context.Contato.SingleOrDefaultAsync(x => x.id == id);
            }else{
                return BadRequest(ModelState);
            }
        }

    }


}