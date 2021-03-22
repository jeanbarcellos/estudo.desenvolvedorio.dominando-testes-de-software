using NerdStore.Core.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace NerdStore.Vendas.Data.Context
{
    public class VendasContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public VendasContext(DbContextOptions<VendasContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;
        }

        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;

            if (sucesso) await _mediator.PublicarEventos(this);

            return sucesso;
        }
    }
}