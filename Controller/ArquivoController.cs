using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    public class ArquivoController
    {

      
        public void GerarArquivoXML()
        {
            
            string arquivoXML = @"C:\Temp\Pessoas.xml";

            
            ClienteController controller = new ClienteController();
            List<Cliente> lstPessoas = controller.Listar();

            
            var docXML = new XDocument(new XElement("Clientes",
                lstPessoas.Select(x => new XElement("Cliente",
                                       new XAttribute("IdCliente", x.IdCliente),
                                       new XAttribute("Nome", x.Nome),
                                       new XAttribute("Cpf", x.Cpf),
                                       new XAttribute("Email", x.Email)))));

           
            docXML.Save(arquivoXML);
        }

       
        public void GerarArquivoCSV()
        {
            
            string arquivoCSV = @"C:\Temp\Pessoas.csv";

           
            using (StreamWriter writer = new StreamWriter(arquivoCSV, false, Encoding.UTF8))
            {
                
                writer.WriteLine("IDCLIENTE;NOME;CPF;EMAIL;");

                
                ClienteController controller = new ClienteController();

                
                foreach (var item in controller.Listar())
                {
                    
                    writer.WriteLine($"{item.IdCliente};{item.Nome};{item.Cpf};{item.Email};");
                }
            }
        }
    }
}
