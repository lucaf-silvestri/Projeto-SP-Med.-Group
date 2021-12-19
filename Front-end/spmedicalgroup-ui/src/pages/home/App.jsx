import "../../assets/css/style.css"
import { Link } from 'react-router-dom';
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"

import MalucoMedicoLa from "../../assets/img/maluco medico la.jpg"
import Acupuntura from "../../assets/img/Acupuntura-removebg-preview.png"
import Anestesiologia from "../../assets/img/Anestesiologia-removebg-preview.png"
import Angiologia from "../../assets/img/Angiologia-removebg-preview.png"
import Dermatologia from "../../assets/img/Dermatologia-removebg-preview.png"
import Cardiologia from "../../assets/img/Cardiologia-removebg-preview.png"
import Psiquiatria from "../../assets/img/Psiquiatria-removebg-preview.png"

export default function Home() {
  return (
    <div>
      <Cabecalho />
      <main>
        <section className="banner">
          <section className="banner-container">
            <section className="textos-banner">
              <h1>O melhor em saúde para você</h1>
              <p>Conheça nossa plataforma, acesse ou agende facilmente consultas com comodidade e em diversas
                especialidades. </p>
            </section>
          </section>
        </section>

        <section className="unidades-home">
          <section className="unidades-home-container">
            <Link to="/unidades"><span className="unidades-uppercase" id="back-to-top">Unidades</span></Link>
            <div className="clinicas-home">
              <Link to="/unidades"><span className="nome-clinica">Clínica Possarle</span></Link>
              <Link to="/unidades"><span className="dados-clinica">Endereço: Av. Barão Limeira, 532, São Paulo, SP</span></Link>
            </div>
            <div className="clinicas-home">
              <Link to="/unidades"><span className="nome-clinica">Clínica Possarle</span></Link>
              <Link to="/unidades"><span className="dados-clinica">Endereço: Av. Barão Limeira, 532, São Paulo, SP</span></Link>
            </div>
            <div className="clinicas-home">
              <Link to="/unidades"><span className="nome-clinica">Clínica Possarle</span></Link>
              <Link to="/unidades"><span className="dados-clinica">Endereço: Av. Barão Limeira, 532, São Paulo, SP</span></Link>
            </div>
          </section>
        </section>
        <section className="fundo1">
          <div className="retangulo-torto">
            <div className="retangulo-torto-container">
              <img src={MalucoMedicoLa} className="medico-sobre"
                alt="Imagem de médico examinando um paciente." />
              <div className="textos-sobre">
                <p className="titulo-sobre">
                  Sobre o SP Medical Group
                </p>
                <p className="texto-sobre">
                  O SP Medical Group foi criado pelo médico Fernando Strada em 2020, em São Paulo. Temos
                  uma
                  equipe de médicos preparados que atuam nas mais diversas áreas, como pediatria,
                  odontologia
                  e
                  gastrenterologia, prontos para atender nossos clientes com equipamentos modernos em um
                  espaço
                  amplo e confortável para os profissionais e pacientes.
                </p>
              </div>
            </div>
          </div>
        </section>
        <section className="fundo2">
          <div className="nossas-especialidades">
            <div className="titulo-nossas-especialidades">
              <p>Nossas Especialidades</p>
            </div>
            <div className="especialidades-home">
              <div className="especialidades-home-container">
                <section className="quadrado-especialidade">
                  <section className="img-especialidade">
                    <img src={Acupuntura} alt="Ícone de Acupuntura" />
                  </section>
                  <section className="txt-especialidade">
                    <p className="titulo-txt-especialidade">
                      Acupuntura
                    </p>
                    <p className="texto-txt-especialidade">
                      Terapia que consiste na aplicação de agulhas em pontos específicos do corpo para tratar doenças e para promover saúde.
                    </p>
                  </section>
                </section>
                <section className="quadrado-especialidade">
                  <section className="img-especialidade">
                    <img src={Anestesiologia} alt="Ícone de Anestesiologia" />
                  </section>
                  <section className="txt-especialidade">
                    <p className="titulo-txt-especialidade">
                      Anestesiologia
                    </p>
                    <p className="texto-txt-especialidade">
                      Proporciona ausência ou alívio da dor ao paciente ao realizar procedimentos médicos, como cirurgias.
                    </p>
                  </section>
                </section>
                <section className="quadrado-especialidade">
                  <section className="img-especialidade">
                    <img src={Angiologia} alt="Ícone de Acupuntura" />
                  </section>
                  <section className="txt-especialidade">
                    <p className="titulo-txt-especialidade">
                      Angiologia
                    </p>
                    <p className="texto-txt-especialidade">
                      Estudo, diagnóstico e tratamento clínico das doenças vasculares.
                    </p>
                  </section>
                </section>
              </div>
            </div>
            <div className="especialidades-home">
              <div className="especialidades-home-container">
                <section className="quadrado-especialidade">
                  <section className="img-especialidade">
                    <img src={Dermatologia} alt="Ícone de Acupuntura" />
                  </section>
                  <section className="txt-especialidade">
                    <p className="titulo-txt-especialidade">
                      Dermatologia
                    </p>
                    <p className="texto-txt-especialidade">
                      Diagnóstico, prevenção e tratamento de doenças e afecções relacionadas à pele, pelos, mucosas, cabelo e unhas.
                    </p>
                  </section>
                </section>
                <section className="quadrado-especialidade">
                  <section className="img-especialidade">
                    <img src={Cardiologia} alt="Ícone de Cardiologia" />
                  </section>
                  <section className="txt-especialidade">
                    <p className="titulo-txt-especialidade">
                      Cardiologia
                    </p>
                    <p className="texto-txt-especialidade">
                      Diagnóstico e tratamento das doenças que acometem o coração e outros componentes do sistema circulatório.
                    </p>
                  </section>
                </section>
                <section className="quadrado-especialidade">
                  <section className="img-especialidade">
                    <img src={Psiquiatria} alt="Ícone de Psiquiatria" />
                  </section>
                  <section className="txt-especialidade">
                    <p className="titulo-txt-especialidade">
                      Psiquiatria
                    </p>
                    <p className="texto-txt-especialidade">
                      Diagnóstico, prevenção e tratamento das diferentes formas de sofrimentos mentais, com manifestações psicológicas severas.
                    </p>
                  </section>
                </section>
              </div>
            </div>
            <div className="ver-todas">
              <div className="ver-todas-container">
                <div className="ver-todas-botao">
                  <Link to="/especialidades"><span>Ver todas as especialidades</span></Link>
                </div>
              </div>
            </div>
          </div>
        </section>

      </main>
      <Rodape />
    </div>
  )
}