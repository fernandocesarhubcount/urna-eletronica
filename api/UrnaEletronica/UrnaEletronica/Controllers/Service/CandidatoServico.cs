using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands;
using UrnaEletronica.Controllers.Commands.Outputs;
using UrnaEletronica.DAL.Repositories;
using UrnaEletronica.DAL.Repositories.Interfaces;
using UrnaEletronica.Model;
using UrnaEletronica.Model.Inputs;

namespace UrnaEletronica.Controllers.Service
{
    public class CandidatoServico : Notifiable, ICandidatoServico
    {
        private readonly ICandidatoRepositorio _repositorio;
        private readonly IVotoRepositorio _votoRepositorio;

        public CandidatoServico(ICandidatoRepositorio repositorio, IVotoRepositorio votoRepositorio)
        {
            _repositorio = repositorio;
            _votoRepositorio = votoRepositorio;
        }

        public IComandoResultado SalvarCandidato(FormularioCandidato form)
        {
            if (form.Valid())
            {
                if (!LegendaJaRegistrada(form.Legenda))
                {

                    Candidato candidato = ConverterFormParaCandidato(form);
                    _repositorio.Salvar(candidato);

                    return new ComandoResultado(true, "Candidato Cadastrado com sucesso", candidato);
                }
                else
                {
                    form.AddNotification("Legenda", "Está leganda foi cadastrada para outro candidato");
                }
            }
            return new ComandoResultado(false, "Por favor, corrija os campos", form.Notifications);
        }

        public bool LegendaJaRegistrada(int legenda)
        {
            Candidato candidatoRegistrado = _repositorio.ObterPorLegenda(legenda);
            return candidatoRegistrado == null ? false : true;
        }

        public IComandoResultado AlterarCandidato(int id, FormularioCandidato form)
        {
            try
            {
                Candidato candidato = ConverterFormParaCandidato(form);
                _repositorio.Alterar(candidato);
                return new ComandoResultado(true, "Candidato atualizado com sucesso!", null);
            }
            catch (Exception ex)
            {
                return new ComandoResultado(false, "Não foi possível atualizar o cadastro do candidato", ex.Message);
            }
        }

        public Candidato ConverterFormParaCandidato(FormularioCandidato form)
        {
            if (form.DataDeRegistro != null)
            {
                return new Candidato(form.NomeCompleto, form.NomeVice, form.DataDeRegistro, form.Legenda);
            }
            return new Candidato(form.NomeCompleto, form.NomeVice, null, form.Legenda);
        }

        public IComandoResultado ApagarCandidato(int idCandidato )
        {
            try
            {
                _votoRepositorio.ApagarTodosVotosCandidato(idCandidato);
                var candidato = _repositorio.ObterPorId(idCandidato);
                if (candidato != null)
                {
                    _repositorio.Excluir(candidato);
                    return new ComandoResultado(true, "Candidato apagado com sucesso!", null);
                }
                return new ComandoResultado(false, "Não foi possivel excluir o candidato", null);
            }
            catch (Exception ex)
            {
                throw new Exception("ApagarCandidato " + ex.Message);
            }
        }

        public IComandoResultado ApagarTodosCandidatos()
        {
            try
            {
                IEnumerable<Candidato> candidatos = _repositorio.ObterTodos();
                foreach (var candidato in candidatos)
                {
                    ApagarCandidato(candidato.IdCandidato);
                }
                return new ComandoResultado(true, "Candidatos apagado com sucesso!", null);
            }
            catch (Exception ex)
            {
                throw new Exception("ApagarTodosCandidatos " + ex.Message);
            }
        }
    }
}
