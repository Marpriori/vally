using System;
using System.Data.Entity.Migrations;
using ProjectVally.Domain.Entities;

namespace ProjectVally.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.ProjetoModeloContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.ProjetoModeloContext context)
        {

            context.Users.AddOrUpdate(
                u => u.Name,
                new User {
                    Name = "Guilherme",
                    Cpf = "000.000.000-00",
                    Mail = "gsvaldevieso@gmail.com",
                    Password = "Nada",
                    Enabled = true

                    });

            context.AccountKinds.AddOrUpdate(
                ak => ak.Description,
                new AccountKind { Description = "Conta Corrente" },
                new AccountKind { Description = "Poupan�a" },
                new AccountKind { Description = "Carteira" },
                new AccountKind { Description = "Cart�o" }
                );

            // context.EntryKinds.AddOrUpdate(
            //     ak => ak.EntryKindId,
            //     new EntryKind { EntryKindId = 1, OwnerId = 0, Description = "Receitas" },
            //new EntryKind { EntryKindId = 2, OwnerId = 1, Description = "Remunera��o" },
            //new EntryKind { EntryKindId = 3, OwnerId = 1, Description = "B�nus" },
            //new EntryKind { EntryKindId = 4, OwnerId = 1, Description = "Rendimentos" },
            //new EntryKind { EntryKindId = 5, OwnerId = 1, Description = "Outras rendas" },

            //   new EntryKind { EntryKindId = 6, Description = "Despesas" }
            //new EntryKind { EntryKindId = 7, OwnerId = 6, Description = "B�sicos" },
            //    new EntryKind { EntryKindId = 8, OwnerId = 7, Description = "Moradia" },
            //    new EntryKind { EntryKindId = 9, OwnerId = 7, Description = "Sa�de" },
            //    new EntryKind { EntryKindId = 10, OwnerId = 7, Description = "Educa��o" },
            //    new EntryKind { EntryKindId = 11, OwnerId = 7, Description = "Transporte" },
            //    new EntryKind { EntryKindId = 12, OwnerId = 7, Description = "Mercado" },
            //    new EntryKind { EntryKindId = 13, OwnerId = 7, Description = "Alimenta��o" },

            //new EntryKind { EntryKindId = 14, OwnerId = 6, Description = "Secund�rios" },
            //    new EntryKind { EntryKindId = 15, OwnerId = 14, Description = "TV/Internet/Telefone" },
            //    new EntryKind { EntryKindId = 16, OwnerId = 14, Description = "Despesas Banc�rias" },
            //    new EntryKind { EntryKindId = 17, OwnerId = 14, Description = "Lazer" },
            //    new EntryKind { EntryKindId = 18, OwnerId = 14, Description = "Compras" },
            //    new EntryKind { EntryKindId = 19, OwnerId = 14, Description = "Viagem" },
            //    new EntryKind { EntryKindId = 20, OwnerId = 14, Description = "Trabalho" },
            //    new EntryKind { EntryKindId = 21, OwnerId = 14, Description = "Impostos" },
            //    new EntryKind { EntryKindId = 22, OwnerId = 14, Description = "Servi�os" },
            //    new EntryKind { EntryKindId = 23, OwnerId = 14, Description = "Outros" },

            //new EntryKind { EntryKindId = 24, OwnerId = 6, Description = "Lan�amentos" },
            //    new EntryKind { EntryKindId = 25, OwnerId = 24, Description = "Transfer�ncia" },
            //    new EntryKind { EntryKindId = 26, OwnerId = 24, Description = "Pagamento cart�o" }
            //  );
        }
    }
}
