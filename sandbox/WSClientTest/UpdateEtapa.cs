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
using WebService.Base.Enums;
using WebService.Request;
using WebService.Net;
using WebService.Response;


namespace sandbox
{



	/*
	 * @author pozzisan
	 * Classe baseada no exemplo Java do @antunesleo
	 */
    public class UpdateEtapa
    {
        /**
             * Seta os parâmetros para login (autenticação)
             * @return
             */
        public static LoginRequest GetLogin()
        {
            LoginRequest login = new LoginRequest
            {
                /**
                 * Substituir com as informações da sua base de dados
                 */
                User = "superuser @ brerp.com.br",
                Pass = "sua senha",
                ClientID = 1000000,
                RoleID = 1000000,
                WarehouseID = 5000025,
                OrgID = 5000000
            };
            return login;
        }

        /**
         * @return String com a url do servidor
         */
        public static String GetUrlBase()
        {
            //Sbustituir com o link da sua base de dados
            return "http://teste.devcoffee.com.br";
        }

        /**
         * Seta as configurações da conexão
         * @return classe contendo os parâmetros da conexão
         */
        public static WebServiceConnection GetClient()
        {
            WebServiceConnection client = new WebServiceConnection
            {
                Attempts = 3,
                Timeout = 5000,
                AttemptsTimeout = 5000,
                Url = GetUrlBase(),
                AppName = "Atualizando etapa da agenda"
            };
            return client;
        }


        public static void Main(String[] args)
        {
            //RecordID a ser marcado
            int recordID = 5000000;
            String flag = "Y";

            //Cria uma operação do tipo update (vamos inserir um BP no sistema)
            UpdateDataRequest updateEtapaAgenda = new UpdateDataRequest
            {
                WebServiceType = "SetZ_AgendaLinha",
                //Pega as informações de login
                Login = GetLogin(),
                RecordID = recordID
            };
            //Passa os dados do registro a ser inserido
            DataRow data = new DataRow();
            data.AddField("Z_Completa", flag);
            updateEtapaAgenda.DataRow = data;

            // Pega as inforamções da conexão
            WebServiceConnection client = GetClient();

            try
            {
                //Envia a operação, que nesse caso é um criar, e armazena a resposta enviada pelo server
                StandardResponse response = client.SendRequest(updateEtapaAgenda);

                Console.WriteLine("XML ENVIADO AO SERVIDOR\n");
                client.WriteRequest(Console.Out);
                Console.WriteLine();
                Console.WriteLine("XML DE RESPOSTA DO SERVIDOR\n");
                client.WriteResponse(Console.Out);
                Console.WriteLine();

                // Verifica se ocorreu algum erro ao executar a operação e exibe o erro
                if (response.Status == WebServiceResponseStatus.Error)
                {
                    Console.WriteLine(response.ErrorMessage);
                    Console.WriteLine(response.GetErrorType());
                }

                Console.WriteLine("--------------------------");
                Console.WriteLine("Web Service: UpdateEtapa");
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
