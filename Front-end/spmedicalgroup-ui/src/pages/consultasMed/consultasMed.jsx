import "../../assets/css/style.css"
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import "../../assets/css/style.css"
import React, { useState, useEffect } from "react";
import axios from "axios";

export default function ConsultasMedico() {
  const [listaConsultas, setListaConsultas] = useState([]);
  const [descricaoConsulta, setDescricaoConsulta] = useState("");
  const refreshPage = () => {
    window.location.reload();
  }

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

  function AtualizarConsulta(consulta) {
    console.log(consulta.idConsulta);
    axios.patch('http://localhost:5000/api/consultas/descricao/' + consulta.idConsulta, {
      descricaoConsulta: descricaoConsulta,
    }, {
      headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
    })
      .then(resposta => {
        if (resposta.status === 201) {
          console.log("Consulta atualizada.");
          setDescricaoConsulta("sas");
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
          <section className="conteudo-main-consultas-medico">
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


                    <input value={descricaoConsulta} onChange={(campo) => setDescricaoConsulta(campo.target.value)} placeholder={consulta.descricaoConsulta}/>
                    <button className="botaoAtualizar" onClick={() => { AtualizarConsulta(consulta); }}>Atualizar</button>



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