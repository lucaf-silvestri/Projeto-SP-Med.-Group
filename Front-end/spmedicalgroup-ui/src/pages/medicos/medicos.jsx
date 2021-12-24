import "../../assets/css/style.css"
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import MarqueConsulta from "../../components/marqueconsulta/marqueconsulta"
import { Component } from 'react';
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
                <section className="espaco-vazio">

                </section>

                <main>
                    <section className="banner-medicos">
                        <h1>Médicos</h1>
                    </section>
                    <section className="main-medicos">
                        <section className="conteudo-main-medicos">
                            <section className="espaco-medicos">
                                <div className="espaco-vazio-medicos"></div>


                                {this.state.listaMedicos.map((medico) => {
                                    return (
                                        <div className="caixa-medico" key={medico.idMedico}>
                                            <div className="foto-medico-container">
                                                <div className="circulo-perfil-medico">
                                                    <img src={Perfil} alt="Imagem de Perfil" />
                                                </div>
                                            </div>
                                            <div className="informacoes-medico">
                                                <div className="titulo-medico">{medico.nomeMedico}</div>
                                                <div className="linha-medico">
                                                    <div></div>
                                                </div>
                                                <div className="espe-cli-medico">
                                                    <div className="espe-cli-medico1">Especialidade:</div>
                                                    <div className="espe-cli-medico2">{medico.idEspecialidadeMedicoNavigation.nomeEspecialidade}</div>
                                                </div>
                                                <div className="espe-cli-medico">
                                                    <div className="espe-cli-medico1">Clínica:</div>
                                                    <div className="espe-cli-medico2">{medico.idClinicaNavigation.nomeFantasia}</div>
                                                </div>
                                            </div>
                                        </div>
                                    );
                                })}


                            </section>
                            <section className="espaco-consulta">
                                <div className="espaco-vazio-medicos"></div>
                                <MarqueConsulta />
                            </section>
                        </section>
                    </section>
                </main>
                <Rodape />
            </div>
        )
    }
}