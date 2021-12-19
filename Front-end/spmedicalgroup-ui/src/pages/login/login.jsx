import { Component } from 'react';
import axios from 'axios';
import { parseJWT, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';
import '../../assets/css/style.css';

import Logo from "../../assets/img/logo.png"
import Google from "../../assets/img/google.png"

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false
        };
    };

    efetuaLogin = (event) => {
        event.preventDefault();

        this.setState({ erroMensagem: '', isLoading: true });
        axios.post('http://localhost:5000/api/login/login', {
            email: this.state.email,
            senha: this.state.senha
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    console.log('API')
                    localStorage.setItem("usuario-login", resposta.data.token);
                    this.setState({ isLoading: false });

                    let base64 = localStorage.getItem('usuario-login').split('.')[1];
                    console.log(base64);

                    let value = parseJWT().role;

                    switch (value) {
                        case "1":
                            this.props.history.push("/consultasAdm")
                            console.log("Estou logado: " + usuarioAutenticado())
                            break;

                        case "2":
                            this.props.history.push("/consultasMed")
                            console.log("Estou logado: " + usuarioAutenticado())
                            break;

                        case "3":
                            this.props.history.push("/consultasCli")
                            console.log("Estou logado: " + usuarioAutenticado())
                            break;

                        default:
                            this.props.history.push("/")
                            break;
                    }
                }
            }).catch(() => {
                this.setState({ erroMensagem: 'E-mail e/ou senha inválidos.', isLoading: false })
            })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }

    render() {
        return (
            <div>
                <header className="header-login">
                    <Link to="/" className="logo-header-login"><img src={Logo} alt="Logo do SP Medical Group" /></Link>
                </header>

                <main className="main-login">
                    <section className="conteudo-main-login">
                        <section className="conteudo-main-login-container">
                            <div className="para-continuar">Para continuar, faça seu login.</div>
                            <Link to="/login" className="google"><img src={Google} alt="Logo do Google" />Continuar com o Google</Link>
                            <section className="ou">
                                <div className="linha"></div>
                                <p>ou</p>
                                <div className="linha"></div>
                            </section>
                            <div className="email-senha">Endereço de e-mail</div>
                            <input
                                type="text"
                                name="email"
                                value={this.state.email}
                                className="caixa"
                                onChange={this.atualizaStateCampo}>
                            </input>

                            <div className="email-senha">Senha</div>

                            <input
                                type="password"
                                name="senha"
                                value={this.state.senha}
                                className="caixa"
                                onChange={this.atualizaStateCampo}>
                            </input>

                            <div className="loginbtn">
                                {
                                    this.state.isLoading === true &&
                                    <button type="submit" disabled className="entrar-login">Entrar</button>
                                }
                                {
                                    this.state.isLoading === false &&
                                    <button type="button" disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}
                                        className="entrar-login" onClick={this.efetuaLogin}>Entrar</button>
                                }
                            </div>
                            <p className="Erro">{this.state.erroMensagem}</p>

                        </section>
                    </section>
                </main>

                <footer>
                    <p>SP Medical Group - 2021</p>
                </footer>
            </div>
        )
    }
}