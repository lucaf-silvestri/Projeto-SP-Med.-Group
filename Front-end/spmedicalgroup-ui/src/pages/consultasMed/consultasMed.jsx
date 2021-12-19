import "../../assets/css/style.css"
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import "../../assets/css/style.css"
import React, { useState, useEffect } from "react";
import axios from "axios";

export default function ConsultasMedico() {
  const [listaConsultas, setListaConsultas] = useState([]);
  const [descricao, setDescricao] = useState("");
  const [idCliente, setIdCliente] = useState(0);
  const [idMedico, setIdMedico] = useState(0);
  const [idSituacao, setIdSituacao] = useState(0);
  const [listaClientes, setListaClientes] = useState([]);
  const [listaMedicos, setListaMedicos] = useState([]);
  const [dataConsulta, setDataConsulta] = useState(new Date());
  const [descricaoConsulta, setDescricaoConsulta] = useState("");

  function BuscarConsultasEspecificas() {
    axios("http://localhost:5000/api/Consultas/Minhas", {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 200) {
          setListaConsultas(resposta.data);
        }
      }).catch(erro => console.log(erro));
  }
  useEffect(BuscarConsultasEspecificas, []);

  function Descricao(idConsulta, descricaoConsulta) {
    setDescricao(descricaoConsulta);
    var textoDescricao = document.getElementById("descricao" + idConsulta)
    textoDescricao.removeAttribute("leitura");

    if (textoDescricao.value === null || textoDescricao.value === "" || textoDescricao.value === undefined) {
      textoDescricao.value = "Adicionar descrição";
    }

    if (textoDescricao.style.display === "none") {
      textoDescricao.style.display = "";
    }
    
    else {
      textoDescricao.style.display = "none";
    }

    var botao = document.getElementById("botao" + idConsulta);

    if (botao.style.display === "none") {
      botao.style.display = "";
    } else {
      setDescricao("")
      botao.style.display = "none";
    }
  }

  function AtualizarDescricao(idConsulta) {
    console.log(descricao + idConsulta)
    //!Atualizar API!
    axios.patch("http://localhost:5000/api/Consultas/descricao/" + idConsulta, {
      descricaoConsulta: descricao
    }, {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 204) {
          var botao = document.getElementById("botao" + idConsulta)
          botao.style.display = "none";
          BuscarConsultasEspecificas();
          setDescricao("")
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
          <section className="conteudo-main-consultas-medico">
            <h2>Suas consultas:</h2>
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
                    <div className="descricao-suas-consultas-medico">
                      <input placeholder="Adicionar descrição" />
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