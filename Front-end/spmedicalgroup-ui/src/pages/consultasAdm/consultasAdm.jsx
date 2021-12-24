import "../../assets/css/style.css"
import React, { useState, useEffect } from "react";
import Cabecalho from "../../components/cabecalho/cabecalho"
import axios from "axios";
import Rodape from "../../components/rodape/rodape"

export default function ConsultasAdm() {
  const [idCliente, setIdCliente] = useState(0);
  const [idMedico, setIdMedico] = useState(0);
  const [idSituacao, setIdSituacao] = useState(0);
  const [listaConsultas, setListaConsultas] = useState([]);
  const [listaClientes, setListaClientes] = useState([]);
  const [listaMedicos, setListaMedicos] = useState([]);
  const [dataConsulta, setDataConsulta] = useState(new Date());
  const [descricaoConsulta, setDescricaoConsulta] = useState("");
  const refreshPage = () => {
    window.location.reload();
  }

  function BuscarMedicos() {
    axios("http://localhost:5000/api/Medicos", {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 200) {
          setListaMedicos(resposta.data);
        }
      }).catch(erro => console.log(erro));
  }
  useEffect(BuscarMedicos, [])

  function BuscarClientes() {
    axios("http://localhost:5000/api/Clientes", {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 200) {
          setListaClientes(resposta.data);
        }
      }).catch(erro => console.log(erro));
  }
  useEffect(BuscarClientes, []);

  function BuscarConsultas() {
    axios("http://localhost:5000/api/Consultas", {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 200) {
          setListaConsultas(resposta.data);
        }
      }).catch(erro => console.log(erro));
  }
  useEffect(BuscarConsultas, []);

  function CadastrarConsulta(consulta) {
    axios.post("http://localhost:5000/api/Consultas", {
      idCliente: idCliente,
      idMedico: idMedico,
      idSituacao: idSituacao,
      dataConsulta: dataConsulta,
      descricaoConsulta: descricaoConsulta
    }, {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 201) {
          console.log("Nova consulta cadastrada.");
          BuscarConsultas();
          setIdCliente(0);
          setIdMedico(0);
          setIdSituacao(0);
          setDataConsulta("");
          setDescricaoConsulta("");
        }
      }).catch(erro => console.log(erro))
    consulta.preventDefault();
  }

  function AtualizarConsulta(consulta) {
    console.log(consulta.idConsulta);
    axios.patch('http://localhost:5000/api/consultas/situacao/' + consulta.idConsulta, {
      idSituacao: idSituacao,
    }, {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 201) {
          console.log("Consulta atualizada.");
          setIdSituacao(0);
        }
      }).catch(erro => console.log(erro))
    refreshPage();
  }

  return (

    <div>
      <Cabecalho />
      <section className="espaco-vazio">

      </section>

      <main>
        <section className="banner-consultas">
          <h1>Consultas</h1>
        </section>
        <section className="main-consultas">

          <form onSubmit={CadastrarConsulta} className="conteudo-main-consultas1">
            <h2>Para agendar uma consulta, insira seus dados:</h2>
            <div className="dados-consultas">Endereço de e-mail do cliente</div>

            <select className="caixa-consultas" value={idCliente} onChange={(campo) => setIdCliente(campo.target.value)}>
              <option value="0" disabled>Selecione o e-mail do cliente</option>
              {
                listaClientes.map((cliente) => {
                  return (
                    <option key={cliente.idCliente} value={cliente.idCliente}>
                      {cliente.idUsuarioNavigation.email}
                    </option>
                  )
                })
              }
            </select>

            <div className="dados-consultas">Endereço de e-mail do médico</div>

            <select className="caixa-consultas" value={idMedico} onChange={(campo) => setIdMedico(campo.target.value)}>
              <option value="0" disabled>Selecione o e-mail do médico</option>
              {
                listaMedicos.map((medico) => {
                  return (
                    <option key={medico.idMedico} value={medico.idMedico}>
                      {medico.idUsuarioNavigation.email}
                    </option>
                  )
                })
              }
            </select>

            <div className="dados-consultas">Data da consulta</div>
            <div className="barra-data">
              <input type="datetime-local" value={dataConsulta} onChange={(campo) =>
                setDataConsulta(campo.target.value)} />
            </div>
            <div className="dados-consultas">Situação da consulta</div>
            <div className="barra-data">
              <select value={idSituacao} onChange={(campo) =>
                setIdSituacao(campo.target.value)}>
                <option value="0" disabled>Selecione a situação</option>
                <option value="1" >Agendada</option>
                <option value="2" >Realizada</option>
                <option value="3" >Cancelada</option>
              </select>
            </div>
            <button type="submit" className="enviar">Agendar</button>
          </form>

          <section className="conteudo-main-consultas2">
            <h2>Próximas consultas:</h2>
            <div className="linha-suas-consultas"></div>

            {
              listaConsultas.map((consulta) => (
                <div key={consulta.idConsulta} className="caixa-suas-consultas">
                  <div className="conteudo-suas-consultas">
                    <div className="conteudo-suas-consultas1">
                      <div className="dado-suas-consultas">
                        <span>Nome completo:</span>
                        <p>{consulta.idClienteNavigation.nomeCliente}</p>
                      </div>
                      <div className="dado-suas-consultas">
                        <span>Médico:</span>
                        <p>{consulta.idMedicoNavigation.nomeMedico}</p>
                      </div>
                      <div className="dado-suas-consultas">
                        <span>Especialidade:</span>
                        <p>{consulta.idMedicoNavigation.idEspecialidadeMedicoNavigation.nomeEspecialidade}</p>
                      </div>
                      <div className="dado-suas-consultas">
                        <span>Descrição:</span>
                      </div>
                    </div>
                    <div className="conteudo-suas-consultas2">

                      <span className="situacao-consulta">{consulta.idSituacaoNavigation.tipoSituacao}</span>

                      <select className="selectSituacao" value={idSituacao} onChange={(campo) =>
                        setIdSituacao(campo.target.value)}>
                        <option value="0" disabled>Selecione a situação</option>
                        <option value="1" >Agendada</option>
                        <option value="2" >Realizada</option>
                        <option value="3" >Cancelada</option>
                      </select>
                      <button className="botaoAtualizar" onClick={() => { AtualizarConsulta(consulta); }}>Atualizar</button>


                      <div className="data-consulta">
                        <span>
                          Data:
                        </span>
                        <p>{Intl.DateTimeFormat({
                          year: "numeric", month: "numeric", day: "numeric"
                        }).format(new Date(consulta.dataConsulta))}</p>
                      </div>
                    </div>
                  </div>
                  <div className="descricao-suas-consultas">
                    <p>{consulta.descricaoConsulta}</p>
                  </div>
                </div>
              )
              )
            }

          </section>
        </section>
      </main>
      <Rodape />
    </div>
  )
}