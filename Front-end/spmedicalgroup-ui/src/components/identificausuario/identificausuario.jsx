import { Link } from "react-router-dom";
import { usuarioAutenticado, parseJWT } from "../../services/auth"
import '../../assets/css/style.css';


export default function IdentificaUsuario() {

    if (usuarioAutenticado() === true) {
        switch (parseJWT().role) {
            case 1:
                return (<Link to="/consultasAdm" className="menu-click">Consultas</Link>)
            case 2:
                return (<Link to="/consultasMedico" className="menu-click">Consultas</Link>)
            case 3:
                return (<Link to="/consultasPaciente" className="menu-click">Consultas</Link>)
            default:
                return (<Link to="/" className="menu-click">Consultas</Link>)
        }
    }

    else {
        return <Link to="/login" className="menu-click">Consultas</Link>
    }
}