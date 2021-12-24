import { useState, useEffect } from "react";
import axios from "axios";
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import "../../assets/css/style.css"

export default function ConsultasCli() {
  const [listaConsultas, setListaConsultas] = useState([]);

  function BuscarConsultasEspecificas() {
    axios("http://localhost:5000/api/Consultas", {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 200) {
          setListaConsultas(resposta.data);
        }
      }).catch(erro => console.log(erro));
  }
  useEffect(BuscarConsultasEspecificas, []);

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
            <h2>Para marcar uma consulta, insira seus dados:</h2>
            <div className="dados-consultas">Endereço de e-mail</div>
            <input type="text" className="caixa-consultas"></input>
            <div className="dados-consultas">Senha</div>
            <input type="text" className="caixa-consultas"></input>
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
            <a href="#" className="enviar">Enviar</a>
          </section>
          <section className="conteudo-main-consultas2">
            <h2>Suas consultas:</h2>
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