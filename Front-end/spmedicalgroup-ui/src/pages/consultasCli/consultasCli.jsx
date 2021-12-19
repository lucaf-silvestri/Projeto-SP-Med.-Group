import { useState, useEffect } from "react";
import axios from "axios";
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import "../../assets/css/style.css"

export default function ConsultasPaciente() {
  const [listaConsultas, setListaConsultas] = useState([]);

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

  function Descricao(idConsulta) {
    var textoDescricao = document.getElementById("descricao" + idConsulta);
    if (textoDescricao.value === null || textoDescricao.value === "" || textoDescricao.value === undefined) {
      textoDescricao.value = "Essa consulta não possui uma descrição.";
    }

    if (textoDescricao.style.display === "none") {
      textoDescricao.style.display = "";
    }

    else {
      textoDescricao.style.display = "none";
    }
  }

  return (
    <div>
      <Cabecalho />
      <section class="espaco-vazio">

      </section>

      <main>
        <section class="banner-consultas">
          <h1>Consultas</h1>
        </section>
        <section class="main-consultas">
          <section class="conteudo-main-consultas1">
            <h2>Para marcar uma consulta, insira seus dados:</h2>
            <div class="dados-consultas">Endereço de e-mail</div>
            <input type="text" placeholder class="caixa-consultas"></input>
            <div class="dados-consultas">Senha</div>
            <input type="text" placeholder class="caixa-consultas"></input>
            <div class="dados-consultas">Especialidade da consulta</div>
            <div class="barra-especialidade">
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
            <a href="#" class="enviar">Enviar</a>
          </section>
          <section class="conteudo-main-consultas2">
            <h2>Suas consultas:</h2>
            <div class="linha-suas-consultas"></div>

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