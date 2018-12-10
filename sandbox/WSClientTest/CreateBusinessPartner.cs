/*****************************************************************************
* Produto: BrERP Plataforma Gestão Empresarial (http://brerp.com.br)         *
* Copyright (C) 2016  devCoffee Sistemas de Gestão Integrada                 *
*                                                                            *
* Este arquivo é parte do BrERP que é software livre; você pode              *
* redistribuí-lo e/ou modificá-lo sob os termos da Licença Pública Geral GNU,*
* conforme publicada pela Free Software Foundation; tanto a versão 2 da      *
* Licença como (a seu critério) qualquer versão mais nova.                   *
*                                                                            *
* A marca BrERP é propriedade da devCoffee Sistema de Gestão Integrada       *
* CNPJ 13.823.508/0001-31, processo registrado o INPI - Intituto Nacional de *
* Propriedade Intelectual número 909512558, portanto ao distribuir ou        *
* modificar este arquivo ou recompilá-lo, a marca BrERP não poderá ser       *
* utilizada, por ser tratar de propriedade da devCoffee Sistemas de Gestão   *
* Integrada conforme estabelecido na Lei n. 9.279/96.                        *
*                                                                            *
* Este programa é distribuído na expectativa de ser útil, mas SEM            *
* QUALQUER GARANTIA; sem mesmo a garantia implícita de                       *
* COMERCIALIZAÇÃO ou de ADEQUAÇÃO A QUALQUER PROPÓSITO EM                    *
* PARTICULAR. Consulte a Licença Pública Geral GNU para obter mais           *
* detalhes.                                                                  *
*                                                                            *
* Você deve ter recebido uma cópia da Licença Pública Geral GNU              *
* junto com este programa; se não, escreva para a Free Software              *
* Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA                   *
* 02111-1307, USA  ou para devCoffee Sistemas de Gestão Integrada,           *
* Rua Paulo Rebessi 665 - Cidade Jardim - Leme/SP.                           *
 ****************************************************************************/

using System;
using WebService.Base;
using WebService.Request;
using WebService.Response;
using WebService.Net;
using WebService.Base.Enums;

namespace sandbox
{
    /*
     * @author pozzisan
     * Classe baseada no exemplo Java do @antunesleo
     */
    class CreateBusinessPartner
    {
        public static LoginRequest GetLogin()
        {
            LoginRequest login = new LoginRequest
            {

                //Subistitua com suas informações

                User = "superuser @ brerp.com.br",
                Pass = "cafe123",
                ClientID = 1000000,
                RoleID = 1000000,
                WarehouseID = 5000007,
                OrgID = 5000003,
            };
            return login;
        }

        public static string GetUrlBase()
        {
            return "https://teste.brerp.com.br/";
        }


        public static WebServiceConnection GetClient()
        {
            WebServiceConnection client = new WebServiceConnection
            {
                Attempts = 3,
                Timeout = 5000,
                AttemptsTimeout = 5000,
                Url = GetUrlBase(),
                AppName = "Atualizando parceiro de negócio",
            };
            return client;
        }

        public static void Main(string[] args)
        {
            //Cria uma operação do tipo create (vamos inserir um BP no sistema)
            CreateDataRequest createBpartner = new CreateDataRequest
            {
                WebServiceType = "CreateBPartnerTest",
                //Pega as informações de login
                Login = GetLogin()
            };

            //Passa os dados do registro a ser inserido
            DataRow data = new DataRow();
            data.AddField("Value", "TESTING3");
            data.AddField("Name", "Pedro Pozzi Ferreira");
            data.AddField("Name2", "pozzisan");
            data.AddField("Description", "Criado por brerpwsc-dotnet: " + DateTime.Now);
            data.AddField("TaxID", null);
            data.AddField("Logo_ID", null);
            createBpartner.DataRow = data;
            // Pega as inforamções da conexão
            WebServiceConnection client = GetClient();

            try
            {
                //Envia a operação, que nesse caso é um criar, e armazena a resposta enviada pelo server
                StandardResponse response = client.SendRequest(createBpartner);

                Console.WriteLine("XML Enviado ao Servidor");
                client.WriteRequest(Console.Out);
                Console.WriteLine();
                Console.WriteLine("XML De Resposta Do Servidor\n");
                client.WriteResponse(Console.Out);
                Console.WriteLine();

                // Verifica se ocorreu algum erro ao executar a operação e exibe o erro
                if (response.Status == WebServiceResponseStatus.Error)
                {
                    Console.WriteLine(response.ErrorMessage);
                    Console.WriteLine(response.GetErrorType());
                }

                Console.WriteLine("--------------------------");
                Console.WriteLine("Web Service: CreateBPartnerTest");
                Console.WriteLine("Attempts: " + client.AttemptsRequest);
                Console.WriteLine("Time: " + client.TimeRequest);
                Console.WriteLine("--------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    }
