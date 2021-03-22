using NerdStore.Core.Data;
using System;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Domain
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterPedidoRascunhoPorClienteId(Guid clienteId);
        public void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);

        void AdicionarItem(PedidoItem pedidoItem);
    }
}
