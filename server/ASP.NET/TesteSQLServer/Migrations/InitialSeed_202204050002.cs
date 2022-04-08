using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSQLServer.Models;

namespace TesteSQLServer.Migrations
{
    [Migration(202204050002)]
    public class InitialSeed_202204050002 : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("payments")
                .Row(new
                {
                   id = Guid.NewGuid(),
                   name = "Pix"
                });

            Insert.IntoTable("products")
                .Row(new Dictionary<string, object>{
                    { "id", Guid.NewGuid()},
                    { "name", "Celular 2077" },
                    { "description", "celular de última geração, com inteligência, ultra desempenho, 32gb ram, 2TB de armazenamento SSD." },
                    { "category", "celulares" },
                    { "image-url", "celular2077.png" },
                    { "price", 7800.00m },
                })
                .Row(new Dictionary<string, object>{
                    { "id", Guid.NewGuid()},
                    { "name", "Teclado mecânico RGB X55" },
                    { "description", "Conforto, durabilidade e qualidade com mais de 15 combinações de cores e programa de personalização." },
                    { "category", "acessorios" },
                    { "image-url", "tecladoX55.png" },
                    { "price", 799.00m },
                })
                .Row(new Dictionary<string, object>{
                    { "id", Guid.NewGuid()},
                    { "name", "Computador C89 com Ryzen 9 5500X, RTX 3090" },
                    { "description", "Computador última geração com ryzen 9 5500x, uma RTX 3090, 128gb ram, 5TB de armazenamento SSD" },
                    { "category", "computadores" },
                    { "image-url", "pcC89.png" },
                    { "price", 18000.00m },
                })
                .Row(new Dictionary<string, object>{
                    { "id", Guid.NewGuid()},
                    { "name", "Monitor Gamer 27 360hz" },
                    { "description", "Monitores 27 polegadas com 360hz free sync, 0.2ms de tempo de resposta, resolução 4K." },
                    { "category", "monitores" },
                    { "image-url", "monitoresGame27.png" },
                    { "price", 7800.00m },
                })
                .Row(new Dictionary<string, object>{
                    { "id", Guid.NewGuid()},
                    { "name", "Placa de Video" },
                    { "description", "placa de video rtx 3090." },
                    { "category", "componentes" },
                    { "image-url", "placadevideo.png" },
                    { "price", 9000.00m },
                });
        }

        public override void Down()
        {
            Delete.FromTable("products");
            Delete.FromTable("payments");
        }
    }
}
