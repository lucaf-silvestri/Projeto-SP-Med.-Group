import "../../assets/css/style.css"
import { Link } from 'react-router-dom';
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import MarqueConsulta from "../../components/marqueconsulta/marqueconsulta"
import { Component } from 'react';
import Cardiologia from "../../assets/img/Cardiologia-removebg-preview.png"
import Perfil from "../../assets/img/perfil.png"

export default class Medicos extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaMedicos: [],
            titulo: '',
            idMedicoAlterado: 0,
            titulosecao: 'Lista Medicos',
        };
    }

    BuscarMedicos = () => {
        console.log('Agora vamos fazer a chamada para a api.');
        fetch('http://localhost:5000/api/Medicos', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })

            .then((resposta) => resposta.json())
            .then((dados) => this.setState({ listaMedicos: dados }))
            .catch((erro) => console.log(erro));
    };

    componentDidMount() {
        this.BuscarMedicos();
    }

    render() {
        return (
            <div>
                <Cabecalho />
                <section class="espaco-vazio">

                </section>

                <main>
                    <section class="banner-medicos">
                        <h1>Médicos</h1>
                    </section>
                    <section class="main-medicos">
                        <section class="conteudo-main-medicos">
                            <section class="espaco-medicos">
                                <div class="espaco-vazio-medicos"></div>


                                {this.state.listaMedicos.map((medico) => {
                                    return (
                                        <div class="caixa-medico">
                                            <div class="foto-medico-container">
                                                <div class="circulo-perfil-medico">
                                                    <img src={Perfil} alt="Imagem de Perfil" />
                                                </div>
                                            </div>
                                            <div class="informacoes-medico">
                                                <div class="titulo-medico">{medico.nomeMedico}</div>
                                                <div class="linha-medico">
                                                    <div></div>
                                                </div>
                                                <div class="espe-cli-medico">
                                                    <div class="espe-cli-medico1">Especialidade:</div>
                                                    <div class="espe-cli-medico2">{medico.idEspecialidadeMedicoNavigation.nomeEspecialidade}</div>
                                                </div>
                                                <div class="espe-cli-medico">
                                                    <div class="espe-cli-medico1">Clínica:</div>
                                                    <div class="espe-cli-medico2">{medico.idClinicaNavigation.nomeFantasia}</div>
                                                </div>
                                            </div>
                                        </div>
                                    );
                                })}


                            </section>
                            <section class="espaco-consulta">
                                <div class="espaco-vazio-medicos"></div>
                                <div class="marque-uma-consulta">
                                    <div class="img-marque-uma-consulta"></div>
                                    <div class="titulo-marque-uma-consulta">
                                        <p>Marque sua consulta</p>
                                    </div>
                                    <div class="txt-marque-uma-consulta">
                                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                                    </div>
                                </div>
                            </section>
                        </section>
                    </section>
                </main>
                <Rodape />
            </div>
        )
    }
}