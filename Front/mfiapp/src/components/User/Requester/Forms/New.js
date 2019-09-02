import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

import {
    Button,
    FormGroup,
    Label,
    Input,
} from 'reactstrap';

const UserRequesterFormNew = () => {
    return (
        <form>
            <FormGroup>
                <Label for="txtEmail">Email</Label>
                <Input type="email" name="email" id="txtEmail" placeholder="Digite um email" />
            </FormGroup>
            <FormGroup>
                <Label for="txtName">Nome</Label>
                <Input type="name" name="name" id="txtName" placeholder="Digite o nome" />
            </FormGroup>
            <FormGroup>
                <Label for="txtPassword">Password</Label>
                <Input type="password" name="password" id="txtPassword" placeholder="Digite sua senha" />
            </FormGroup>
            <FormGroup>
                <Button className="button180" color="danger" title="Cancelar Criação de Cliente">
                    <FontAwesomeIcon icon="ban" />&nbsp;
                    Cancelar
                </Button>
                <Button className="button180" color="secondary" title="Limpar Campos">
                    <FontAwesomeIcon icon="eraser" />&nbsp;
                    Limpar
                </Button>
                <Button className="button180" color="success" title="Criar Cliente">
                    <FontAwesomeIcon icon="save" />&nbsp;
                    Criar Novo Cliente
                </Button>
            </FormGroup>
        </form>
    );
}

export default UserRequesterFormNew;