import "../../assets/css/style.css"
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import { Component } from 'react';

export default class Unidades extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaUnidades: [],
            titulo: '',
            idUnidadeAlterada: 0,
            titulosecao: 'Lista Unidades',
        };
    }

    BuscarUnidades = () => {
        console.log('Agora vamos fazer a chamada para a api.');
        fetch('http://localhost:5000/api/Clinicas', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })

            .then((resposta) => resposta.json())
            .then((dados) => this.setState({ listaUnidades: dados }))
            .catch((erro) => console.log(erro));
    };

    componentDidMount() {
        this.BuscarUnidades();
    }

    render() {
        return (
            <div>
                <Cabecalho />
                <section className="espaco-vazio">

                </section>

                <main>
                    <section className="banner-unidades">
                        <h1>Unidades</h1>
                    </section>
                    <section className="main-unidades">
                        <section className="conteudo-main-unidades">
                            <div className="espaco-vazio-medicos"></div>

                            {this.state.listaUnidades.map((unidade) => {
                                return (
                                    <div className="caixa-unidades">
                                        <div className="conteudo-caixa-unidades">
                                            <div className="conteudo-caixa-unidades2">
                                                <div className="titulo-unidades">{unidade.nomeFantasia}</div>
                                                <div className="end-hor-unidades">
                                                    <div className="end-hor-unidades1">Endereço:</div>
                                                    <div className="end-hor-unidades2">{unidade.enderecoClinica}</div>
                                                </div>
                                                <div className="end-hor-unidades">
                                                    <div className="end-hor-unidades1">Horário de atendimento:</div>
                                                    <div className="end-hor-unidades2">{unidade.horarioInicio} - {unidade.horarioFim}</div>
                                                </div>
                                            </div>
                                        </div>
                                        <div className="mapa">
                                        </div>
                                    </div>
                                );
                            })}

                        </section>
                    </section>
                </main>
                <Rodape />
            </div>
        )
    }
}