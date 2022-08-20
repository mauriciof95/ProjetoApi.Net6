using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Order : BaseEntity
    {
        [Required(ErrorMessage = "Informe a data do pedido.")]
        public DateTime order_date { get; set; }

        [Required(ErrorMessage = "Informe o status do pedido.")]
        public string order_status { get; set; }

        [Required(ErrorMessage = "Selecione o cliente.")]
        public long client_id { get; set; }

        [Required(ErrorMessage = "Selecione o vendedor.")]
        public long seller_id { get; set; }



        public Client cliente { get; set; }

        public Seller vendedor { get; set; }

        public ICollection<OrderItem> pedido_itens { get; set; }
    }
}
