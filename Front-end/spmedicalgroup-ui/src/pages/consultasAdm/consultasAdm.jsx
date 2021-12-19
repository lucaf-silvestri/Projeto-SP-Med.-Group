import "../../assets/css/style.css"
import React, { useState, useEffect } from "react";
import { Link } from 'react-router-dom';
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
    consulta.preventDefault();
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
  }

  function AtualizarSituacao(idConsulta) {
    axios.patch("http://localhost:5000/api/Consultas/" + idConsulta, {
      idSituacao: idSituacao
    }, {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 204) {
          console.log("Consulta" + idConsulta + "atualizada.");
          document.getElementById(idConsulta).setAttribute("disabled", "disabled");
          var botao = document.getElementById("botao" + idConsulta)
          botao.style.display = "none";
          BuscarConsultas();
        }
      }).catch(erro => console.log(erro))
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
          <section className="conteudo-main-consultas1">
            <h2>Para agendar uma consulta, insira seus dados:</h2>
            <div className="dados-consultas">Endereço de e-mail do Cliente</div>
            <input type="text" placeholder="" className="caixa-consultas"></input>
            <div className="dados-consultas">Endereço de e-mail do médico</div>
            <input type="text" placeholder="" className="caixa-consultas"></input>
            <div className="dados-consultas">Especialidade da consulta</div>
            <div className="barra-especialidade">
              <select>
                <option>Acupuntura</option>
                <option>Anestesiologia</option>
                <option>Angiologia</option>
                <option>Cardiologia</option>
                <option>Cirurgia Cardiovascular</option>
                <option>Cirurgia da Mão</option>
                <option>Cirurgia do aparelho digestivo</option>
                <option>Cirurgia geral</option>
                <option>Cirurgia pediátrica</option>
                <option>Cirurgia plástica</option>
                <option>Cirurgia torácica</option>
                <option>Cirurgia vascular</option>
                <option>Dermatologia</option>
                <option>Radioterapia</option>
                <option>Urologia</option>
                <option>Pediatria</option>
                <option>Psiquiatria</option>
              </select>
            </div>
            <div className="dados-consultas">Data da consulta</div>
            <div className="barra-data">
              <input type="date">
              </input>
            </div>
            <Link to="/consultasAdm" className="enviar">Agendar</Link>
          </section>
          <section className="conteudo-main-consultas2">
            <h2>Próximas consultas:</h2>
            <div className="linha-suas-consultas"></div>

            {
              listaConsultas.map((consulta) => {
                return (
                  <div class="caixa-suas-consultas">
                    <div class="conteudo-suas-consultas">
                      <div class="conteudo-suas-consultas1">
                        <div class="dado-suas-consultas">
                          <span>Nome completo:</span>
                          <p>{consulta.idPacienteNavigation.nomePaciente}</p>
                        </div>
                        <div class="dado-suas-consultas">
                          <span>Médico:</span>
                          <p>{consulta.idMedicoNavigation.nomeMedico}</p>
                        </div>
                        <div class="dado-suas-consultas">
                          <span>Especialidade:</span>
                          <p>{consulta.idMedicoNavigation.idEspecialidadeMedicoNavigation.nomeEspecialidade}</p>
                        </div>
                        <div class="dado-suas-consultas">
                          <span>Descrição:</span>
                        </div>
                      </div>
                      <div class="conteudo-suas-consultas2">
                        <span class="situacao-consulta">Agendada</span>
                        <div class="data-consulta">
                          <span>
                            Data:
                          </span>
                          <p>{Intl.DateTimeFormat("pt-BR", {
                            year: "numeric", month: "long", day: "numeric", hour: "numeric", minute: "numeric"
                          }).format(new Date(consulta.dataConsulta))}</p>
                        </div>
                      </div>
                    </div>
                    <div class="descricao-suas-consultas">
                      <p>O suco de uva é uma excelente opção para hidratar e manter o bom funcionamento do corpo. Além
                        de ser uma bebida saborosa e que combina com qualquer época do ano, o suco integral da fruta
                        oferece uma variedade de benefícios para a saúde.</p>
                    </div>
                  </div>
                )
              }
              )
            }

          </section>
        </section>
      </main>
      <Rodape />
    </div>
  )
}