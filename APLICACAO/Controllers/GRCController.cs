using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APLICACAO.Controllers
{


    public class GRCController : Controller
    {

        //Aqui podes deixar assim por defeito  ou então pode ser null- > APLICACAOEntities2 dc =  null
        //A tua classe do model agora tem dois construtores, um que leva connection string como parametro (new APLICACAOEntities2(connectionString1)) e o original (new APLICACAOEntities2())

       
        APLICACAOEntities2 dc = new APLICACAOEntities2();

     

        public ActionResult GRC()
        {                
           
            ViewBag.Message = "Your contact page.";

            return View();
            
        }

      

        //NOTA TA: Aqui estou a Criar o Controlo para a Lista de Clientes da view LISTA_CLIENTES, com os campos de pesquisa Numero, Nome e NIF
        public ActionResult LISTA_CLIENTES(string Pesquisa_numero_LISTA_CLIENTES = "", string Pesquisa_nome_LISTA_CLIENTES = "", string Pesquisa_nif_LISTA_CLIENTES = "")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);


            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);

                var q = zz.View_GRC_TAB_CL.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa_numero_LISTA_CLIENTES))
                q = q.Where(c => c.no.Contains(Pesquisa_numero_LISTA_CLIENTES));
            if (!string.IsNullOrEmpty(Pesquisa_nome_LISTA_CLIENTES))
                q = q.Where(c => c.nome.Contains(Pesquisa_nome_LISTA_CLIENTES));
            if (!string.IsNullOrEmpty(Pesquisa_nif_LISTA_CLIENTES))
                q = q.Where(c => c.ncont.Contains(Pesquisa_nif_LISTA_CLIENTES));

            return View(q.ToList());
            
           
        }
        public ActionResult VER_CLIENTE(string NUM_CLIENT_SELECT)
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);


            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);

            var q = zz.View_GRC_TAB_CL.AsQueryable();
            if (!string.IsNullOrEmpty(NUM_CLIENT_SELECT))
                q = q.Where(c => c.no.Equals(NUM_CLIENT_SELECT));

            return View(q.ToList());

        }

        
        public ActionResult PROC_GRC_VER_CLIENTE_Grid3_Result(string NUM_CLIENT_SELECT)
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);


            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);

            var d = zz.PROC_GRC_VER_CLIENTE_Grid3(NUM_CLIENT_SELECT).AsQueryable();
            //if (!string.IsNullOrEmpty(NUM_CLIENT_SELECT))
            //    d = d.Where(c => c.no.Equals(NUM_CLIENT_SELECT));


            return PartialView(d.ToList());
        }


        public ActionResult EVOL_PMR_PER(string Pesquisa_no = "", string Pesquisa_nome = "", string Filtro_por_Evolucao_do_PMR = "", string Filtro_Zona = "", string Filtro_Tipo_Pagamento = "", string Filtro_Comercial = "", string Colunas_Opcao = "trimestral")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);


            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);


            List<string> petList = new List<string>();
            petList.Add("");
            petList.Add("Apenas Clientes cujo PMR SUBIU por compração com N-1");
            petList.Add("Apenas Clientes cujo PMR DESCEU por compração com N-1");
            ViewData["Filtro_por_Evolucao_do_PMR"] = new SelectList(petList);
            
            
            List<string> petList1 = new List<string>();
            petList1.Add("trimestral");
            petList1.Add("mensal");
            ViewData["Colunas_Opcao"] = new SelectList(petList1);
            var opcaocolunas = Colunas_Opcao;
            ViewBag.opcaocolunas = opcaocolunas;

       


            //Nota TA: Opção A
            //var f = dc.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).ToList().Select(x => x.Comercial).Distinct();
            //SelectList Comercial = new SelectList(f, "Comercial");
            //ViewBag.Comercial1 = Comercial;


            //var d = dc.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).ToList().Select(x => x.Zona).Distinct();
            //SelectList Zona = new SelectList(d, "Zona");
            //ViewBag.Zona1 = Zona;


            //var e = dc.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).ToList().Select(x => x.Tipo_Pagamento).Distinct();
            //SelectList Tipo_Pagamento = new SelectList(e, "Tipo_Pagamento");
            //ViewBag.Tipo_Pagamento1 = Tipo_Pagamento;

            //Nota TA: Opção B
            var g = zz.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).Where(c => c.Distinct_Zona == 1).Select(c => c.Zona).ToList();
            SelectList Zona1 = new SelectList(g, "Zona");
            ViewBag.Zona1 = Zona1;

            var h = zz.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).Where(c => c.Distinct_Comercial == 1).Select(c => c.Comercial).ToList();
            SelectList Comercial1 = new SelectList(h, "Comercial");
            ViewBag.Comercial1 = Comercial1;

            var i = zz.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).Where(c => c.Distinct_Tipo_Pagamento == 1).Select(c => c.Tipo_Pagamento).ToList();
            SelectList Tipo_Pagamento1 = new SelectList(i, "Tipo_Pagamento");
            ViewBag.Tipo_Pagamento1 = Tipo_Pagamento1;

            var opcaocoluna1 = Colunas_Opcao;
            ViewBag.opcaocoluna1 = opcaocoluna1;



            var z = zz.PROC_GRC_EVOL_PMR(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa_no))
                z = z.Where(c => c.no.Contains(Pesquisa_no));
            if (!string.IsNullOrEmpty(Pesquisa_nome))
                z = z.Where(c => c.nome.Contains(Pesquisa_nome));
            if (!string.IsNullOrEmpty(Filtro_por_Evolucao_do_PMR))
                z = z.Where(c => c.Filtro_por_Evolucao_do_PMR.Equals(Filtro_por_Evolucao_do_PMR));
            if (!string.IsNullOrEmpty(Filtro_Comercial))
                z = z.Where(c => c.Comercial.Equals(Filtro_Comercial));
            if (!string.IsNullOrEmpty(Filtro_Zona))
                z = z.Where(c => c.Zona.Equals(Filtro_Zona));
            if (!string.IsNullOrEmpty(Filtro_Tipo_Pagamento))
                z = z.Where(c => c.Tipo_Pagamento.Equals(Filtro_Tipo_Pagamento));
                         
            return View(z.ToList());

        }


        public ActionResult IDADE_SALDOS(string Pesquisa_no = "", string Pesquisa_nome = "", string Filtro_por_Evolucao_do_PMR = "", string Filtro_Zona = "", string Filtro_Tipo_Pagamento = "", string Filtro_Comercial = "", string Colunas_Opcao_Numero = "4", string Colunas_Opcao_Ve_ANTE = "Não", string Colunas_Opcao_Sld_Negativo = "Não", string Pesquisa_User = "tjalmeida")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);
            
            List<string> petList = new List<string>();
            petList.Add("");
            petList.Add("Apenas Clientes cujo PMR SUBIU por compração com N-1");
            petList.Add("Apenas Clientes cujo PMR DESCEU por compração com N-1");
            ViewData["Filtro_por_Evolucao_do_PMR"] = new SelectList(petList);


            List<int> petList1 = new List<int>(new int[] {1,2,3,4,5,6,7,8,9,10,11,12 });
            ViewData["Colunas_Opcao_Numero"] = new SelectList(petList1);
            var opcaocolunas = Colunas_Opcao_Numero;
            ViewData["opcaocolunas"] = opcaocolunas;

            List<string> petList2 = new List<string>();
            petList2.Add("Não");
            petList2.Add("Sim");
            ViewData["Colunas_Opcao_Ve_ANTE"] = new SelectList(petList2);
            var opcaocolunas2 = Colunas_Opcao_Ve_ANTE;
            ViewData["opcaocolunas2"] = opcaocolunas2;


            List<string> petList3 = new List<string>();
            petList3.Add("tjalmeida");
            ViewData["Pesquisa_User"] = new SelectList(petList3);


            List<string> petList4 = new List<string>();
            petList4.Add("Não");
            petList4.Add("Sim");
            ViewData["Colunas_Opcao_Sld_Negativo"] = new SelectList(petList4);
            var opcaocolunas4 = Colunas_Opcao_Sld_Negativo;
            ViewData["opcaocolunas4"] = opcaocolunas4;

       


            //Nota TA: Opção A
            //var f = dc.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).ToList().Select(x => x.Comercial).Distinct();
            //SelectList Comercial = new SelectList(f, "Comercial");
            //ViewBag.Comercial1 = Comercial;


            //var d = dc.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).ToList().Select(x => x.Zona).Distinct();
            //SelectList Zona = new SelectList(d, "Zona");
            //ViewBag.Zona1 = Zona;


            //var e = dc.PROC_GRC_EVOL_PMR_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).ToList().Select(x => x.Tipo_Pagamento).Distinct();
            //SelectList Tipo_Pagamento = new SelectList(e, "Tipo_Pagamento");
            //ViewBag.Tipo_Pagamento1 = Tipo_Pagamento;

            //Nota TA: Opção B
            var g = zz.PROC_GRC_IDADE_SALDOS_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).Where(c => c.Distinct_Zona == 1).Select(c => c.Zona).ToList();
            SelectList Zona1 = new SelectList(g, "Zona");
            ViewData["Zona1"] = Zona1;

            var h = zz.PROC_GRC_IDADE_SALDOS_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).Where(c => c.Distinct_Comercial == 1).Select(c => c.Comercial).ToList();
            SelectList Comercial1 = new SelectList(h, "Comercial");
            ViewData["Comercial1"] = Comercial1;

            var i = zz.PROC_GRC_IDADE_SALDOS_PESQUISA(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento).Where(c => c.Distinct_Tipo_Pagamento == 1).Select(c => c.Tipo_Pagamento).ToList();
            SelectList Tipo_Pagamento1 = new SelectList(i, "Tipo_Pagamento");
            ViewData["Tipo_Pagamento1"] = Tipo_Pagamento1;

            //var opcaocoluna1 = Colunas_Opcao_Numero;
            //ViewBag.opcaocoluna1 = opcaocoluna1;

            //Nota TA: Aqui defino as dados de dias para os cabeçahos das colunas da Grelha de View Idade de Saldos

            var Interv_01 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User ).Select(c => c.Interv_01).First();
            ViewData["Interv_01_dias"] = Interv_01;
            var Interv_02 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_02).First();
            ViewData["Interv_02_dias"] = Interv_02;
            var Interv_03 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_03).First();
            ViewData["Interv_03_dias"] = Interv_03;
            var Interv_04 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_04).First();
            ViewData["Interv_04_dias"] = Interv_04;
            var Interv_05 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_05).First();
            ViewData["Interv_05_dias"] = Interv_05;
            var Interv_06 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_06).First();
            ViewData["Interv_06_dias"] = Interv_06;
            var Interv_07 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_07).First();
            ViewData["Interv_07_dias"] = Interv_07;
            var Interv_08 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_08).First();
            ViewData["Interv_08_dias"] = Interv_08;
            var Interv_09 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_09).First();
            ViewData["Interv_09_dias"] = Interv_09;
            var Interv_10 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_10).First();
            ViewData["Interv_10_dias"] = Interv_10;
            var Interv_11 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_11).First();
            ViewData["Interv_11_dias"] = Interv_11;
            var Interv_12 = zz.PROC_GRC_CONF_IDADE_SALDOS(Pesquisa_User).Select(c => c.Interv_12).First();
            ViewData["Interv_12_dias"] = Interv_12;






            var z = zz.PROC_GRC_IDADE_SALDOS(Pesquisa_no, Pesquisa_nome, Filtro_Comercial, Filtro_Zona, Filtro_Tipo_Pagamento, Colunas_Opcao_Sld_Negativo).AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa_no))
                z = z.Where(c => c.no.Contains(Pesquisa_no));
            if (!string.IsNullOrEmpty(Pesquisa_nome))
                z = z.Where(c => c.nome.Contains(Pesquisa_nome));
            if (!string.IsNullOrEmpty(Filtro_por_Evolucao_do_PMR))
                z = z.Where(c => c.Filtro_por_Evolucao_do_PMR.Equals(Filtro_por_Evolucao_do_PMR));
            if (!string.IsNullOrEmpty(Filtro_Comercial))
                z = z.Where(c => c.Comercial.Equals(Filtro_Comercial));
            if (!string.IsNullOrEmpty(Filtro_Zona))
                z = z.Where(c => c.Zona.Equals(Filtro_Zona));
            if (!string.IsNullOrEmpty(Filtro_Tipo_Pagamento))
                z = z.Where(c => c.Tipo_Pagamento.Equals(Filtro_Tipo_Pagamento));
        
            return View(z.ToList());

        }



        public ActionResult GRC_CONF_IDADE_SALDOS_Result(string Pesquisa_Id = "", string Pesquisa_User = "tjalmeida", string Interv_01_dias = "", string Interv_02_dias = "", string Interv_03_dias = "", string Interv_04_dias = "", string Interv_05_dias = "", string Interv_06_dias = "", string Interv_07_dias = "", string Interv_08_dias = "", string Interv_09_dias = "", string Interv_10_dias = "", string Interv_11_dias = "", string Interv_12_dias = "")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);

            var p = zz.PROC_GRC_CONF_IDADE_SALDOS_ALT(Pesquisa_Id,Pesquisa_User, Interv_01_dias, Interv_02_dias, Interv_03_dias, Interv_04_dias, Interv_05_dias, Interv_06_dias, Interv_07_dias, Interv_08_dias, Interv_09_dias, Interv_10_dias, Interv_11_dias, Interv_12_dias).AsQueryable();


            return PartialView(p.ToList());
           
        }

        public ActionResult GRC_CONF_IDADE_SALDOS_Result_ALT(string Pesquisa_Id = "", string Pesquisa_User = "tjalmeida", string Interv_01_dias = "", string Interv_02_dias = "", string Interv_03_dias = "", string Interv_04_dias = "", string Interv_05_dias = "", string Interv_06_dias = "", string Interv_07_dias = "", string Interv_08_dias = "", string Interv_09_dias = "", string Interv_10_dias = "", string Interv_11_dias = "", string Interv_12_dias = "")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);

            var p = zz.PROC_GRC_CONF_IDADE_SALDOS_ALT(Pesquisa_Id, Pesquisa_User, Interv_01_dias, Interv_02_dias, Interv_03_dias, Interv_04_dias, Interv_05_dias, Interv_06_dias, Interv_07_dias, Interv_08_dias, Interv_09_dias, Interv_10_dias, Interv_11_dias, Interv_12_dias).AsQueryable();


            return Redirect(Request.UrlReferrer.ToString());

          
        }

        public ActionResult GRC_ALERTAS_RESUMO(string Alertas = "", string Pesquisa_User = "tjalmeida")
        {


            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);

 //NOTA TA: Aqui coloco todas as variaveis que preciso para os textos de introdução aos alertas e passo-as para a View através de ViewData.
            var i= zz.PROC_GRC_CONF_ALERTAS1(Pesquisa_User).ToList();
            ViewData["Par_Activo_AO01"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO01).First();
            ViewData["Par_Activo_AO02"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO02).First();
            ViewData["Par_Activo_AO03"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO03).First();
            ViewData["Par_Activo_AO04"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO04).First();
            ViewData["Par_Activo_AO05"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO05).First();
            ViewData["Par_Activo_AO06"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO06).First();
            ViewData["Par_Activo_AO07"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO07).First();
            ViewData["Par_Activo_AO08"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO08).First();
            ViewData["Par_Activo_AO09"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO09).First();
            ViewData["Par_Activo_AO10"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO10).First();
            
            ViewData["Par_Meses_Controlo_AO01"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO01).First();
            ViewData["Par_Meses_Controlo_AO02"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO02).First();
            ViewData["Par_Meses_Controlo_AO03"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO03).First();
            ViewData["Par_Meses_Controlo_AO04"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO04).First();
            ViewData["Par_Meses_Controlo_AO05"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO05).First();
            ViewData["Par_Meses_Controlo_AO06"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO06).First();
            ViewData["Par_Meses_Controlo_AO07"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO07).First();
            ViewData["Par_Meses_Controlo_AO08"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO08).First();
            ViewData["Par_Meses_Controlo_AO09"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO09).First();
            ViewData["Par_Meses_Controlo_AO10"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO10).First();

            ViewData["Par_Lim_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO01).First();
            ViewData["Par_Lim_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO02).First();
            ViewData["Par_Lim_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO03).First();
            ViewData["Par_Lim_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO04).First();
            ViewData["Par_Lim_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO05).First();
            ViewData["Par_Lim_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO06).First();
            ViewData["Par_Lim_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO07).First();
            ViewData["Par_Lim_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO08).First();
            ViewData["Par_Lim_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO09).First();
            ViewData["Par_Lim_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO10).First();

            ViewData["Par_Abaixo_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO01).First();
            ViewData["Par_Abaixo_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO02).First();
            ViewData["Par_Abaixo_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO03).First();
            ViewData["Par_Abaixo_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO04).First();
            ViewData["Par_Abaixo_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO05).First();
            ViewData["Par_Abaixo_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO06).First();
            ViewData["Par_Abaixo_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO07).First();
            ViewData["Par_Abaixo_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO08).First();
            ViewData["Par_Abaixo_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO09).First();
            ViewData["Par_Abaixo_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO10).First();

            ViewData["Par_Acima_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO01).First();
            ViewData["Par_Acima_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO02).First();
            ViewData["Par_Acima_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO03).First();
            ViewData["Par_Acima_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO04).First();
            ViewData["Par_Acima_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO05).First();
            ViewData["Par_Acima_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO06).First();
            ViewData["Par_Acima_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO07).First();
            ViewData["Par_Acima_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO08).First();
            ViewData["Par_Acima_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO09).First();
            ViewData["Par_Acima_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO01"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO02"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO03"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO04"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO05"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO06"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO07"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO08"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO09"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO10"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO01"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO02"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO03"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO04"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO05"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO06"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO07"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO08"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO09"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO10"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO10).First();

            ViewData["Par_Lim_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO01).First();
            ViewData["Par_Lim_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO02).First();
            ViewData["Par_Lim_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO03).First();
            ViewData["Par_Lim_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO04).First();
            ViewData["Par_Lim_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO05).First();
            ViewData["Par_Lim_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO06).First();
            ViewData["Par_Lim_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO07).First();
            ViewData["Par_Lim_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO08).First();
            ViewData["Par_Lim_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO09).First();
            ViewData["Par_Lim_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO10).First();

            ViewData["Par_Abaixo_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO01).First();
            ViewData["Par_Abaixo_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO02).First();
            ViewData["Par_Abaixo_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO03).First();
            ViewData["Par_Abaixo_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO04).First();
            ViewData["Par_Abaixo_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO05).First();
            ViewData["Par_Abaixo_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO06).First();
            ViewData["Par_Abaixo_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO07).First();
            ViewData["Par_Abaixo_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO08).First();
            ViewData["Par_Abaixo_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO09).First();
            ViewData["Par_Abaixo_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO10).First();

            ViewData["Par_Acima_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO01).First();
            ViewData["Par_Acima_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO02).First();
            ViewData["Par_Acima_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO03).First();
            ViewData["Par_Acima_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO04).First();
            ViewData["Par_Acima_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO05).First();
            ViewData["Par_Acima_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO06).First();
            ViewData["Par_Acima_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO07).First();
            ViewData["Par_Acima_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO08).First();
            ViewData["Par_Acima_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO09).First();
            ViewData["Par_Acima_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO01"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO02"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO03"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO04"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO05"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO06"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO07"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO08"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO09"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO10"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO01"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO02"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO03"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO04"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO05"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO06"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO07"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO08"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO09"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO10"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Tem_VN_AO01"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO02"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO03"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO04"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO05"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO06"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO07"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO08"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO09"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO10"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO10).First();

            ViewData["Par_Var_PMR_Perc_AO01"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO01).First();
            ViewData["Par_Var_PMR_Perc_AO02"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO02).First();
            ViewData["Par_Var_PMR_Perc_AO03"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO03).First();
            ViewData["Par_Var_PMR_Perc_AO04"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO04).First();
            ViewData["Par_Var_PMR_Perc_AO05"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO05).First();
            ViewData["Par_Var_PMR_Perc_AO06"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO06).First();
            ViewData["Par_Var_PMR_Perc_AO07"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO07).First();
            ViewData["Par_Var_PMR_Perc_AO08"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO08).First();
            ViewData["Par_Var_PMR_Perc_AO09"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO09).First();
            ViewData["Par_Var_PMR_Perc_AO10"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO10).First();

            ViewData["Par_Var_PMR_Absol_AO01"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO01).First();
            ViewData["Par_Var_PMR_Absol_AO02"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO02).First();
            ViewData["Par_Var_PMR_Absol_AO03"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO03).First();
            ViewData["Par_Var_PMR_Absol_AO04"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO04).First();
            ViewData["Par_Var_PMR_Absol_AO05"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO05).First();
            ViewData["Par_Var_PMR_Absol_AO06"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO06).First();
            ViewData["Par_Var_PMR_Absol_AO07"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO07).First();
            ViewData["Par_Var_PMR_Absol_AO08"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO08).First();
            ViewData["Par_Var_PMR_Absol_AO09"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO09).First();
            ViewData["Par_Var_PMR_Absol_AO10"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO10).First();

            ViewData["Par_Var_Cred_Conc_Perc_AO01"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO01).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO02"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO02).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO03"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO03).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO04"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO04).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO05"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO05).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO06"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO06).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO07"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO07).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO08"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO08).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO09"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO09).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO10"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO10).First();

            ViewData["Par_Var_Cred_Conc_Absol_AO01"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO01).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO02"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO02).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO03"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO03).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO04"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO04).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO05"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO05).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO06"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO06).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO07"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO07).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO08"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO08).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO09"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO09).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO10"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO10).First();

            ViewData["Par_Var_Cred_Venc_Perc_AO01"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO01).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO02"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO02).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO03"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO03).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO04"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO04).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO05"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO05).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO06"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO06).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO07"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO07).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO08"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO08).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO09"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO09).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO10"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO10).First();

            ViewData["Par_Var_Cred_Venc_Absol_AO01"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO01).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO02"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO02).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO03"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO03).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO04"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO04).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO05"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO05).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO06"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO06).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO07"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO07).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO08"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO08).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO09"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO09).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO10"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO10).First();

            ViewData["Par_Var_VN_Perc_AO01"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO01).First();
            ViewData["Par_Var_VN_Perc_AO02"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO02).First();
            ViewData["Par_Var_VN_Perc_AO03"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO03).First();
            ViewData["Par_Var_VN_Perc_AO04"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO04).First();
            ViewData["Par_Var_VN_Perc_AO05"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO05).First();
            ViewData["Par_Var_VN_Perc_AO06"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO06).First();
            ViewData["Par_Var_VN_Perc_AO07"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO07).First();
            ViewData["Par_Var_VN_Perc_AO08"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO08).First();
            ViewData["Par_Var_VN_Perc_AO09"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO09).First();
            ViewData["Par_Var_VN_Perc_AO10"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO10).First();

            ViewData["Par_Var_VN_Absol_AO01"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO01).First();
            ViewData["Par_Var_VN_Absol_AO02"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO02).First();
            ViewData["Par_Var_VN_Absol_AO03"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO03).First();
            ViewData["Par_Var_VN_Absol_AO04"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO04).First();
            ViewData["Par_Var_VN_Absol_AO05"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO05).First();
            ViewData["Par_Var_VN_Absol_AO06"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO06).First();
            ViewData["Par_Var_VN_Absol_AO07"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO07).First();
            ViewData["Par_Var_VN_Absol_AO08"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO08).First();
            ViewData["Par_Var_VN_Absol_AO09"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO09).First();
            ViewData["Par_Var_VN_Absol_AO10"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO10).First();

            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO01"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO01).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO02"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO02).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO03"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO03).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO04"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO04).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO05"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO05).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO06"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO06).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO07"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO07).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO08"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO08).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO09"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO09).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO10"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO10).First();

            ViewData["Par_Peso_Cliente_VN_Perc_AO01"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO01).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO02"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO02).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO03"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO03).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO04"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO04).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO05"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO05).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO06"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO06).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO07"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO07).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO08"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO08).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO09"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO09).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO10"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO10).First();

            ViewData["Par_Util_Plafond_Excesso_Per_AO01"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO01).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO02"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO02).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO03"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO03).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO04"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO04).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO05"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO05).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO06"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO06).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO07"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO07).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO08"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO08).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO09"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO09).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO10"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO10).First();





            var p = zz.PROC_GRC_ALERTA_AOXX(Alertas, Pesquisa_User).AsQueryable();
            if (!string.IsNullOrEmpty(Alertas))
                p = p.Where(c => c.ALERTA.Equals(Alertas));

            return View(p.ToList());

        }


        public ActionResult GRC_CONF_ALERTAS_Result_ALT(string Pesquisa_Id = "", string Pesquisa_Alerta = "", string Pesquisa_User = "", string Meses_Controlo = "", string Lim_Max_PMR = "", string Abaixo_Max_PMR = "", string Acima_Max_PMR = "", string NoPeriodo_Abaixo_Max__PMR = "", string NoPeriodo_Acima_Max__PMR = "", string NoPeriodo_Desce_Max_PMR = "", string NoPeriodo_Sobe_Max_PMR = "", string Lim_Min_PMR = "", string Abaixo_Min_PMR = "", string Acima_Min_PMR = "", string NoPeriodo_Desce_Min_PMR = "", string NoPeriodo_Sobe_Min_PMR = "", string NoPeriodo_Abaixo_Min__PMR = "", string NoPeriodo_Acima_Min__PMR = "", string Var_PMR_Perc = "", string Var_PMR_Absol = "", string Var_Cred_Conc_Perc = "", string Var_Cred_Conc_Absol = "", string Var_Cred_Venc_Perc = "", string Var_Cred_Venc_Absol = "", string NoPeriodo_Tem_VN = "", string Var_VN_Perc = "", string Var_VN_Absol = "", string Peso_Cred_Conc_CP_Perc = "", string Peso_Cliente_VN_Perc = "", string Util_Plafond_Excesso_Per = "", string Activo = "")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);


            var p = zz.PROC_GRC_CONF_ALERTAS_ALT(Pesquisa_Id, Pesquisa_Alerta, IdentifyUser, Meses_Controlo, Lim_Max_PMR, Abaixo_Max_PMR, Acima_Max_PMR, NoPeriodo_Abaixo_Max__PMR, NoPeriodo_Acima_Max__PMR, NoPeriodo_Desce_Max_PMR, NoPeriodo_Sobe_Max_PMR, Lim_Min_PMR, Abaixo_Min_PMR, Acima_Min_PMR, NoPeriodo_Desce_Min_PMR, NoPeriodo_Sobe_Min_PMR, NoPeriodo_Abaixo_Min__PMR, NoPeriodo_Acima_Min__PMR, Var_PMR_Perc, Var_PMR_Absol, Var_Cred_Conc_Perc, Var_Cred_Conc_Absol, Var_Cred_Venc_Perc, Var_Cred_Venc_Absol, NoPeriodo_Tem_VN, Var_VN_Perc, Var_VN_Absol, Peso_Cred_Conc_CP_Perc, Peso_Cliente_VN_Perc, Util_Plafond_Excesso_Per, Activo).AsQueryable();


            return Redirect(Request.UrlReferrer.ToString());


        }
       
        public ActionResult GRC_CONF_ALERTAS1_Result(string Pesquisa_User = "")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);

            var p = zz.PROC_GRC_CONF_ALERTAS1(IdentifyUser).AsQueryable();


            return PartialView(p.ToList());

        }

        public ActionResult PROC_GRC_CRIA_CONF_USER(string Pesquisa_User = "")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);

            var p = zz.PROC_GRC_CRIA_CONF_USER(IdentifyUser);


            return RedirectToAction("Index", "Home");

        }


        public ActionResult GRC_CONF_USER_Result(string Pesquisa_User = "", string Pesquisa_Objecto01 = "", string Pesquisa_Objecto02 = "", string Pesquisa_Objecto03 = "")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);




             var userAgent1 = Request.Browser.IsMobileDevice;
            if (userAgent1.Equals(false))
            {
            var Class_00_2 = "PC";

            string Class_01_2 = Class_00_2;


            var p = zz.PROC_GRC_CONF_USER(IdentifyUser, Pesquisa_Objecto01, Pesquisa_Objecto02, Pesquisa_Objecto03, Class_01_2).AsQueryable();


            return PartialView(p.ToList());
            }
            else
            {
                var Class_00_1 = "MOBILE";

                string Class_01_1 = Class_00_1;


                var p = zz.PROC_GRC_CONF_USER(IdentifyUser, Pesquisa_Objecto01, Pesquisa_Objecto02, Pesquisa_Objecto03, Class_01_1).AsQueryable();


                return PartialView(p.ToList());
            }
        }

        public ActionResult GRC_CONF_USER_Result_ALT(string Pesquisa_User = "", string Pesquisa_Objecto01 = "", string Pesquisa_Objecto02 = "", string objecto_PAR = "", string ALERTA = "", string NO_ = "", string NOME = "", string PMR_ACT = "", string PMR_ANT = "", string VN__ACT_12MESES = "", string VN_ACT = "", string VN_ANT = "", string CRED_CONC_ACT = "", string CRED_CONC_ANT = "", string CRED_VENC_ACT = "", string CRED_VENC_ANT = "", string VN_TOTAL_ACT = "", string CRED_CONC_TOTAL_ACT = "")
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);


            var userAgent1 = Request.Browser.IsMobileDevice;
            if (userAgent1.Equals(false))
                        {
                            var Class_00_2 = "PC";

                            string Class_01_2 = Class_00_2;
                            var p = zz.PROC_GRC_CONF_USER_ALT(IdentifyUser, Pesquisa_Objecto01, Pesquisa_Objecto02, objecto_PAR, ALERTA, NO_, NOME, PMR_ACT, PMR_ANT, VN__ACT_12MESES, VN_ACT, VN_ANT, CRED_CONC_ACT, CRED_CONC_ANT, CRED_VENC_ACT, CRED_VENC_ANT, VN_TOTAL_ACT, CRED_CONC_TOTAL_ACT, Class_01_2).AsQueryable();


                            return Redirect(Request.UrlReferrer.ToString()); 
                        }

                        else
                        {
                            var Class_00_1 = "MOBILE";

                            string Class_01_1 = Class_00_1;
                            var p = zz.PROC_GRC_CONF_USER_ALT(IdentifyUser, Pesquisa_Objecto01, Pesquisa_Objecto02, objecto_PAR, ALERTA, NO_, NOME, PMR_ACT, PMR_ANT, VN__ACT_12MESES, VN_ACT, VN_ANT, CRED_CONC_ACT, CRED_CONC_ANT, CRED_VENC_ACT, CRED_VENC_ANT, VN_TOTAL_ACT, CRED_CONC_TOTAL_ACT, Class_01_1).AsQueryable();


                            return Redirect(Request.UrlReferrer.ToString());
                        }

        }




        public ActionResult PROC_GRC_ACT_TBL_GRC_IND()
        {
            string IdentifyUser = User.Identity.Name;
            string caracter = "#";
            int Identifycaracter = IdentifyUser.IndexOf(caracter);
            var IdentifyLength = IdentifyUser.Length - Identifycaracter;
            var User1 = IdentifyUser.Substring(0, Identifycaracter);
            var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
            APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);


            var p = zz.PROC_GRC_ACT_TBL_GRC_IND();


            return View();


        }

        public ActionResult PROC_GRC_ACT_TBL_GRC0001()
        {
            APLICACAOEntities2 dc = new APLICACAOEntities2();


            var p = dc.PROC_GRC_ACT_TBL_GRC0001();


            return View();


        }
        public ActionResult PROC_GRC_ACT_TBL_GRC0002()
        {
            APLICACAOEntities2 dc = new APLICACAOEntities2();


            var p = dc.PROC_GRC_ACT_TBL_GRC0002();


            return View();


        }

        public ActionResult GRC_ALERTAS_INDIVIDUAL(string Alertas = "", string Pesquisa_User = "")
        {

string IdentifyUser = User.Identity.Name;
string caracter = "#";
int Identifycaracter = IdentifyUser.IndexOf(caracter);
var IdentifyLength = IdentifyUser.Length - Identifycaracter;
var User1 = IdentifyUser.Substring(0, Identifycaracter);
var Conexao = IdentifyUser.Substring(Identifycaracter + 1, IdentifyLength - 1);
APLICACAOEntities2 zz = new APLICACAOEntities2(Conexao);



            //NOTA TA: Aqui coloco todas as variaveis que preciso para os textos de introdução aos alertas e passo-as para a View através de ViewData.
            var i = zz.PROC_GRC_CONF_ALERTAS1(Pesquisa_User).ToList();
            ViewData["Par_Activo_AO01"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO01).First();
            ViewData["Par_Activo_AO02"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO02).First();
            ViewData["Par_Activo_AO03"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO03).First();
            ViewData["Par_Activo_AO04"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO04).First();
            ViewData["Par_Activo_AO05"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO05).First();
            ViewData["Par_Activo_AO06"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO06).First();
            ViewData["Par_Activo_AO07"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO07).First();
            ViewData["Par_Activo_AO08"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO08).First();
            ViewData["Par_Activo_AO09"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO09).First();
            ViewData["Par_Activo_AO10"] = i.Where(c => c.ParametrosNum == 1).Select(c => c.AO10).First();

            ViewData["Par_Meses_Controlo_AO01"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO01).First();
            ViewData["Par_Meses_Controlo_AO02"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO02).First();
            ViewData["Par_Meses_Controlo_AO03"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO03).First();
            ViewData["Par_Meses_Controlo_AO04"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO04).First();
            ViewData["Par_Meses_Controlo_AO05"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO05).First();
            ViewData["Par_Meses_Controlo_AO06"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO06).First();
            ViewData["Par_Meses_Controlo_AO07"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO07).First();
            ViewData["Par_Meses_Controlo_AO08"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO08).First();
            ViewData["Par_Meses_Controlo_AO09"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO09).First();
            ViewData["Par_Meses_Controlo_AO10"] = i.Where(c => c.ParametrosNum == 2).Select(c => c.AO10).First();

            ViewData["Par_Lim_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO01).First();
            ViewData["Par_Lim_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO02).First();
            ViewData["Par_Lim_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO03).First();
            ViewData["Par_Lim_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO04).First();
            ViewData["Par_Lim_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO05).First();
            ViewData["Par_Lim_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO06).First();
            ViewData["Par_Lim_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO07).First();
            ViewData["Par_Lim_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO08).First();
            ViewData["Par_Lim_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO09).First();
            ViewData["Par_Lim_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 3).Select(c => c.AO10).First();

            ViewData["Par_Abaixo_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO01).First();
            ViewData["Par_Abaixo_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO02).First();
            ViewData["Par_Abaixo_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO03).First();
            ViewData["Par_Abaixo_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO04).First();
            ViewData["Par_Abaixo_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO05).First();
            ViewData["Par_Abaixo_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO06).First();
            ViewData["Par_Abaixo_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO07).First();
            ViewData["Par_Abaixo_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO08).First();
            ViewData["Par_Abaixo_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO09).First();
            ViewData["Par_Abaixo_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 4).Select(c => c.AO10).First();

            ViewData["Par_Acima_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO01).First();
            ViewData["Par_Acima_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO02).First();
            ViewData["Par_Acima_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO03).First();
            ViewData["Par_Acima_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO04).First();
            ViewData["Par_Acima_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO05).First();
            ViewData["Par_Acima_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO06).First();
            ViewData["Par_Acima_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO07).First();
            ViewData["Par_Acima_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO08).First();
            ViewData["Par_Acima_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO09).First();
            ViewData["Par_Acima_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 5).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO01"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO02"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO03"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO04"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO05"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO06"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO07"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO08"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO09"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Abaixo_Max__PMR_AO10"] = i.Where(c => c.ParametrosNum == 6).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO01"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO02"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO03"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO04"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO05"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO06"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO07"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO08"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO09"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Acima_Max__PMR_AO10"] = i.Where(c => c.ParametrosNum == 7).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Desce_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 8).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO01"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO02"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO03"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO04"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO05"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO06"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO07"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO08"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO09"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Sobe_Max_PMR_AO10"] = i.Where(c => c.ParametrosNum == 9).Select(c => c.AO10).First();

            ViewData["Par_Lim_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO01).First();
            ViewData["Par_Lim_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO02).First();
            ViewData["Par_Lim_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO03).First();
            ViewData["Par_Lim_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO04).First();
            ViewData["Par_Lim_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO05).First();
            ViewData["Par_Lim_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO06).First();
            ViewData["Par_Lim_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO07).First();
            ViewData["Par_Lim_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO08).First();
            ViewData["Par_Lim_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO09).First();
            ViewData["Par_Lim_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 10).Select(c => c.AO10).First();

            ViewData["Par_Abaixo_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO01).First();
            ViewData["Par_Abaixo_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO02).First();
            ViewData["Par_Abaixo_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO03).First();
            ViewData["Par_Abaixo_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO04).First();
            ViewData["Par_Abaixo_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO05).First();
            ViewData["Par_Abaixo_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO06).First();
            ViewData["Par_Abaixo_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO07).First();
            ViewData["Par_Abaixo_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO08).First();
            ViewData["Par_Abaixo_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO09).First();
            ViewData["Par_Abaixo_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 11).Select(c => c.AO10).First();

            ViewData["Par_Acima_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO01).First();
            ViewData["Par_Acima_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO02).First();
            ViewData["Par_Acima_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO03).First();
            ViewData["Par_Acima_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO04).First();
            ViewData["Par_Acima_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO05).First();
            ViewData["Par_Acima_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO06).First();
            ViewData["Par_Acima_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO07).First();
            ViewData["Par_Acima_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO08).First();
            ViewData["Par_Acima_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO09).First();
            ViewData["Par_Acima_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 12).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Desce_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 13).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO01"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO02"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO03"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO04"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO05"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO06"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO07"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO08"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO09"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Sobe_Min_PMR_AO10"] = i.Where(c => c.ParametrosNum == 14).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO01"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO02"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO03"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO04"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO05"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO06"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO07"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO08"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO09"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Abaixo_Min__PMR_AO10"] = i.Where(c => c.ParametrosNum == 15).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO01"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO02"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO03"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO04"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO05"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO06"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO07"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO08"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO09"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Acima_Min__PMR_AO10"] = i.Where(c => c.ParametrosNum == 16).Select(c => c.AO10).First();

            ViewData["Par_NoPeriodo_Tem_VN_AO01"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO01).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO02"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO02).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO03"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO03).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO04"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO04).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO05"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO05).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO06"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO06).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO07"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO07).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO08"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO08).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO09"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO09).First();
            ViewData["Par_NoPeriodo_Tem_VN_AO10"] = i.Where(c => c.ParametrosNum == 17).Select(c => c.AO10).First();

            ViewData["Par_Var_PMR_Perc_AO01"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO01).First();
            ViewData["Par_Var_PMR_Perc_AO02"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO02).First();
            ViewData["Par_Var_PMR_Perc_AO03"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO03).First();
            ViewData["Par_Var_PMR_Perc_AO04"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO04).First();
            ViewData["Par_Var_PMR_Perc_AO05"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO05).First();
            ViewData["Par_Var_PMR_Perc_AO06"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO06).First();
            ViewData["Par_Var_PMR_Perc_AO07"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO07).First();
            ViewData["Par_Var_PMR_Perc_AO08"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO08).First();
            ViewData["Par_Var_PMR_Perc_AO09"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO09).First();
            ViewData["Par_Var_PMR_Perc_AO10"] = i.Where(c => c.ParametrosNum == 20).Select(c => c.AO10).First();

            ViewData["Par_Var_PMR_Absol_AO01"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO01).First();
            ViewData["Par_Var_PMR_Absol_AO02"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO02).First();
            ViewData["Par_Var_PMR_Absol_AO03"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO03).First();
            ViewData["Par_Var_PMR_Absol_AO04"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO04).First();
            ViewData["Par_Var_PMR_Absol_AO05"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO05).First();
            ViewData["Par_Var_PMR_Absol_AO06"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO06).First();
            ViewData["Par_Var_PMR_Absol_AO07"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO07).First();
            ViewData["Par_Var_PMR_Absol_AO08"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO08).First();
            ViewData["Par_Var_PMR_Absol_AO09"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO09).First();
            ViewData["Par_Var_PMR_Absol_AO10"] = i.Where(c => c.ParametrosNum == 21).Select(c => c.AO10).First();

            ViewData["Par_Var_Cred_Conc_Perc_AO01"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO01).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO02"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO02).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO03"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO03).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO04"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO04).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO05"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO05).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO06"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO06).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO07"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO07).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO08"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO08).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO09"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO09).First();
            ViewData["Par_Var_Cred_Conc_Perc_AO10"] = i.Where(c => c.ParametrosNum == 22).Select(c => c.AO10).First();

            ViewData["Par_Var_Cred_Conc_Absol_AO01"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO01).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO02"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO02).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO03"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO03).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO04"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO04).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO05"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO05).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO06"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO06).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO07"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO07).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO08"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO08).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO09"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO09).First();
            ViewData["Par_Var_Cred_Conc_Absol_AO10"] = i.Where(c => c.ParametrosNum == 23).Select(c => c.AO10).First();

            ViewData["Par_Var_Cred_Venc_Perc_AO01"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO01).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO02"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO02).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO03"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO03).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO04"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO04).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO05"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO05).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO06"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO06).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO07"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO07).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO08"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO08).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO09"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO09).First();
            ViewData["Par_Var_Cred_Venc_Perc_AO10"] = i.Where(c => c.ParametrosNum == 24).Select(c => c.AO10).First();

            ViewData["Par_Var_Cred_Venc_Absol_AO01"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO01).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO02"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO02).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO03"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO03).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO04"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO04).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO05"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO05).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO06"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO06).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO07"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO07).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO08"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO08).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO09"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO09).First();
            ViewData["Par_Var_Cred_Venc_Absol_AO10"] = i.Where(c => c.ParametrosNum == 25).Select(c => c.AO10).First();

            ViewData["Par_Var_VN_Perc_AO01"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO01).First();
            ViewData["Par_Var_VN_Perc_AO02"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO02).First();
            ViewData["Par_Var_VN_Perc_AO03"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO03).First();
            ViewData["Par_Var_VN_Perc_AO04"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO04).First();
            ViewData["Par_Var_VN_Perc_AO05"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO05).First();
            ViewData["Par_Var_VN_Perc_AO06"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO06).First();
            ViewData["Par_Var_VN_Perc_AO07"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO07).First();
            ViewData["Par_Var_VN_Perc_AO08"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO08).First();
            ViewData["Par_Var_VN_Perc_AO09"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO09).First();
            ViewData["Par_Var_VN_Perc_AO10"] = i.Where(c => c.ParametrosNum == 26).Select(c => c.AO10).First();

            ViewData["Par_Var_VN_Absol_AO01"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO01).First();
            ViewData["Par_Var_VN_Absol_AO02"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO02).First();
            ViewData["Par_Var_VN_Absol_AO03"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO03).First();
            ViewData["Par_Var_VN_Absol_AO04"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO04).First();
            ViewData["Par_Var_VN_Absol_AO05"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO05).First();
            ViewData["Par_Var_VN_Absol_AO06"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO06).First();
            ViewData["Par_Var_VN_Absol_AO07"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO07).First();
            ViewData["Par_Var_VN_Absol_AO08"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO08).First();
            ViewData["Par_Var_VN_Absol_AO09"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO09).First();
            ViewData["Par_Var_VN_Absol_AO10"] = i.Where(c => c.ParametrosNum == 27).Select(c => c.AO10).First();

            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO01"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO01).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO02"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO02).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO03"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO03).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO04"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO04).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO05"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO05).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO06"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO06).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO07"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO07).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO08"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO08).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO09"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO09).First();
            ViewData["Par_Peso_Cred_Conc_CP_Perc_AO10"] = i.Where(c => c.ParametrosNum == 28).Select(c => c.AO10).First();

            ViewData["Par_Peso_Cliente_VN_Perc_AO01"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO01).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO02"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO02).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO03"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO03).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO04"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO04).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO05"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO05).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO06"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO06).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO07"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO07).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO08"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO08).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO09"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO09).First();
            ViewData["Par_Peso_Cliente_VN_Perc_AO10"] = i.Where(c => c.ParametrosNum == 29).Select(c => c.AO10).First();

            ViewData["Par_Util_Plafond_Excesso_Per_AO01"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO01).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO02"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO02).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO03"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO03).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO04"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO04).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO05"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO05).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO06"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO06).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO07"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO07).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO08"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO08).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO09"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO09).First();
            ViewData["Par_Util_Plafond_Excesso_Per_AO10"] = i.Where(c => c.ParametrosNum == 30).Select(c => c.AO10).First();


            ViewData["Alerta"] = Alertas;


            var p = zz.PROC_GRC_ALERTA_AOXX(Alertas, Pesquisa_User).AsQueryable();
            if (!string.IsNullOrEmpty(Alertas))
                p = p.Where(c => c.ALERTA.Equals(Alertas));

            return View(p.ToList());

        }
    }

}
