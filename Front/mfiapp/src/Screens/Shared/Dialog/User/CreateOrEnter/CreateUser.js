import React, { useContext } from 'react'

import {
    Button
} from 'reactstrap'

import { withRouter } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { DialogsContext } from '../../../../../Contexts/Dialogs';

const AreaDialogCreateUser = (props) => {
    const { toggleDialogEnterOrCreate } = useContext(DialogsContext)

    const goToChooseTypePage = () => {
        let path = `/usuario/escolher`
        props.history.push(path)
        toggleDialogEnterOrCreate()
    }

    return (
        <>
            <p className="lead">Registrar no sistema </p>
            <ul className="list-unstyled" style={{ lineHeight: '2' }}>
                <li><FontAwesomeIcon className="text-success" icon="check" /> Faça Orcamentos</li>
                {/* <li><FontAwesomeIcon className="text-success" icon="check" />Escolha seus fornecedores favoritos
                                </li>
                                <li><FontAwesomeIcon className="text-success" icon="check" />Avalie os fornecedores cadastrados
                            </li> */}
            </ul>
            Ou
                            <ul className="list-unstyled" style={{ lineHeight: '2' }}>
                <li><FontAwesomeIcon className="text-success" icon="check" />Mostre seus serviços</li>
                {/* <li><FontAwesomeIcon className="text-success" icon="check" />Mostre suas promoções</li> */}
            </ul>
            <p><Button className="btn btn-info btn-block" onClick={goToChooseTypePage}>Sim quero me registrar</Button></p>
        </>
    )
}

export default withRouter(AreaDialogCreateUser)