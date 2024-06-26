﻿using Tapa_Buraco.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Tapa_Buraco.WebApi.Controllers
{
    [RoutePrefix("api/v1/Usuario")]
    public class UsuarioController : ApiController
    {
        [AuthorizeAttributeOverride()]
        [HttpGet]
        [Route("GetAll")]
        public async Task<HttpResponseMessage> GetAll([FromUri] string nome = null, [FromUri] int startIndexPaging = 0, [FromUri] int pageSizePaging = 15)
        {
            DTO.Response<DTO.Usuario> objResponse = new DTO.Response<DTO.Usuario>();
            string caminho = "Usuario/GetAll()";

            try
            {
                #region LOGs
                try
                {
                    #region Nlog
                    string parametros = $"Nome = {nome}";
                    NLogHelper.InicioRequisição(caminho, parametros);
                    #endregion Nlog                    
                }
                catch (Exception ex)
                {
                    //se houver problema com o LOG, ainda assim não interrompo a requisição.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                objResponse = await new Business.Usuario().GetAll(nome, startIndexPaging, pageSizePaging);
                if (objResponse != null && objResponse.Sucesso)
                {
                    #region LOGs                
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.OK(200), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    objResponse.Mensagem = "Consulta feita com sucesso";
                    return Request.CreateResponse(HttpStatusCode.OK, objResponse);
                }
                else
                {
                    #region LOGs 
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    objResponse.Sucesso = false;
                    objResponse.Mensagem = "Erro ao fazer a consulta";
                    return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
                }

            }
            catch (Exception ex)
            {

                objResponse.Sucesso = false;
                objResponse.Mensagem = Util.Util.GetAllExceptionsMessages(ex);

                #region LOGs
                try
                {
                    #region Nlog
                    string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                        (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                    NLogHelper.FimRequisição(caminho, retorno);
                    #endregion Nlog
                }
                catch (Exception ex2)
                {
                    //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex2);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
            }
        }

        [AuthorizeAttributeOverride()]
        [HttpGet]
        [Route("GetById")]
        public async Task<HttpResponseMessage> GetById([FromUri] int id)
        {
            DTO.Response<DTO.Usuario> objResponse = new DTO.Response<DTO.Usuario>();
            string caminho = "Usuario/GetById()";

            try
            {
                #region LOGs
                try
                {
                    #region Nlog
                    string parametros = $"ID = {id}";
                    NLogHelper.InicioRequisição(caminho, parametros);
                    #endregion Nlog                    
                }
                catch (Exception ex)
                {
                    //se houver problema com o LOG, ainda assim não interrompo a requisição.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                objResponse = await new Business.Usuario().GetById(id);

                if (objResponse != null && objResponse.Sucesso)
                {
                    #region LOGs                
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.OK(200), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    objResponse.Mensagem = "Consulta feita com sucesso";
                    return Request.CreateResponse(HttpStatusCode.OK, objResponse);
                }
                else
                {
                    #region LOGs 
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    objResponse.Sucesso = false;
                    objResponse.Mensagem = "Erro ao fazer a consulta";
                    return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
                }

            }
            catch (Exception ex)
            {
                objResponse.Sucesso = false;
                objResponse.Mensagem = Util.Util.GetAllExceptionsMessages(ex);

                #region LOGs
                try
                {
                    #region Nlog
                    string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                        (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                    NLogHelper.FimRequisição(caminho, retorno);
                    #endregion Nlog
                }
                catch (Exception ex2)
                {
                    //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex2);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
            }
        }

        [AuthorizeAttributeOverride()]
        [HttpPost]
        [Route("Post")]
        public async Task<HttpResponseMessage> Post([FromBody] DTO.Request<DTO.Usuario> objUsuarioRequest)
        {
            DTO.Response<DTO.Usuario> objResponse = new DTO.Response<DTO.Usuario>();
            string caminho = "Usuario/Post()";

            try
            {
                #region LOGs
                try
                {
                    #region Nlog
                    string parametros = "IdUsuarioRequisicao= '" + objUsuarioRequest.UsuarioAutenticacao.USUARIO.ID + "', " +
                        (objUsuarioRequest == null ? "objUsuarioRequest [Nulo]" : Newtonsoft.Json.JsonConvert.SerializeObject(objUsuarioRequest));
                    NLogHelper.InicioRequisição(caminho, parametros);
                    #endregion Nlog                    
                }
                catch (Exception ex)
                {
                    //se houver problema com o LOG, ainda assim não interrompo a requisição.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                objResponse = await new Business.Usuario().Save(objUsuarioRequest);
                if (objResponse != null && objResponse.Sucesso)
                {
                    #region LOGs                
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.OK(200), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    objResponse.Mensagem = "Dados do Usuário foram salvos com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, objResponse);
                }
                else
                {
                    #region LOGs 
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    objResponse.Mensagem = "Erro ao inserir usuário.";
                    return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
                }
            }
            catch (Exception ex)
            {
                objResponse.Sucesso = false;
                objResponse.Mensagem = Util.Util.GetAllExceptionsMessages(ex);

                #region LOGs
                try
                {
                    #region Nlog
                    string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                        (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                    NLogHelper.FimRequisição(caminho, retorno);
                    #endregion Nlog
                }
                catch (Exception ex2)
                {
                    //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex2);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
            }
        }

        [AuthorizeAttributeOverride()]
        [HttpPost]
        [Route("Put")]
        public async Task<HttpResponseMessage> Put([FromBody] DTO.Request<DTO.Usuario> objUsuarioRequest)
        {
            DTO.Response<DTO.Usuario> objResponse = new DTO.Response<DTO.Usuario>();
            string caminho = "Usuario/Put()";

            try
            {
                #region LOGs
                try
                {
                    #region Nlog
                    string parametros = "IdUsuarioRequisicao= '" + objUsuarioRequest.UsuarioAutenticacao.USUARIO.ID + "', " +
                        (objUsuarioRequest == null ? "objUsuarioRequest [Nulo]" : Newtonsoft.Json.JsonConvert.SerializeObject(objUsuarioRequest));
                    NLogHelper.InicioRequisição(caminho, parametros);
                    #endregion Nlog                    
                }
                catch (Exception ex)
                {
                    //se houver problema com o LOG, ainda assim não interrompo a requisição.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                objResponse = await new Business.Usuario().Update(objUsuarioRequest);
                if (objResponse != null && objResponse.Sucesso)
                {
                    #region LOGs                
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.OK(200), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    objResponse.Mensagem = "Dados do Usuário foram alterados com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, objResponse);
                }
                else
                {
                    #region LOGs 
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
                }
            }
            catch (Exception ex)
            {
                objResponse.Sucesso = false;
                objResponse.Mensagem = Util.Util.GetAllExceptionsMessages(ex);

                #region LOGs
                try
                {
                    #region Nlog
                    string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                        (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                    NLogHelper.FimRequisição(caminho, retorno);
                    #endregion Nlog
                }
                catch (Exception ex2)
                {
                    //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex2);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
            }
        }

        [AuthorizeAttributeOverride()]
        [HttpPost]
        [Route("Delete")]
        public async Task<HttpResponseMessage> Delete([FromBody] DTO.Request<DTO.Usuario> objUsuarioRequest)
        {
            DTO.Response<DTO.Usuario> objResponse = new DTO.Response<DTO.Usuario>();
            string caminho = "Usuario/Delete()";

            try
            {
                #region LOGs
                try
                {
                    #region Nlog
                    string parametros = "IdUsuarioRequisicao= '" + objUsuarioRequest.UsuarioAutenticacao.USUARIO.ID + "', " +
                        (objUsuarioRequest == null ? "objUsuarioRequest [Nulo]" : Newtonsoft.Json.JsonConvert.SerializeObject(objUsuarioRequest));
                    NLogHelper.InicioRequisição(caminho, parametros);
                    #endregion Nlog                    
                }
                catch (Exception ex)
                {
                    //se houver problema com o LOG, ainda assim não interrompo a requisição.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                objResponse = await new Business.Usuario().Delete(objUsuarioRequest);
                if (objResponse != null && objResponse.Sucesso)
                {
                    #region LOGs                
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.OK(200), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    objResponse.Mensagem = "Usuário foi excluido com sucesso!";
                    return Request.CreateResponse(HttpStatusCode.OK, objResponse);
                }
                else
                {
                    #region LOGs 
                    try
                    {
                        #region Nlog
                        string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                            (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                        NLogHelper.FimRequisição(caminho, retorno);
                        #endregion Nlog
                    }
                    catch (Exception ex)
                    {
                        //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                        try
                        {
                            #region Nlog
                            NLogHelper.ErroNlog(caminho, ex);
                            #endregion Nlog
                        }
                        catch { }
                    }
                    #endregion LOGs

                    return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
                }
            }
            catch (Exception ex)
            {
                objResponse.Sucesso = false;
                objResponse.Mensagem = Util.Util.GetAllExceptionsMessages(ex);

                #region LOGs
                try
                {
                    #region Nlog
                    string retorno = "Retorno => " + "HttpStatusCode.BadRequest(400), " +
                        (objResponse == null ? "objResponse [Nulo]" : objResponse.ToString());
                    NLogHelper.FimRequisição(caminho, retorno);
                    #endregion Nlog
                }
                catch (Exception ex2)
                {
                    //se houver problema com o LOG, ainda assim retorno a Msg ao cliente.
                    try
                    {
                        #region Nlog
                        NLogHelper.ErroNlog(caminho, ex2);
                        #endregion Nlog
                    }
                    catch { }
                }
                #endregion LOGs

                return Request.CreateResponse(HttpStatusCode.BadRequest, objResponse);
            }
        }
    }
}
