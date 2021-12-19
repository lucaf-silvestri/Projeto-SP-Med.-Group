import React from 'react'
import logo from '../../assets/img/logo.png'
import { Link } from 'react-router-dom';

export default function Footer() {
    return (
        <div className="marque-uma-consulta">
            <Link to="/consultasCli">
                <div className="img-marque-uma-consulta"></div>
                <div className="titulo-marque-uma-consulta">
                    <p>Marque sua consulta</p>
                </div>
                <div className="txt-marque-uma-consulta">
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                        sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                </div>
            </Link>
        </div>
    )
}