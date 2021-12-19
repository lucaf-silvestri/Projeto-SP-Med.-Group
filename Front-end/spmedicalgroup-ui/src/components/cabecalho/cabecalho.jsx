import React from 'react'
import logo from '../../assets/img/logo.png'
import { Link } from 'react-router-dom';
import '../../assets/css/style.css';

import IdentificaUsuario from '../identificausuario/identificausuario'

export default function Header() {
    return (
        <header>
        <section className="container-header">
            <section className="conteudo-header">
                <section className="menu">
                    <span className="logo"><Link to="/"><img src={logo} alt="Logo SP Medical Group"/></Link></span>
                    <Link to="/medicos"><span className="menu-click">Médicos</span></Link>
                    <Link to="/especialidades"><span className="menu-click">Especialidades</span></Link>
                    <Link to="/unidades"><span className="menu-click">Unidades</span></Link>
                    <Link to="/consultasCli"><span className="menu-click">Consultas</span></Link>
                </section>
                <Link to="/login" className="entrar"><span>Entrar</span></Link>
            </section>
        </section>
    </header>
    )
}