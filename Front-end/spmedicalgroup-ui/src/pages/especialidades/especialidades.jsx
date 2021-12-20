import "../../assets/css/style.css"
import { Link } from 'react-router-dom';
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import MarqueConsulta from "../../components/marqueconsulta/marqueconsulta"
import { Component } from 'react';
import Cardiologia from "../../assets/img/Cardiologia-removebg-preview.png"

export default class Especialidades extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaEspecialidades: [],
            titulo: '',
            idEspecialidadeAlterada: 0,
            titulosecao: 'Lista Especialidades',
        };
    }

    BuscarEspecialidades = () => {
        console.log('Agora vamos fazer a chamada para a api.');
        fetch('http://localhost:5000/api/especialidadeMedicos', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })

            .then((resposta) => resposta.json())
            .then((dados) => this.setState({ listaEspecialidades: dados }))
            .catch((erro) => console.log(erro));
    };

    componentDidMount() {
        this.BuscarEspecialidades();
    }

    render() {
        return (
            <div>
                <Cabecalho />
                <section className="espaco-vazio">

                </section>

                <main>
                    <section className="banner-especialidades">
                        <h1>Especialidades</h1>
                    </section>
                    <section className="main-medicos">
                        <section className="conteudo-main-medicos">
                            <section className="espaco-medicos">
                                <div className="espaco-vazio-medicos"></div>

                                {this.state.listaEspecialidades.map((especialidade) => {
                                    return (
                                        <div className="caixa-especialidade" key={especialidade.idEspecialidadeMedico}>
                                            <div className="imagem-especialidade">
                                                <img src={Cardiologia} alt="Imagem da Especialidade" />
                                            </div>
                                            <div className="conteudo-especialidade">
                                                <h3>{especialidade.nomeEspecialidade}</h3>
                                                <div>
                                                    <div></div>
                                                </div>
                                                <p>{especialidade.descricaoEspecialidade}</p>
                                                <Link to="/consultasCli">Marcar uma consulta com essa especialidade</Link>
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