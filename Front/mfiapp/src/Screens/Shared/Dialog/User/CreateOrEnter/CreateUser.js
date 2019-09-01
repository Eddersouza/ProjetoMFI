import React from 'react'

import {
    Button
} from 'reactstrap';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

const AreaDialogCreateUser = () => {
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
                <li><FontAwesomeIcon className="text-success" icon="check" />Mostre suas promoções</li>
            </ul>
            <p><Button className="btn btn-info btn-block">Sim quero me registrar</Button></p>
        </>
    );
}

export default AreaDialogCreateUser;