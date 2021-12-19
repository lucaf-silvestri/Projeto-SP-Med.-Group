import React from 'react';
import ReactDOM from 'react-dom';
import {  Route, BrowserRouter as Router, Redirect, Switch } from 'react-router-dom';
import { parseJWT, usuarioAutenticado } from './services/auth';
import axios from 'axios';

import './index.css';

import Home from './pages/home/App';
import Login from './pages/login/login';
import Especialidades from './pages/especialidades/especialidades';
import Unidades from './pages/unidades/unidades';
import Medicos from './pages/medicos/medicos';
import NotFound from './pages/notFound/notFound';
import ConsultasAdm from './pages/consultasAdm/consultasAdm';
import ConsultasMed from './pages/consultasMed/consultasMed';
import ConsultasCli from './pages/consultasCli/consultasCli';

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJWT().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const PermissaoMed = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJWT().role === '2' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const PermissaoCli = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJWT().role === '3' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/login" component={Login} />
        <PermissaoAdm path="/consultasAdm" component={ConsultasAdm}/>
        <PermissaoMed path="/consultasMed" component={ConsultasMed} />
        <PermissaoCli path="/consultasCli" component={ConsultasCli} />
        <Route path="/medicos" component={Medicos} />
        <Route path="/unidades" component={Unidades} />
        <Route path="/especialidades" component={Especialidades} />

        <Route path="/notFound" component={NotFound} />
        <Redirect to="/notFound" />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(  
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
