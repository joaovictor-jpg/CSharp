using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entitites.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessage _message;
        private readonly IServiceMessage _serviceMessage;

        public MessageController(IMapper mapper, IMessage message, IServiceMessage serviceMessage)
        {
            _mapper = mapper;
            _message = message;
            _serviceMessage = serviceMessage;
        }

        private async Task<string> RetornaIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;
        }

        [Authorize]
        [Produces("Application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> AddAsync(MessageViewModel messageViewModel)
        {
            messageViewModel.UserId = await RetornaIdUsuarioLogado();
            var messageMap = _mapper.Map<Message>(messageViewModel);
            //await _message.Add(messageMap);
            await _serviceMessage.Adcionar(messageMap);
            return messageMap.Notitycoes;
        }

        [Authorize]
        [Produces("Application/json")]
        [HttpPut("/api/Update")]
        public async Task<List<Notifies>> UpdateAsync(MessageViewModel messageViewModel)
        {
            messageViewModel.UserId = await RetornaIdUsuarioLogado();
            var messageMap = _mapper.Map<Message>(messageViewModel);
            //await _message.Update(messageMap);
            await _serviceMessage.Atualizar(messageMap);
            return messageMap.Notitycoes;
        }

        [Authorize]
        [Produces("Application/json")]
        [HttpDelete("/api/Delete")]
        public async Task<List<Notifies>> DeleteAsync(MessageViewModel messageViewModel)
        {
            messageViewModel.UserId = await RetornaIdUsuarioLogado();
            var messageMap = _mapper.Map<Message>(messageViewModel);
            await _message.Delete(messageMap);
            return messageMap.Notitycoes;
        }

        [Authorize]
        [Produces("Application/json")]
        [HttpPost("/api/GetEntity")]
        public async Task<MessageViewModel> GetEntityByIdAsync(Message message)
        {
            message = await _message.GenEntityById(message.Id);
            var messageMap = _mapper.Map<MessageViewModel>(message);
            return messageMap;
        }

        //[Authorize]
        [AllowAnonymous]
        [Produces("Application/json")]
        [HttpGet("/api/Get")]
        public async Task<List<MessageViewModel>> ListAsync()
        {
            var messagens = await _message.List();
            var messageMap = _mapper.Map<List<MessageViewModel>>(messagens);
            return messageMap;
        }
        
        [Authorize]
        [Produces("Application/json")]
        [HttpGet("/api/Ativo")]
        public async Task<List<MessageViewModel>> ListaMessageAtivaAsync()
        {
            var messagens = await _serviceMessage.ListarMessageAtivas();
            var messageMap = _mapper.Map<List<MessageViewModel>>(messagens);
            return messageMap;
        }


    }
}
