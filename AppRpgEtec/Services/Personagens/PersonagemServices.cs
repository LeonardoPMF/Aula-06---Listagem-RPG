﻿using AppRpgEtec.Models;
using AppRpgEtec.Views.Personagens;
using AppRpgEtec.ViewModels.Personagens;
using AppRpgEtec.ViewModels.Usuarios;
using AppRpgEtec.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Services.Personagens
{
    public class PersonagemServices : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "https://rpgapi20242pam.azurewebsites.net/Personagens";

        private string _token;

        public PersonagemServices(string token)
        {
            _token = token;
            _request = new Request();
        }
            
          public async Task<Personagem> PostPersonagemAsync(Personagem p) {

            return await _request.PostAsync(apiUrlBase, p, _token);
        }

        public async Task<ObservableCollection<Personagem>> GetPersonagensAsync()
        {
            string UrlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Personagem> listaPersonagens = await
         _request.GetAsync<ObservableCollection<Models.Personagem>>(apiUrlBase + UrlComplementar,
           _token);
            return listaPersonagens;
        }
        
        public async Task<Personagem> GetPersonagemAsync(int personagemId)
        {
            string urlComplementar = string.Format("/{0}", personagemId);
            var personagem = await _request.GetAsync<Models.Personagem>(apiUrlBase + urlComplementar, _token);
            return personagem;
        }

        public async Task<int> PutPersonagemAsync(Personagem p)
        {
            var result = await _request.PutAsync(apiUrlBase, p, _token);
            return result;
        }
        public async Task<int> DeletePersonagemAsync(int personagemId)
        {
            string urlComplementar = string.Format("/{0}", personagemId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token); 
            return result;
        }

    }
}